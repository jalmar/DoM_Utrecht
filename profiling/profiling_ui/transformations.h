#ifndef TRANSFORMATIONS_H
#define TRANSFORMATIONS_H

enum TransformationType {
	Rigid = 0,
	Affine = 1
};

class Transformations
{
public:
	static void GetTransformation(TransformationType transformationType, float imageDimensionX, float imageDimensionY, float imageDimensionZ, float dx, float dy, float dz, float *transformation);
	static const char* Transformations::EnumToString(TransformationType t);
	Transformations();
	~Transformations();
};

#endif // TRANSFORMATIONS_H
