
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
public class GPURender
{
	/**
	 *	Configurable options
	 */
	private static final int CL_DATATYPE_SIZE = Sizeof.cl_float;
	
	private static int TRANSFORM_LWG_SIZE = 512;
	private static int RENDER_LWG_SIZE = 512;
	
	private static float PSF_SIGMA = 1.8f;
	
	private static float PIXEL_SIZE = 64.0f;
	
	private static boolean USE_BINNING_METHOD = false;
	
	public static void setTransformLWGS(int lwgs)
	{
		TRANSFORM_LWG_SIZE = lwgs;
	}
	
	public static void setRenderLWGS(int lwgs)
	{
		RENDER_LWG_SIZE = lwgs;
	}
	
	public static void setPSFSigma(float sigma)
	{
		PSF_SIGMA = sigma;
	}
	
	public static void setPixelSize(float size)
	{
		PIXEL_SIZE = size;
	}
	
	public static void setBinningMethod(boolean binning)
	{
		USE_BINNING_METHOD = binning;
	}
	
	/**
	 *	Hidden constructor
	 */
	private GPURender() {}
	
	// ************************************************************************************
	
	public static ImageProcessor run(GPUBase gpu, ResultsTable fluorophores, ImageProcessor image)
	{
		// limit work group sizes to maximum
		int maxWorkGroupSize = (int) gpu.getMaxWorkGroupSize();
		if(TRANSFORM_LWG_SIZE > maxWorkGroupSize)
		{
			TRANSFORM_LWG_SIZE = maxWorkGroupSize;
		}
		if(RENDER_LWG_SIZE > maxWorkGroupSize)
		{
			RENDER_LWG_SIZE = maxWorkGroupSize;
		}
		
		// round work group sizes to nearest multiple of 16
		TRANSFORM_LWG_SIZE = (int) (Math.round(TRANSFORM_LWG_SIZE / 16.0f) * 16);
		RENDER_LWG_SIZE = (int) (Math.round(RENDER_LWG_SIZE / 16.0f) * 16);
		
		// get number of available compute units
		long availableComputeUnits = gpu.getNumberOfComputeUnits();
		
		// ------------------------------------------------------------------
		
		// customizable parameters
		//final float psf_sigma_x = PSF_SIGMA;
		//final float psf_sigma_y = PSF_SIGMA;
		final float[] transformation_matrix = new float[]{
			1.0f/PIXEL_SIZE,	0.0f,		0.0f,		0.0f,
			0.0f,		1.0f/PIXEL_SIZE,	0.0f,		0.0f,
			0.0f,		0.0f,		1.0f/PIXEL_SIZE,	0.0f,
			0.0f,		0.0f,		0.0f,		1.0f
		};
		
		// retrieve image paramaters
		final int image_width = image.getWidth();
		final int image_height = image.getHeight();
		final int pixel_count = image_width * image_height;
		final int padded_pixel_count = (int) (Math.ceil(pixel_count / (float)RENDER_LWG_SIZE) * RENDER_LWG_SIZE);
		
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
		
		// ------------------------------------------------------------------
		
		// create memory data buffers
		cl_mem fluorophore_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 4 *padded_fluorophore_count * CL_DATATYPE_SIZE, null, null);
		cl_mem transformation_matrix_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 16 * CL_DATATYPE_SIZE, null, null);
		cl_mem image_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_WRITE_ONLY, padded_pixel_count * CL_DATATYPE_SIZE, null, null);
		//cl_mem local_data_buffer = clCreateBuffer(gpu._ocl_context, CL_MEM_READ_WRITE, 4 * RENDER_LWG_SIZE * CL_DATATYPE_SIZE, null, null);
		
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
		cl_kernel render_kernel = null;
		if(USE_BINNING_METHOD)
		{
			render_kernel = clCreateKernel(gpu._ocl_program, "bin_fluorophores", null);
		}
		else
		{
			render_kernel = clCreateKernel(gpu._ocl_program, "convolve_fluorophores", null);
		}
		clSetKernelArg(render_kernel, 0, Sizeof.cl_mem, Pointer.to(image_data_buffer));
		clSetKernelArg(render_kernel, 1, Sizeof.cl_int, Pointer.to(new int[]{image_width}));
		clSetKernelArg(render_kernel, 2, Sizeof.cl_int, Pointer.to(new int[]{image_height}));
		clSetKernelArg(render_kernel, 3, Sizeof.cl_mem, Pointer.to(fluorophore_data_buffer));
		clSetKernelArg(render_kernel, 4, 4 * CL_DATATYPE_SIZE * RENDER_LWG_SIZE, null); //Pointer.to(local_data_buffer));
		clSetKernelArg(render_kernel, 5, Sizeof.cl_int, Pointer.to(new int[]{fluorophore_count}));
		
		// ------------------------------------------------------------------
		
		// profiling
		long start_time = 0l;
		long end_time = 0l;
		cl_event kernel_event = new cl_event();
		long[] profiling_result = new long[1];
		double time_diff = (double)(end_time - start_time);
		String[] units = new String[]{"nanoseconds", "microseconds", "milliseconds", "seconds", "minutes", "hours", "way too long!"};
		int unit_index = 0;
		
		// ------------------------------------------------------------------
		
		// write data to memory buffers
		clEnqueueWriteBuffer(gpu._ocl_queue, fluorophore_data_buffer, true, 0, 4 * fluorophore_count * CL_DATATYPE_SIZE, Pointer.to(fluorophore_data), 0, null, null);
		clEnqueueWriteBuffer(gpu._ocl_queue, transformation_matrix_buffer, true, 0, 16 * CL_DATATYPE_SIZE, Pointer.to(transformation_matrix), 0, null, null);
		
		// ==================================================================
		
		// STEP 1: transform the fluorophores to image space
		clEnqueueNDRangeKernel(gpu._ocl_queue, transform_kernel, 1, null, new long[]{padded_fluorophore_count}, new long[]{TRANSFORM_LWG_SIZE}, 0, null, kernel_event);
		
		// ==================================================================
		
		// get profiling information
		clWaitForEvents(1, new cl_event[]{kernel_event});
		clGetEventProfilingInfo(kernel_event, CL_PROFILING_COMMAND_START, Sizeof.cl_long, Pointer.to(profiling_result), null);
		start_time = profiling_result[0];
		clGetEventProfilingInfo(kernel_event, CL_PROFILING_COMMAND_END, Sizeof.cl_long, Pointer.to(profiling_result), null);
		end_time = profiling_result[0];
		
		// print profiling information
		time_diff = (double)(end_time - start_time);
		unit_index = 0;
		while(time_diff > 1e3f && unit_index < 3)
		{
			time_diff /= 1e3f;
			++unit_index;
		}
		while(time_diff > 60f && unit_index < 5)
		{
			time_diff /= 60f;
			++unit_index;
		}
		System.err.format("Transformation of fluorophores took %.1f %s\n", (time_diff), units[unit_index]);
		
		// ------------------------------------------------------------------
		
//		// DEBUG: retrieve transformed fluorophore data
//		float[] transformed_fluorophores_data = new float[4*fluorophore_count];
//		clEnqueueReadBuffer(gpu._ocl_queue, fluorophore_data_buffer, CL_TRUE, 0, 4 * fluorophore_count * CL_DATATYPE_SIZE, Pointer.to(transformed_fluorophores_data), 0, null, null);
//
//		// DEBUG: print transformed fluorophore data
//		for(int i = 0; i < transformed_fluorophores_data.length; i+=4)
//		{
//			System.err.println(transformed_fluorophores_data[i] + "," + transformed_fluorophores_data[i+1] + "," + transformed_fluorophores_data[i+2] + "," + transformed_fluorophores_data[i+3]);
//		}
		
		// ==================================================================
		
		// STEP 2: render the fluorophores into an image
		// NOTE: render is performed per sector (or batch of pixels)
		//       to avoid watchdog timer kick in (and looks cool :D)
		clEnqueueNDRangeKernel(gpu._ocl_queue, render_kernel, 1, null, new long[]{padded_pixel_count}, new long[]{RENDER_LWG_SIZE}, 0, null, kernel_event);
		
		// ==================================================================
		
		// get profiling information
		clWaitForEvents(1, new cl_event[]{kernel_event});
		clGetEventProfilingInfo(kernel_event, CL_PROFILING_COMMAND_START, Sizeof.cl_long, Pointer.to(profiling_result), null);
		start_time = profiling_result[0];
		clGetEventProfilingInfo(kernel_event, CL_PROFILING_COMMAND_END, Sizeof.cl_long, Pointer.to(profiling_result), null);
		end_time = profiling_result[0];
		
		// print profiling information
		time_diff = (double)(end_time - start_time);
		unit_index = 0;
		while(time_diff > 1e3f && unit_index < 3)
		{
			time_diff /= 1e3f;
			++unit_index;
		}
		while(time_diff > 60f && unit_index < 5)
		{
			time_diff /= 60f;
			++unit_index;
		}
		System.err.format("Convolution of fluorophores took %.1f %s\n", (time_diff), units[unit_index]);
		
		// retrieve image data
		float[] image_data = new float[pixel_count];
		clEnqueueReadBuffer(gpu._ocl_queue, image_data_buffer, CL_TRUE, 0, pixel_count * CL_DATATYPE_SIZE, Pointer.to(image_data), 0, null, null);
		
		// convert data into image (row-major)
		for(int py = 0; py < image_height; ++py)
		{
			for(int px = 0; px < image_width; ++px)
			{
				int index = py * image_width + px;
				image.putPixelValue(px, py, image_data[index]);
			}
		}
		
		// ------------------------------------------------------------------
		
		// release kernels
		clReleaseKernel(transform_kernel);
		clReleaseKernel(render_kernel);
		
		// release buffers
		clReleaseMemObject(fluorophore_data_buffer);
		clReleaseMemObject(transformation_matrix_buffer);
		clReleaseMemObject(image_data_buffer);
		//clReleaseMemObject(local_data_buffer);
		
		// ------------------------------------------------------------------
		
		// return image
		return image;
	}
}
