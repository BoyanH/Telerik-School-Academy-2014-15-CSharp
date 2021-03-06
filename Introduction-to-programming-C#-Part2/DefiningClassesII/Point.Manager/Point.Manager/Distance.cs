﻿using System;

namespace Point.Manager
{
    public static class Distance
    {
        public static double Calculate(Point3D p, Point3D q)
        {
            return Math.Sqrt(Math.Pow(p.X - q.X, 2) + Math.Pow(p.Y - q.Y, 2) + Math.Pow(p.Z - q.Z, 2));
        }
    }
}
