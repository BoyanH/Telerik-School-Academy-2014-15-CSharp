using System;
using System.Collections.Generic;

namespace Point.Manager
{
    class Path
    {
        private static string separator = ";";
        private List<Point3D> pointsList = new List<Point3D>();

        public List<Point3D> PointsList
        {
            get
            {
                return pointsList;
            }
        }

        public Path(params Point3D[] points)
        {
            this.AddPoint(points);
        }

        public void AddPoint(params Point3D[] newPoints)
        {
            foreach (var point in newPoints)
            {
                pointsList.Add(point);
            }
        }

        public void RemovePoint(Point3D newPoint)
        {
            pointsList.Remove(newPoint);
        }

        public static Path ParsePath(string path)
        {
            string[] pointsStringified = path.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Point3D[] pointsInPath = new Point3D[pointsStringified.Length];

            for (int point = 0; point < pointsStringified.Length; point++)
            {
                pointsInPath[point] = Point3D.ParsePoint(pointsStringified[point]);
            }

            return new Path(pointsInPath);
        }

        public static Path operator +(Path p1, Path p2)
        {

            Point3D[] totalPoints = new Point3D[p1.PointsList.Count + p2.PointsList.Count];

            for (int i = 0; i < p1.PointsList.Count; i++)
			{
			    totalPoints[i] = p1.PointsList[i];
			}

            for (int k = 0; k < p2.PointsList.Count; k++)
			{
			    totalPoints[p1.PointsList.Count - 1 + k] = p2.PointsList[k];
			}

            return new Path(totalPoints);
        }

        public override string ToString()
        {
            return String.Join(separator, pointsList);
        }
    }
}
