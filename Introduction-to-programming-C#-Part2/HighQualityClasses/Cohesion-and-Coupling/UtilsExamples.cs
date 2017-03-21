using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(File.GetExtension("example"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(File.GetExtension("example.pdf"));
            Console.WriteLine(File.GetExtension("example.new.pdf"));

            try
            {
                Console.WriteLine(File.GetNameWithoutExtension("example"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(File.GetNameWithoutExtension("example.pdf"));
            Console.WriteLine(File.GetNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var someContainer = new RectangularCuboid(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", someContainer.Volume);
            Console.WriteLine("Diagonal XYZ = {0:f2}", someContainer.DiagonalXYZ);
            Console.WriteLine("Diagonal XY = {0:f2}", someContainer.DiagonalXY);
            Console.WriteLine("Diagonal XZ = {0:f2}", someContainer.DiagonalXZ);
            Console.WriteLine("Diagonal YZ = {0:f2}", someContainer.DiagonalYZ);

            //a person who calls this geometry utils should be wise enought to know what
            //for example DiagonalXYZ means, therefore to call it as diagonal between sides with side lengths

            Console.WriteLine("Is my static clever GetDiagonalBetweenSides working correctly? You deside!");
            Console.WriteLine("{0} == {1} ? What do you think?",
                someContainer.DiagonalXYZ, RectangularCuboid.GetDiagonalBetweenSides(3, 4, 5));
        }
    }
}
