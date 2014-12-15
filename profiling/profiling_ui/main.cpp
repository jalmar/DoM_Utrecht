#include "profiling_ui.h"
#include <QtWidgets/QApplication>

#include <iostream>

//#ifdef __APPLE__
//#include <OpenCL/opencl.h>
//#else
//#include <CL/cl.h>
//#endif

using namespace std;

int main(int argc, char *argv[])
{
	QApplication a(argc, argv);
	profiling_ui w;
	w.show();

//	cl_platform_id test;
//	cl_uint num = 0;
//	cl_uint ok = 1;
//	clGetPlatformIDs(ok, &test, &num);
//	
//	clGetContextInfo(NULL, NULL, NULL, 0, 0);
//
//	cout << "test" << std::endl;
//	cout << "Number of OpenCL platforms found: " << num << std::endl;

	return a.exec();
}
