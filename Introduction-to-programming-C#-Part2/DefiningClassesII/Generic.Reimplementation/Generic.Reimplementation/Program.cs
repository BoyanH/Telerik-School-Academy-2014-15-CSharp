using System;

namespace Generic.Reimplementation
{
    public class MyGenericListTest
    {
        public static void Main()
        {
            //LIST TASK
            var intGL = new GenericList<int>(5);
            intGL.Add(1);
            intGL.Add(2);
            intGL.Add(3);
            intGL.Add(5);
            intGL.AddAt(4, 3);

            Console.WriteLine("Created a list of integers: {0}", intGL.ToString());
            Console.WriteLine("Getting the element with index 2 using [2]: {0}", intGL[2]);
            Console.WriteLine("Setting the second element to 21314 using [2]");
            intGL[2] = 21314;
            Console.WriteLine("List is: {0}", intGL);
            intGL.Remove(21314);
            Console.WriteLine("Removing element with value 21314, list is: {0}", intGL);
            intGL.Add(6);
            intGL.Add(9);
            Console.WriteLine("List after 2 more elements are added and length is doubled: {0}", intGL);
            Console.WriteLine("Min Element is: {0}", intGL.Min());
            Console.WriteLine("Max Element is: {0}", intGL.Max());

            Console.WriteLine(new string('-', 70));

            Console.WriteLine("Creating a list with a string");
            var stringGL = new GenericList<string>(5);
            stringGL.Add("asd");
            Console.WriteLine("List is: {0}", stringGL);
            Console.WriteLine("Removing \"asd\"");
            stringGL.Remove("asd");
            Console.WriteLine("List is: {0}", stringGL);

            Console.WriteLine(new string('-', 70));

            //MATRIX TASK
            var myMatrix = new Matrix<int>(12, 15);
            var secondMatrix = new Matrix<int>(15, 18);
            var thirdMatrix = new Matrix<int>(12, 15);

            for (int row = 0; row < myMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < myMatrix.GetLength(1); col++)
                {
                    myMatrix[row, col] = row * col;
                    thirdMatrix[row, col] = row - col;
                }
            }

            for (int row = 0; row < secondMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < secondMatrix.GetLength(1); col++)
                {
                    secondMatrix[row, col] = row + col;
                }
            }

            Console.WriteLine("The element in myMatrix[3, 10] is: {0}", myMatrix[3, 10]);
            var multiplicationMatrix = myMatrix * secondMatrix;
            Console.WriteLine("Element in matrix = myMatrix * secondMatrix; at position [4, 8] is: {0}",
                multiplicationMatrix[4, 8]);
            var subtractionMatrix = myMatrix - thirdMatrix;
            Console.WriteLine("Element in matrix = myMatrix - thirdMatrix; at position [4, 8] is: {0}",
                subtractionMatrix[4, 8]);

            Console.WriteLine(new string('-', 70));
            
            //VERSION ATTRIBUTE TASK
            Type type = typeof(Matrix<>);

            foreach (var attr in type.GetCustomAttributes(false))
            {
                if (attr is VersionAttribute)
                {
                    Console.WriteLine("This is version {0} of the {1} class.",
                        (attr as VersionAttribute).Version, typeof(Matrix<>).FullName);
                }
            }
        }
    }
}
