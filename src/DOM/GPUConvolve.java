
package DOM;

// ImageJ
//import static ij.IJ.*;
import ij.IJ;
import ij.ImagePlus;
import ij.ImageStack;
import ij.process.ImageProcessor;

import ij.measure.ResultsTable;

// OpenCL
import static org.jocl.CL.*;
import org.jocl.*;

// Java
//import java.io.File;

/**
 *
 */
public class GPUConvolve
{
	/**
	 *	Configurable options
	 */
	private static final int CL_DATATYPE_SIZE = Sizeof.cl_float;
	
	private static final int TRANSFORM_LWG_SIZE = 512;
	private static final int CONVOLVE_LWG_SIZE = 512;
	
	/**
	 *	Hidden constructor
	 */
	private GPUConvolve() {}
	
	// ************************************************************************************
	
	public static ImageProcessor run(GPUBase gpu, ResultsTable fluorophores, ImageProcessor image)
	{
		// customizable parameters
		final float psf_sigma_x = 1.8f;
		final float psf_sigma_y = 1.8f;
		final float[] transformation_matrix = new float[]{
			1.0f/64.0f,	0.0f,		0.0f,		0.0f,
			0.0f,		1.0f/64.0f,	0.0f,		0.0f,
			0.0f,		0.0f,		1.0f/64.0f,	0.0f,
			0.0f,		0.0f,		0.0f,		1.0f
		};
		
		// retrieve image paramaters
		final int image_width = image.getWidth();
		final int image_height = image.getHeight();
		final int pixel_count = image_width * image_height;
		final int padded_pixel_count = (int) (Math.ceil(pixel_count / (float)CONVOLVE_LWG_SIZE) * CONVOLVE_LWG_SIZE);
		
		// retrieve fluorophore paramters
		final int fluorophore_count = fluorophores.getCounter();
		final int padded_fluorophore_count = (int) (Math.ceil(pixel_count / (float)TRANSFORM_LWG_SIZE) * TRANSFORM_LWG_SIZE);
		
		final float[] fluorophore_x = fluorophores.getColumn(0);
		final float[] fluorophore_y = fluorophores.getColumn(1);
		final float[] fluorophore_z = fluorophores.getColumn(2);
		final float[] fluorophore_w = fluorophores.getColumn(3);
		
		if(fluorophore_x.length != fluorophore_y.length || fluorophore_z.length != fluorophore_w.length || fluorophore_y.length != fluorophore_z.length)
		{
			System.err.println("Number of fluorophore coordinates do not match!");
			return null;
		}
		
		// convert data into (x,y,z,w)+ format
		float[] fluorophore_data = new float[4*fluorophore_count];
		for(int i = 0; i < fluorophore_count; ++i)
		{
			fluorophore_data[4*i+0] = fluorophore_x[i];
			fluorophore_data[4*i+1] = fluorophore_y[i];
			fluorophore_data[4*i+2] = fluorophore_z[i];
			fluorophore_data[4*i+3] = fluorophore_w[i];
		}
		
		// create memory data buffers
		cl_mem fluorophore_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 4 *padded_fluorophore_count * CL_DATATYPE_SIZE, null, null);
		cl_mem transformation_matrix_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 16 * CL_DATATYPE_SIZE, null, null);
		cl_mem image_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_WRITE_ONLY, padded_pixel_count * CL_DATATYPE_SIZE, null, null);
		//cl_mem local_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 4 * CONVOLVE_LWG_SIZE * CL_DATATYPE_SIZE, null, null);
		
		// create kernel objects
		
		// __kernel void transform_fluorophores (
		// 0: __global union fluorophore_t* const fluorophores,
		// 1: __constant const scalar_t* const transformation_matrix)
		cl_kernel transform_kernel = clCreateKernel(gpu._ocl_program, "transform_fluorophores", null);
		
		
		clSetKernelArg(transform_kernel, 0, Sizeof.cl_mem, Pointer.to(fluorophore_data_buffer));
		clSetKernelArg(transform_kernel, 1, Sizeof.cl_mem, Pointer.to(transformation_matrix_buffer));
		
		// __kernel void convolve_fluorophores (
		// 0: __global pixel_t* const image,
		// 1: __private const int image_width,
		// 2: __private const int image_height,
		// 3: __global const union fluorophore_t* const global_fluorophores,
		// 4: __local union fluorophore_t* local_fluorophores,
		// 5: __private const int fluorophore_count)
		cl_kernel convolve_kernel = clCreateKernel(gpu._ocl_program, "convolve_fluorophores", null);
		
		clSetKernelArg(convolve_kernel, 0, Sizeof.cl_mem, Pointer.to(image_data_buffer));
		clSetKernelArg(convolve_kernel, 1, Sizeof.cl_int, Pointer.to(new int[]{image_width}));
		clSetKernelArg(convolve_kernel, 2, Sizeof.cl_int, Pointer.to(new int[]{image_height}));
		clSetKernelArg(convolve_kernel, 3, Sizeof.cl_mem, Pointer.to(fluorophore_data_buffer));
		clSetKernelArg(convolve_kernel, 4, 4 * CL_DATATYPE_SIZE * CONVOLVE_LWG_SIZE, null); //Pointer.to(local_data_buffer));
		clSetKernelArg(convolve_kernel, 5, Sizeof.cl_int, Pointer.to(new int[]{fluorophore_count}));
		
		// write data to memory buffers
		clEnqueueWriteBuffer(gpu._ocl_queue, fluorophore_data_buffer, true, 0, 4 * fluorophore_count * CL_DATATYPE_SIZE, Pointer.to(fluorophore_data), 0, null, null);
		clEnqueueWriteBuffer(gpu._ocl_queue, transformation_matrix_buffer, true, 0, 16 * CL_DATATYPE_SIZE, Pointer.to(transformation_matrix), 0, null, null);
		
		// transform the fluorophores to image space
		long start_time = System.nanoTime();
		clEnqueueNDRangeKernel(gpu._ocl_queue, transform_kernel, 1, null, new long[]{padded_fluorophore_count}, new long[]{TRANSFORM_LWG_SIZE}, 0, null, null);
		long end_time = System.nanoTime();
		System.err.println("Transformation of fluorophores took " + (end_time - start_time) + " nanoseconds");
		
		// retrieve transformed fluorophore data
		float[] transformed_fluorophores_data = new float[4*fluorophore_count];
		clEnqueueReadBuffer(gpu._ocl_queue, fluorophore_data_buffer, CL_TRUE, 0, 4 * fluorophore_count * CL_DATATYPE_SIZE, Pointer.to(transformed_fluorophores_data), 0, null, null);
		
//		for(int i = 0; i < transformed_fluorophores_data.length; i+=4)
//		{
//			System.err.println(transformed_fluorophores_data[i] + "," + transformed_fluorophores_data[i+1] + "," + transformed_fluorophores_data[i+2] + "," + transformed_fluorophores_data[i+3]);
//		}
		
		// convolve the fluorophores into an image
		start_time = System.nanoTime();
		clEnqueueNDRangeKernel(gpu._ocl_queue, convolve_kernel, 1, null, new long[]{padded_pixel_count}, new long[]{CONVOLVE_LWG_SIZE}, 0, null, null);
		end_time = System.nanoTime();
		System.err.println("Convolution of fluorophores took " + (end_time - start_time) + " nanoseconds");
		
		// retrieve image data
		float[] image_data = new float[pixel_count];
		clEnqueueReadBuffer(gpu._ocl_queue, image_data_buffer, CL_TRUE, 0, pixel_count * CL_DATATYPE_SIZE, Pointer.to(image_data), 0, null, null);
		
		// convert data into image (row-major)
		for(int py = 0; py < image_height; ++py)
		{
			for(int px = 0; px < image_width; ++px)
			{
				int index = py * image_width + px;
//				System.err.println("(" + px + "," + py + " = " + image_data[index]);
				image.putPixelValue(px, py, image_data[index]);
			}
		}
		
		// release kernels
		clReleaseKernel(transform_kernel);
		clReleaseKernel(convolve_kernel);
		
		// release buffers
		clReleaseMemObject(fluorophore_data_buffer);
		clReleaseMemObject(transformation_matrix_buffer);
		clReleaseMemObject(image_data_buffer);
		//clReleaseMemObject(local_data_buffer);
		
		// return image
		return image;
	}
}
