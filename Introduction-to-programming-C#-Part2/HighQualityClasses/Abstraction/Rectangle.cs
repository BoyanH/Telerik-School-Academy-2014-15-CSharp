using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                base.NegativValueExceptionHelper(value, "width"); //throw exception if value < 0

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                base.NegativValueExceptionHelper(value, "height"); //throw exception if value < 0

                this.height = value;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * (this.Width + this.Height);
            }
        }

        public override double Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
