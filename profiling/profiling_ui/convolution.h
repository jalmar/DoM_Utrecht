#include "CL\cl.h"

#pragma once
class convolution
{
public:
	convolution(cl_platform_id selected_ocl_platform_id, cl_device_id selected_ocl_device_id, float *);
	~convolution();
};

