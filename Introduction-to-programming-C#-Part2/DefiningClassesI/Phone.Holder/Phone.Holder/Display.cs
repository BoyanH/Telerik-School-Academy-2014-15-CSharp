using System;

namespace Phone.Handler
{
    public class Display
    {
        private readonly double size; //in inches
        private readonly int numberOfColors;

        public double Size
        {
            get
            {
                return size;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return numberOfColors;
            }
        }

        public Display()
        {

        }
        public Display(double size)
        {
            this.size = size;
        }
        public Display(double size, int numberOfColors)
            : this(size)
        {
            this.numberOfColors = numberOfColors;
        }
    }
}
