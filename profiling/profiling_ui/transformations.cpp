#include "transformations.h"


Transformations::Transformations()
{
}


Transformations::~Transformations()
{
}

const char* Transformations::EnumToString(TransformationType t)
{
	switch (t)
	{
	case TransformationType::Rigid:
		return "Rigid";
	case TransformationType::Affine:
		return "Affine";
	}
}

void Transformations::GetTransformation(TransformationType transformationType, float imageDimensionX, float imageDimensionY, float imageDimensionZ, float dx, float dy, float dz, float *transformation)
{
	if (transformationType == TransformationType::Rigid)
		throw "error";

	if (transformationType == TransformationType::Affine)
	{
		*transformation = imageDimensionX;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = dx;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = imageDimensionY;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = dy;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = imageDimensionZ;
		*++transformation;
		*transformation = dz;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = 0;
		*++transformation;
		*transformation = 1.0;
	}
}