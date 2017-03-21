using System;

namespace Generic.Reimplementation
{
    [Version("20.15")]
    class Matrix<T>
    {
        private T[,] elemMatrix;
        private int rows;
        private int cols;

        public T this[int row, int col]
        {
            get
            {
                if (elemMatrix.GetLength(0) <= row || elemMatrix.GetLength(1) <= col || row < 0 || col < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("Row must be between 0 and {0}; Col must be between 0 and {1}!",
                        rows, cols));
                }

                return this.elemMatrix[row, col];
            }
            set
            {
                if (elemMatrix.GetLength(0) <= row || elemMatrix.GetLength(1) <= col || row < 0 || col < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("Row must be between 0 and {0}; Col must be between 0 and {1}!",
                        rows, cols));
                }

                this.elemMatrix[row, col] = value;
            }
        }

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.elemMatrix = new T[rows, cols];
        }

        public int GetLength(int level)
        {
            return this.elemMatrix.GetLength(level);
        }

        private static Matrix<T> SubtractAddOrMultiply(Matrix<T> leftMatrix, Matrix<T> rightMatrix, int sign, bool isMultiply = false) //sign = +/- 1;
        {
            if ((leftMatrix.GetLength(0) != rightMatrix.GetLength(0) || leftMatrix.GetLength(1) != rightMatrix.GetLength(1)) && !isMultiply)
            {
                throw new Exception("Matrixes are not equallly sized!");
            }
            else if (isMultiply && leftMatrix.GetLength(1) != rightMatrix.GetLength(0))
            {
                throw new Exception("Matrixes can't be multiplied!");
            }

            int newRows = leftMatrix.GetLength(0) > rightMatrix.GetLength(0) ? leftMatrix.GetLength(0) : rightMatrix.GetLength(0);
            int newCols = leftMatrix.GetLength(1) > rightMatrix.GetLength(1) ? leftMatrix.GetLength(1) : rightMatrix.GetLength(1);

            Matrix<T> newMatrix = new Matrix<T>(newRows, newCols);

            for (int row = 0; row < leftMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < leftMatrix.GetLength(1); col++)
                {
                    if (isMultiply)
                    {
                        dynamic sum = 0;
                        for (int x = 0; x < leftMatrix.GetLength(1); x++)
                        {
                            sum = sum + (dynamic)leftMatrix[row, x] * (dynamic)rightMatrix[x, col];
                        }
                        newMatrix[row, col] = sum;
                    }
                    else
                    {
                        newMatrix[row, col] = (dynamic)leftMatrix[row, col] + sign * (dynamic)rightMatrix[row, col];
                    }
                }
            }

            return newMatrix;
        }

        public static Matrix<T> operator +(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return SubtractAddOrMultiply(leftMatrix, rightMatrix, 1);
        }

        public static Matrix<T> operator -(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return SubtractAddOrMultiply(leftMatrix, rightMatrix, -1);
        }

        public static Matrix<T> operator *(Matrix<T> leftMatrix, Matrix<T> rightMatrix)
        {
            return SubtractAddOrMultiply(leftMatrix, rightMatrix, 1, true);
        }
    }
}
