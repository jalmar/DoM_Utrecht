using System;

namespace profiler.utils
{
    public enum TransformationType
    {
        Rigid = 0,
        Affine = 1
    }
    class Transformations
    {
        public static float[] GetTransformation(TransformationType transformationType, float imageDimensionX, float imageDimensionY, float imageDimensionZ, float dx, float dy, float dz)
        {
            if (transformationType == TransformationType.Rigid)
                throw new NotImplementedException();

            if (transformationType == TransformationType.Affine)
            {
                return new[]
                {
                    imageDimensionX, 0,0, dx,
                    0,imageDimensionY,0, dy,
                    0,0,imageDimensionZ, dz,
                    0,0,0,1
                };
            }

            return null;
        }
    }
}
