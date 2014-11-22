
package DOM;

// import Java classes
import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
//import java.io.FileReader;

// import ImageJ classes
import ij.IJ;
import ij.plugin.PlugIn;
import ij.ImagePlus;
import ij.process.ImageProcessor;
import ij.process.FloatProcessor;

import ij.measure.ResultsTable;
import ij.gui.GenericDialog;

// import OpenCL classes
import org.jocl.CLException;


/**
 *	Wrapper for the plugin
 */
public class GPUConvolve_plugin implements PlugIn
{
	/**
	 *	Members
	 */
	
	/**
	 *	Constructor
	 */
	public GPUConvolve_plugin() { /* empty */ }
	
	// ////////////////////////////////////////////////////////////////////////
	
	public void run(String arg)
	{
		IJ.register(GPUConvolve_plugin.class); // avoid garbage collection
		IJ.register(GPUConvolve.class); // avoid garbage collection
		
		// ask for parameters
		GenericDialog gd = new GenericDialog("Convolve fluorophores");
		gd.addNumericField("Image width:", 0, 0);
		gd.addNumericField("Image height:", 0, 0);
		gd.showDialog();
		if(gd.wasCanceled()) return;
		
		// retrieve parameters
		int image_width = (int) gd.getNextNumber();
		int image_height = (int) gd.getNextNumber();
		
		// DEBUG: print parameters
		System.err.println("Image width = " + image_width);
		System.err.println("Image height = " + image_height);
		
		// execute filter
		ImagePlus result = exec(image_width, image_height, ResultsTable.getResultsTable()); // NOTE: use system Results Table
		
		// show image
		if(null != result)
		{
			result.show();
		}
	}
	
	// ////////////////////////////////////////////////////////////////////////
	
	public ImagePlus exec(int image_width, int image_height, ResultsTable fluorophores)
	{
		// TODO: check arguments
		return convolve(image_width, image_height, fluorophores);
	}
	
	// ////////////////////////////////////////////////////////////////////////
	
	public static ImagePlus convolve(int image_width, int image_height, ResultsTable fluorophores)
	{
		ImageProcessor ip = new FloatProcessor(image_width, image_height);
		GPUBase gpu = null;
		try
		{
			gpu = new GPUBase(false, false, false, false); // no double precision, no automatic mode, no profiling and no debugging mode enabled
		}
		catch(CLException cle)
		{
			System.err.println("Could not set up OpenCL");
			return null;
		}
		
		// continue only if gpu was constructed successfully
		if(gpu != null)
		{
			// open OpenCL kernel file
			BufferedReader opencl_kernel_reader = null;
			try
			{
				InputStream resource_stream = gpu.getClass().getResourceAsStream("/convolution.cl");
				if(resource_stream == null)
				{
					IJ.error("Could not load OpenCL kernel as resource from JAR file");
					return null;
				}
				opencl_kernel_reader = new BufferedReader(new InputStreamReader(resource_stream));
			}
			catch(Exception e)
			{
				IJ.error("Could not load OpenCL kernel");
				return null;
			}
			
			// load contents of OpenCL kernel file
			String opencl_kernel_program = "";
			String line = null;
			try
			{
				while((line = opencl_kernel_reader.readLine()) != null)
				{
					// add line to program
					opencl_kernel_program += line + '\n';
				}
			}
			catch(IOException e)
			{
				// early exit
				IJ.error("Could not load contents of OpenCL kernel file");
				return null;
			}
			
			// close file
			try
			{
				opencl_kernel_reader.close();
			}
			catch(IOException e)
			{
				// ignore, do nothing
			}
			
			// load OpenCL kernel program
			boolean compile_success = gpu.loadProgramFromString(opencl_kernel_program);
			if(!compile_success)
			{
				IJ.error("Could not load program file into OpenCL");
				return null;
			}
		}
		
		GPUConvolve.run(gpu, fluorophores, ip);
		ip.resetMinAndMax();
		return new ImagePlus("Convolved fluorophores result", ip);
	}
}
