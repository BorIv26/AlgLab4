using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab4
{
    class Recursive
    {
        public static float GetDeterminant(float[,] matrix)
        {
            //1x1 matrix det
            if (matrix.GetLength(0) == 1 && matrix.GetLength(1) == 1)
                return matrix[0, 0];
            //2x2 matrix det
            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2) 
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            float determ = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                determ += (int)Math.Pow(-1, i) * matrix[0, i] * GetDeterminant(GetMinor(matrix, 0, i));
            }
            return determ;
        }

        private static float[,] GetMinor(float[,] matrix, int row, int column)
        {
            var size = matrix.GetLength(0);
            var minor = new float[size - 1, size - 1];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != 0 && j != column)
                        minor[i < 0 ? i : i - 1, j < column ? j : j - 1] = matrix[i, j];                    
                }
            }
            return minor;        
        }        
    }
}
