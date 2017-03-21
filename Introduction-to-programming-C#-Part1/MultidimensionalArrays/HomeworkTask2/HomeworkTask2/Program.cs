using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask2 {
    class AppStart {

        static int[] GetMaxValue(int[,] matrix) {

            int maxSum = int.MinValue,
                startRow = 0,
                startCol = 0,
                rows = matrix.GetLength(0),
                cols = matrix.GetLength(1);


            for (int row = 0; row < rows - 2; row++) {
                for (int col = 0; col < cols - 2; col++) {
                    int currentSum = 0;
                    for (int i = row; i <= row + 2; i++) {
                        for (int j = col; j <= col + 2; j++) {
                            currentSum += matrix[i, j];
                        }
                    }
                    if (currentSum > maxSum) {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            return new int[] {maxSum, startRow, startCol};
        }

        static void PrintMatrix(int[,] matrix) {

            for (int row = 0; row < matrix.GetLength(0); row++) {

                for (int col = 0; col < matrix.GetLength(1); col++) {

                    Console.Write("{0:000} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void PrintSpecialMatrix(int[,] matrix, int row, int col) {
            
            Console.WriteLine("\nThe 3x3 matrix with the maximal sum is:");
            
            for (int i = row; i <= row + 2; i++) {
                for (int j = col; j <= col + 2; j++) {
                    Console.Write("{0:000} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main() {

            int n, counter = 1;

            Console.Write("N: ");
            while(!int.TryParse(Console.ReadLine(), out n)) {
            
                Console.WriteLine("Invalid Integer!");
                Console.WriteLine("\nN: ");
            }

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++) {

                for (int col = 0; col < n; col++) {

                    matrix[row, col] = counter;
                    ++counter;
                }
            }

            PrintMatrix(matrix);

            int specialRow = GetMaxValue(matrix)[1],
                specialCol = GetMaxValue(matrix)[2];

            PrintSpecialMatrix(matrix, specialRow, specialCol);
        }
    }
}
