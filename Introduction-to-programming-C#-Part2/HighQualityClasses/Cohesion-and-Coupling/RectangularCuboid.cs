using System;

namespace CohesionAndCoupling
{
    public class RectangularCuboid
    {
        private double width;
        private double height;
        private double depth;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                value.Validate("width");

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
                value.Validate("height");

                this.height = value;
            }
        }
        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                value.Validate("depth");

                this.depth = value;
            }
        }

        public double Volume
        {
            get
            {
                return Width * Height * Depth;
            }
        }

        public double DiagonalXYZ
        {
            get
            {
                return GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            }
        }

        public double DiagonalXY
        {
            get
            {
                return GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            }
        }

        public double DiagonalXZ
        {
            get
            {
                return GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            }
        }

        public double DiagonalYZ
        {
            get
            {
                return GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            }
        }

        public RectangularCuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }


        public static double GetDiagonalBetweenSides(double sideA, double sideB)
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, sideA, sideB);
            return distance;
        }
        
        public static double GetDiagonalBetweenSides(double sideA, double sideB, double sideC)
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, sideA, sideB, sideC);
            return distance;
        }

        public static double GetVolume(double width, double height, double depth)
        {
            return width * height * depth;
        }
    }
}
