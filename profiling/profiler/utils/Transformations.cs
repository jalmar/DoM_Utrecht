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
        public static float[] GetTransformation(Transformation transformation, int imageDimensionX, int imageDimensionY, int imageDimensionZ)
        {
            float dx = 0;
            float dy = 0;
            float dz = 0;

            if (transformation == Transformation.Rigid)
                throw new NotImplementedException();

            if (transformation == Transformation.Affine)
            {
                return new float[]
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
