#ifndef INFO_H
#define INFO_H

#include <iostream>

#define CL_CHECK(_expr)                                                         \
   do {                                                                         \
     cl_int _err = _expr;                                                       \
     if (_err == CL_SUCCESS)                                                    \
       break;                                                                   \
     fprintf(stderr, "OpenCL Error: '%s' returned %d!\n", #_expr, (int)_err);   \
     abort();                                                                   \
         } while (0)

#define CL_CHECK_ERR(_expr)                                                     \
   ({                                                                           \
     cl_int _err = CL_INVALID_VALUE;                                            \
     typeof(_expr) _ret = _expr;                                                \
     if (_err != CL_SUCCESS) {                                                  \
       fprintf(stderr, "OpenCL Error: '%s' returned %d!\n", #_expr, (int)_err); \
       abort();                                                                 \
	 	      }                                                                 \
     _ret;                                                                      \
      })

class Info
{
public:
	static void	ListPlatformInfo(cl_platform_id platform_id){
		char buffer[10240];
		CL_CHECK(clGetPlatformInfo(platform_id, CL_PLATFORM_PROFILE, 10240, buffer, NULL));
		printf("  PROFILE = %s\n", buffer);
		CL_CHECK(clGetPlatformInfo(platform_id, CL_PLATFORM_VERSION, 10240, buffer, NULL));
		printf("  VERSION = %s\n", buffer);
		CL_CHECK(clGetPlatformInfo(platform_id, CL_PLATFORM_NAME, 10240, buffer, NULL));
		printf("  NAME = %s\n", buffer);
		CL_CHECK(clGetPlatformInfo(platform_id, CL_PLATFORM_VENDOR, 10240, buffer, NULL));
		printf("  VENDOR = %s\n", buffer);
		CL_CHECK(clGetPlatformInfo(platform_id, CL_PLATFORM_EXTENSIONS, 10240, buffer, NULL));
		printf("  EXTENSIONS = %s\n", buffer);
	}

	static void ListDeviceInfo(cl_device_id device_id)
	{
		char buffer[10240];
		cl_uint buf_uint;
		cl_ulong buf_ulong;
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_NAME, sizeof(buffer), buffer, NULL));
		printf("  DEVICE_NAME = %s\n", buffer);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_VENDOR, sizeof(buffer), buffer, NULL));
		printf("  DEVICE_VENDOR = %s\n", buffer);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_VERSION, sizeof(buffer), buffer, NULL));
		printf("  DEVICE_VERSION = %s\n", buffer);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DRIVER_VERSION, sizeof(buffer), buffer, NULL));
		printf("  DRIVER_VERSION = %s\n", buffer);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_MAX_COMPUTE_UNITS, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_MAX_COMPUTE_UNITS = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_MAX_WORK_GROUP_SIZE, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_MAX_WORK_GROUP_SIZE = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_MAX_CLOCK_FREQUENCY, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_MAX_CLOCK_FREQUENCY = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_GLOBAL_MEM_SIZE, sizeof(buf_ulong), &buf_ulong, NULL));
		printf("  DEVICE_GLOBAL_MEM_SIZE = %llu\n", (unsigned long long)buf_ulong);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_IMAGE2D_MAX_HEIGHT, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_IMAGE2D_MAX_HEIGHT = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_IMAGE2D_MAX_WIDTH, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_IMAGE2D_MAX_WIDTH = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_IMAGE3D_MAX_HEIGHT, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_IMAGE3D_MAX_HEIGHT = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_IMAGE3D_MAX_WIDTH, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_IMAGE3D_MAX_WIDTH = %u\n", (unsigned int)buf_uint);
		CL_CHECK(clGetDeviceInfo(device_id, CL_DEVICE_IMAGE3D_MAX_DEPTH, sizeof(buf_uint), &buf_uint, NULL));
		printf("  DEVICE_IMAGE3D_MAX_DEPTH = %u\n", (unsigned int)buf_uint);
	}
};

#endif // PROFILING_UI_H