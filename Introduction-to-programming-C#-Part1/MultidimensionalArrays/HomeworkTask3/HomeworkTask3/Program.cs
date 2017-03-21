using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask3 {
    class AppStart {

        static bool[] GetLongestSequence(int[,] matrix) {

            int crntLine = 0, maxLine = 0;
            int crnRow = 0, maxRow = 0;
            int crntDiagonal = 0, maxDiagonal = 0;

            int[] diagonalStart, rowStart, lineStart, maxDiagonalStart, maxRowStart, maxLineStart;

            //col
            for (int row = 0; row < matrix.GetLength(0); row++) {

                for (int col = 1; col < matrix.GetLength(1); col++) {

                    if (matrix[row, col - 1] == matrix[row, col]) {

                        crntLine++;

                        if (crntLine > maxLine) {

                            maxLine = crntLine;
                            maxLineStart = lineStart;

                        }
                    }
                    else {

                        crntLine = 1;
                        lineStart = new int[] {row, col};
                    }
                }
            }
            //END COL

            //ROW
            for (int col = 0; col < matrix.GetLength(0); col++) {

                for (int row = 1; row < matrix.GetLength(1); row++) {

                    if (matrix[row-1, col] == matrix[row, col]) {

                        crntLine++;

                        if (crntLine > maxLine) {

                            maxRow = crnRow;
                            maxRowStart = rowStart;

                        }
                    }
                    else {

                        crnRow = 1;
                        rowStart = new int[] {row, col};
                    }
                }
            }
            //END ROW

            //DIAGONAL
            for (int row = matrix.GetLength(0); row >= 0; row--) {

                for (int col = 1; col <= matrix.GetLength(1) - row - 1; col++) {

                    if (matrix[row + col, col] == matrix[row + col - 1, col]) {
                        crntDiagonal++;

                        if (crntDiagonal > maxDiagonal) {

                            maxDiagonal = crntDiagonal;
                            maxDiagonalStart = diagonalStart;

                        }
                    }
                    else {

                        crntDiagonal = 1;
                        diagonalStart = new int[] {row, col};
                    }
                }
            }

            for (int col = 1; col < matrix.GetLength(1); col++) {

                for (int row = 1; row < matrix.GetLength(1) - col; row++) {

                    if (matrix[row, col + row] == matrix[row, col + row - 1]) {
                        crntDiagonal++;

                        if (crntDiagonal > maxDiagonal) {

                            maxDiagonal = crntDiagonal;
                            maxDiagonalStart = diagonalStart;

                        }
                    }
                    else {

                        crntDiagonal = 1;
                        diagonalStart = new int[] {row, col};
                    }
                    
                }
            }
            //END OF DIAGONAL

            bool[,] colorScheme = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            if (maxDiagonal > maxLine && maxDiagonal > maxRow) {
            

            }
            else if (maxLine > maxDiagonal && maxLine > maxRow) {

                for (int col = maxLineStart[1]; col < col + maxLine; col++) {
                    colorScheme[maxLineStart[0], col] = true;
                }
            }
            else if (maxRow > maxDiagonal && maxRow > maxLine) {

                for (int row = maxRowStart[0]; row < row + maxRow; row++) {
                    colorScheme[maxRowStart[1], row] = true;
                }
            }
        }

        static void PrintMatrix(int[,] matrix) {

            for (int row = 0; row < matrix.GetLength(0); row++) {

                for (int col = 0; col < matrix.GetLength(1); col++) {

                    Console.ForegroundColor = ConsoleColor.Black;
                    if(bool[row, col]) {
                    
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0:000} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void Main() {

            int n, counter = 1;

            Console.Write("N: ");
            while (!int.TryParse(Console.ReadLine(), out n)) {

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
