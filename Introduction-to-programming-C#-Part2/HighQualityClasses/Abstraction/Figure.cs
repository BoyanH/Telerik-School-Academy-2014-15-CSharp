using System;

namespace Abstraction
{
    public abstract class Figure
    {
        public abstract double Perimeter { get; }
        public abstract double Area { get; }

        protected void NegativValueExceptionHelper(double value, string property)
        {
            if (!(value > 0))
            {
                throw new ArgumentOutOfRangeException(property, string.Format("{0} can't be negativ!", property));
            }
        }
    }
}
