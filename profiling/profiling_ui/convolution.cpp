#include "convolution.h"

#include <iostream>
#include <fstream>
#include "c_timer.h"
#include "CL\cl.h"
#include "helper.h"

using namespace std;

convolution::convolution(cl_platform_id selected_ocl_platform_id, cl_device_id selected_ocl_device_id, float *transformation)
{
	c_timer *timer = new c_timer();
	timer->Start();
	
	cout << "Computing..." << endl;
	cout << "Reading kernel..." << endl;

	ifstream kernelFile("E:\\Projects\\GitHub\\DoM_Utrecht-GPU\\profiling\\convolution.cl");

	// read kernelfile
	string kernelString((std::istreambuf_iterator<char>(kernelFile)), (std::istreambuf_iterator<char>()));
	
	cout << kernelString << "\n";
	
	cout << "Reading kernel... done" << endl;

	//TODO 
	
	cl_context_properties contextProperties[] = { CL_CONTEXT_PLATFORM, (cl_context_properties)selected_ocl_platform_id, 0 };
	
	cl_context _ocl_context = clCreateContext(contextProperties, 1, new cl_device_id[]{selected_ocl_device_id}, NULL, NULL, NULL);

	cl_command_queue_properties _cl_command_queue_properties = { false };

	cl_command_queue _cl_command_queue = clCreateCommandQueue(_ocl_context, selected_ocl_device_id, _cl_command_queue_properties, NULL);
	
	cl_program programma = cl_program();

	cl_int status = clGetProgramBuildInfo(programma, selected_ocl_device_id, CL_PROGRAM_BUILD_OPTIONS, NULL, NULL, NULL);

	cl_int error;
	size_t srcsize;

	/* Read the source kernel code in exmaple.cl as an array of char's */
	char src[8192];
	FILE *fil = fopen("E:\\Projects\\GitHub\\DoM_Utrecht-GPU\\profiling\\convolution.cl", "r");
	srcsize = fread(src, sizeof src, 1, fil);
	fclose(fil);

	char build_c[4096];

	const char *srcptr[] = { src };
	/* Submit the source code of the kernel to OpenCL, and create a program object with it */
	cl_program prog = clCreateProgramWithSource(_ocl_context, 1, srcptr, &srcsize, &error);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}

	const cl_device_id* device_id = &selected_ocl_device_id;

	/* Compile the kernel code (after this we could extract the compiled version) */
	
	error = clBuildProgram(prog, 0, NULL, NULL, NULL, NULL);//clBuildProgram(prog, 0, device_id, "", NULL, NULL);
	if (error != CL_SUCCESS) {
		printf("Error on buildProgram ");
		printf("\n Error number %d", error);
		fprintf(stdout, "\nRequestingInfo\n");
		clGetProgramBuildInfo(prog, selected_ocl_device_id, CL_PROGRAM_BUILD_STATUS, 4096, build_c, NULL);
		printf("Build build status for %s_program:\n%s\n", "example", build_c);
		clGetProgramBuildInfo(prog, selected_ocl_device_id, CL_PROGRAM_BUILD_OPTIONS, 4096, build_c, NULL);
		printf("Build build options for %s_program:\n%s\n", "example", build_c);
		clGetProgramBuildInfo(prog, selected_ocl_device_id, CL_PROGRAM_BUILD_LOG, 4096, build_c, NULL);
		printf("Build Log for %s_program:\n%s\n", "example", build_c);
	}

	//float *fluorophores = new float[1024]; // TEST // CsvData.ReadFluorophores(_sourceFilename);
	
	ifstream _sourceFilename("E:\\Projects\\GitHub\\DoM_Utrecht-GPU\\profiling\\data\\fluorophores_1k.csv");
	string csvFluorophore((std::istreambuf_iterator<char>(_sourceFilename)), (std::istreambuf_iterator<char>()));

	ReplaceStringInPlace(csvFluorophore, "\n", ",");

	vector<string> csvFluorophores = split(csvFluorophore, ',');

	stringstream ss;
	vector<double> csvFluorophoresFloat(csvFluorophores.size());
	for (size_t i = 0; i < csvFluorophores.size(); ++i)
	{
		csvFluorophoresFloat[i] = StringToNumber<float>(csvFluorophores[i]);
	}
	//string* fluorophores = &csvFluorophores[0];


	/* Create memory buffers in the Context where the desired Device is. These will be the pointer
	parameters on the kernel. */
	cl_mem fluorophoresCoords = clCreateBuffer(_ocl_context, CL_MEM_READ_WRITE, sizeof(csvFluorophoresFloat) * csvFluorophoresFloat.size(), NULL, &error);// ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadWrite, fluorophores.LongLength);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}
	cl_mem transformationMatrix = clCreateBuffer(_ocl_context, CL_MEM_READ_ONLY, sizeof(transformation) * 16, NULL, &error);// new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadOnly, selectedTransformation.LongLength);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}

	/* Create a kernel object with the compiled program */
	cl_kernel k_example = clCreateKernel(prog, "transform_fluorophores", &error);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}

	/* Set the kernel parameters */
	error = clSetKernelArg(k_example, 0, sizeof(fluorophoresCoords), &fluorophoresCoords);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}
	error = clSetKernelArg(k_example, 1, sizeof(transformationMatrix), &transformationMatrix);
	if (error != CL_SUCCESS) {
		printf("\n Error number %d", error);
	}


	cout << "Computing... done" << endl;
	timer->Stop();
	cout << timer->GetDuration() << endl;
}


convolution::~convolution()
{
}
