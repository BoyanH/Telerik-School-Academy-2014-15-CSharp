using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask1 {
    class AppStart {

        static int[,] CreateMatrixTypeA(int n) {

            int[,] matrix = new int[n, n];
            int counter = 1;

            for (int col = 0; col < n; col++) {

                for (int row = 0; row < n; row++) {

                    matrix[row, col] = counter;
                    ++counter;
                }
            }

            return matrix;
        }

        static int[,] CreateMatrixTypeB(int n) {

            int[,] matrix = new int[n, n];
            int counter = 1;

            for (int col = 0; col < n; col++) {

                for (int row = 0; row < n; row++) {

                    int opoRow = n - 1 - row;

                    if (col % 2 != 0) {
                        matrix[opoRow, col] = counter;
                    }
                    else {
                    
                        matrix[row, col] = counter;
                    }

                    ++counter;
                }
            }

            return matrix;
        }

        static int[,] CreateMatrixTypeC(int n) {

            int[,] matrix = new int[n, n];
            int counter = 1;

            for (int row = n; row >= 0; row--) {

                for (int col = 0; col <= n - row-1; col++) {

                    matrix[row + col, col] = counter;
                    ++counter;
                }
            }

            for (int col = 1; col < n; col++) {

                for (int row = 0; row < n - col; row++) {

                    matrix[row, col + row] = counter;
                    ++counter;
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix) {

            for (int row = 0; row < matrix.GetLength(0); row++) {

                for (int col = 0; col < matrix.GetLength(1); col++) {
                    Console.Write("{0:000} ", matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        static void Main() {

            int n;

            Console.WriteLine("Enter size of matrix N to be amazed! \n");

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

                Console.WriteLine("Invalid Integer!");
                Console.Write("\nN: ");
            }

            Console.WriteLine();
            PrintMatrix(CreateMatrixTypeA(n));
            Console.WriteLine();

            Console.WriteLine();
            PrintMatrix(CreateMatrixTypeB(n));
            Console.WriteLine();

            Console.WriteLine();
            PrintMatrix(CreateMatrixTypeC(n));
            Console.WriteLine();
            
        }
    }
}
