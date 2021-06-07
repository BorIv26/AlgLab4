using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab4
{
    class Program
    {
        static void Main()
        {
            int size = 0;            
            Console.WriteLine("Enter the number of unknowns");
            int.TryParse(Console.ReadLine(), out size);
            var FirstM = new float[size, size];
            var SecondM = new float[size];
            Console.WriteLine("Enter first matrix members(int)");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var temp1 = i + 1;
                    var temp2 = j + 1;
                    Console.Write("a" + temp1 + temp2 + ": ");
                    float value;
                    if (!float.TryParse(Console.ReadLine(), out value))
                        throw new FormatException();
                    FirstM[i, j] = value;
                }
            }
            Console.WriteLine();
            Console.WriteLine("First matrix");
            Console.WriteLine();
            PrintMatrix(FirstM);
            var firstDeterm = Recursive.GetDeterminant(FirstM);
            Console.WriteLine("Determinant of first matrix = " + firstDeterm);
            Console.WriteLine();
            Console.WriteLine("Enter column B members (float, if it int, add \",0\". e.g.: 4,0)");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                var temp1 = i + 1;
                Console.Write("b" + temp1 + ": ");
                float value;
                if (!float.TryParse(Console.ReadLine(), out value))
                    throw new FormatException();
                SecondM[i] = value;
            }
            Console.WriteLine();
            if (firstDeterm == 0)
            {
                bool flag = false;
                for (int i = 0; i < size - 1; i++)
                {
                    flag = SecondM[i] / FirstM[i, 0] == SecondM[i + 1] / FirstM[i + 1, 0];
                    if (!flag) break;
                }
                if (flag)
                {
                    Console.WriteLine("Infinite Solution");
                    return;
                }
                else
                {
                    Console.WriteLine("No Solution");
                    return;
                }
            }
            var resultM = new float[size];
            for (int i = 0; i < size; i++)
            {
                var tempMtx = SelectColumn(FirstM, SecondM, i);
                PrintMatrix(tempMtx);
                var tempDeterm = Recursive.GetDeterminant(tempMtx);
                resultM[i] = tempDeterm / firstDeterm;
                Console.WriteLine("determinant = " + tempDeterm);

                Console.WriteLine();
            }
            Console.Write("Solution of a quadratic system of linear equations by Cramer's method:  ");
            Console.WriteLine(resultM[0] + " " + resultM[1] + " " + resultM[2]);
        }
        public static void PrintMatrix(float[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static float[,] SelectColumn(float[,] matrix, float[] column, int index)
        {
            var result = (float[,])matrix.Clone();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                result[i, index] = column[i];
            }
            return result;
        }
    }
}
