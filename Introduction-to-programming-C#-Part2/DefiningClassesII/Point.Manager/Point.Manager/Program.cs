using System;

namespace Point.Manager
{
    public class PointTester
    {
        public static void Main()
        {
            Point3D p = new Point3D(2, 2, 1);
            Point3D q = new Point3D(5, 3, -2);
            Console.WriteLine(p.ToString());
            Console.WriteLine(Distance.Calculate(p ,q));

            Path path = new Path(new Point3D[] { p, q });
            Console.WriteLine("Created a new Path with 2 points: {0}", path.ToString());

            PathStorage.WriteToExternalPath(path, "../../pathDB.txt");
            Console.WriteLine("Just saved it to pathDB.txt");
            Console.WriteLine("Now reading from pathDB.txt");
            Path samePath = PathStorage.ReadExternalPath("../../pathDB.txt");
            Console.WriteLine("Saved path is: {0}", samePath.ToString());
        }
    }
}
