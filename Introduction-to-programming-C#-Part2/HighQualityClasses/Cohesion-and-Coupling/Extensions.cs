using System;

namespace CohesionAndCoupling
{
    public static class Extensions
    {
        public static void Validate(this ValueType value, string property)
        {
            if ((double)value <= 0)
            {
                throw new ArgumentOutOfRangeException(property, string.Format("{0} can't be negativ!", property));
            }
        }
    }
}
