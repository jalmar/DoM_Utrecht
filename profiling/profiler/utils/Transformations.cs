using System;

namespace profiler.utils
{
    public enum Transformation
    {
        Rigid = 0,
        Affine = 1
    }
    class Transformations
    {
        public static float[] GetTransformation(Transformation transformation, int imageDimensionX, int imageDimensionY, int imageDimensionZ, float dx, float dy, float dz)
        {
            if (transformation == Transformation.Rigid)
                throw new NotImplementedException();

            if (transformation == Transformation.Affine)
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
