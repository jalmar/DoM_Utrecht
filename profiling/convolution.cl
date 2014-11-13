//#define ENABLE_FP64

// enabling extensions
//#if defined(ENABLE_FP64)
//	#if defined(cl_khr_fp64)
//		#pragma OPENCL EXTENSION cl_khr_fp64 : enable
//	#elif defined(cl_amd_fp64)
//		#pragma OPENCL EXTENSION cl_amd_fp64 : enable
//	#else
//		#error "Double precision floating point not supported by OpenCL implementation"
//	#endif
//#endif
//
//#pragma OPENCL EXTENSION cl_khr_global_int32_base_atomics : enable
//#pragma OPENCL EXTENSION cl_khr_global_int32_extended_atomics : enable
//#pragma OPENCL EXTENSION cl_khr_local_int32_base_atomics : enable
//#pragma OPENCL EXTENSION cl_khr_local_int32_extended_atomics : enable
//
//#if defined(ENABLE_FP64)
//	#pragma OPENCL EXTENSION cl_khr_int64_base_atomics : enable
//	#pragma OPENCL EXTENSION cl_khr_int64_extended_atomics : enable
//#endif

// *******************************************************************

// floating-point data type; depends on support from device
//#if defined(ENABLE_FP64)
//	typedef double scalar_t;
//#else
//	typedef float scalar_t;
//#endif

union {
	float  element[4];
	float4 elements;
} fluorophore_t;

typedef float scalar_t;
typedef unsigned short pixel_t;

// *******************************************************************

__kernel void transform_fluorophores (
					__global fluorophore_t* const fluorophores,
					__constant const scalar_t* const transformation_matrix)
{
	// get fluorophore data and create new empty fluorophore for result
	__private const int global_id = get_global_id(0);
	__private fluorophore_t original = fluorophores[global_id];
	__private fluorophore_t transformed = (0.0f);
	
	// retain parameter value and set homogenous coordinate value
	__private const scalar_t param = original.element[3];
	original.element[3] = 1.0f;
	
	// apply transformation
	for (__private int r = 0; r < 4; ++r)
	{
		for (__private int c = 0; c < 4; ++c)
		{
			transformed.element[r] += transformation_matrix[mad(r,4,c)] * original.element[c];
		}
	}
	
	// restore parameter value and write result back
	transformed.element[3] = param;
	fluorophores[global_id] = transformed;
}

// *******************************************************************

// 1D kernel
// Global size image_width * image_height
// Work group size (multiple of 16)
__kernel void convolve_fluorophores (
					__global pixel_t* const image,
					__private const int image_width,
					__private const int image_height,
					__global const fluorophore_t* const fluorophores,
					__private const int fluorophore_count)
{
	// thread parameters
	__private const int global_id = get_global_id(0);
	__private const int local_id = get_local_id(0);
	__private const int batch_size = get_local_size(0);
	
	// OPTIM: keep pixel value cached in private memory
	__private scalar_t pixel_value = 0.0f;
	
	// OPTIM: allocate local memory buffer for fluorophore
	__local fluorophore_t* local_fluorophores[batch_size];
	
	// loop through all fluorophores (in batches)
	for (__private int k = 0; k < fluorophore_count; k += batch_size)
	{
		// check number of fluorophores left (last part may be partial batch)
		// ALTERNATIVE: batch_size = select(fluorophore_count - k, batch_size, k + batch_size >= fluorophore_count);
		if (k + batch_size >= fluorophore_count)
		{
			batch_size = fluorophore_count - k; // last remainder
		}
		
		// transfer fluorophore data to local memory
		if (k + local_id < fluorophore_count)
		{
			local_fluorophores[local_id] = fluorophores[k + local_id];
		}
		
		// barrier on local memory to ensure all threads are finished writing to local memory buffer before the next step is executed
		barrier(CLK_LOCAL_MEM_FENCE);
		
		// loop through all locally stored fluorophores
		for (__private int i = 0; i < batch_size; ++i)
		{
			// calculate effect of fluorophore on pixel
			pixel_value += point_spread_function();
		}
		
		// barrier on local memory to ensure all threads are finished reading from local memory buffer before the next batch is loaded into memory
		barrier(CLK_LOCAL_MEM_FENCE);
	}
	
	// store pixel value in image
	image[global_id] = pixel_value;
}

// *******************************************************************

scalar_t point_spread_function()
{
	return 1.0f;
}