using System;

namespace Point.Manager
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        private static readonly Point3D startPoint = new Point3D(0, 0, 0);
        private static char separator = '/';

        public Point3D StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D ParsePoint(string point)
        {
            string[] pointCoords = point.Split('/');

            return new Point3D(Convert.ToDouble(pointCoords[0]), Convert.ToDouble(pointCoords[1]), Convert.ToDouble(pointCoords[2]));
        }

        public override string ToString()
        {
            return string.Format("{1}{0}{2}{0}{3}", separator, this.X, this.Y, this.Z);
        }
    }
}
