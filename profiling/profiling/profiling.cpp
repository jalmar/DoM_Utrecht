// profiling.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>

#include <CL/cl.h>
//#include <CL/cl_gl.h>
//#include <CL/cl_platform.h>
//#include <CL/clext.h>

int _tmain(int argc, _TCHAR* argv[])
{
	cl_platform_id test;
	cl_uint num;
	cl_uint ok = 1;
	clGetPlatformIDs(ok, &test, &num);

	std::cout << "test" << std::endl;
	std::cout << "Number of OpenCL platforms found: " << num << std::endl;

	return 0;
}

