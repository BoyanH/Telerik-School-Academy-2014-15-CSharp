using System;

namespace Methods
{
    public class Line
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }

        public Line(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
        }

        public static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            return (y1 == y2);
        }

        public static bool IsHorizontal(Line line)
        {
            return (line.Y1 == line.Y2);
        }

        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            return (x1 == x2);
        }

        public static bool IsVertical(Line line)
        {
            return (line.X1 == line.X2);
        }

        public static double CalcLength(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

            return distance;
        }

        public static double CalcLength(Line line)
        {
            double distance = Math.Sqrt(Math.Pow((line.X2 - line.X1), 2) + Math.Pow((line.Y2 - line.Y1), 2));

            return distance;
        }
    }
}
