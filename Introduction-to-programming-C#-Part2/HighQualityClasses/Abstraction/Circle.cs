using System;

namespace Abstraction
{
    class Circle : Figure
    {

        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                base.NegativValueExceptionHelper(value, "radius"); //throw exception if value < 0

                this.radius = value;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public override double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
    }
}
