using AlgLab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab4
{
    class Redheffer
    {
        public static float[,] GetMatrix(int size)
        {
            var matrix = new float[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = ((j + 1) % (i + 1) == 0 || j == 0) ? 1 : 0;
                }
            }
            return matrix;
        }
        public static float GetMartensFunc(int size) => Recursive.GetDeterminant(GetMatrix(size));
    }
}
