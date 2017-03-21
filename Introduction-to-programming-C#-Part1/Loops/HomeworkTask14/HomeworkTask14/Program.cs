using System;

namespace HomeworkTask14 {
    class AppStart {

        static int[,] CreateMatrixAsArray(int rowColNumber) {

            int positionInSpiral = 1,
                maxRowNumber = rowColNumber,
                maxColNumber = rowColNumber,
                rowNumber = 0,
                colNumber = 0;

            int[,] matrixArray = new int[rowColNumber, rowColNumber];

            while (positionInSpiral <= rowColNumber * rowColNumber) {

                for (int i = colNumber; i < maxColNumber; i++) {

                    matrixArray[rowNumber, i] = positionInSpiral;
                    ++positionInSpiral;
                }

                ++rowNumber;

                for (int j = rowNumber; j < maxRowNumber; j++) {

                    matrixArray[j, maxColNumber-1] = positionInSpiral;
                    ++positionInSpiral;
                }
                --maxColNumber;

                for (int z = maxColNumber-1; z > colNumber; z--) {

                    matrixArray[maxRowNumber-1, z] = positionInSpiral;
                    ++positionInSpiral;
                }
               --maxRowNumber;

                for (int k = maxRowNumber; k >= rowNumber; k--) {

                    matrixArray[k, colNumber] = positionInSpiral;
                    ++positionInSpiral;
                }
                ++colNumber;
            }

            return matrixArray;
        }

        static void PrintMatrixArray(int[,] matrixArray) {

            Console.WriteLine();

            for (int row = 0; row < matrixArray.GetLength(0); row++) {

                for (int col = 0; col < matrixArray.GetLength(1); col++) {

                    Console.Write("{0:000} ", matrixArray[row, col]);
                }
                Console.WriteLine();

            }

            Console.WriteLine();
        }

        static void Main() {

            int number;

            Console.WriteLine("Enter the an integer for the number of rows/cols of the fancy spiral-thingy you are going to see!\n");

            Console.Write("Rows/Cols: ");
            bool numberParsed = int.TryParse(Console.ReadLine(), out number);

            if (numberParsed && number < 20) {

                var array = CreateMatrixAsArray(number);
                PrintMatrixArray(array);
            }
            else {

                Console.WriteLine("Invalid Integer! Must be an integer <20!");
            }
 
        }
    }
}
