// profiling.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

#include "tiffreader.h"
//#include <tiffio.h>

#include <CL/cl.h>
//#include <CL/cl_gl.h>
//#include <CL/cl_platform.h>
//#include <CL/clext.h>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	cl_platform_id test;
	cl_uint num = 0;
	cl_uint ok = 1;
	//clGetPlatformIDs(ok, &test, &num);
	

	cout << "test" << std::endl;
	cout << "Number of OpenCL platforms found: " << num << std::endl;

	return 0;
}
