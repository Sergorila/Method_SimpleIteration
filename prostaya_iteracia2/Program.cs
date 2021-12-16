using System;
namespace prostaya_iteracia2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix = CreateSLAU(8, 9);
            ShowIterationMethod(matrix);
        }

        public static double[,] CreateSLAU(int v, int n)
        {
            double[,] matrix = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == i)
                    {
                        matrix[i, j] = v + i;
                    }
                    else
                    {
                        matrix[i, j] = (v + i) * Math.Pow(10, -2);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, n] += matrix[i, j] * matrix[j, j];
                }
            }
            return matrix;
        }
        public static void Show(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {

                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.Write("|\t");
                Console.WriteLine($"{matrix[i, matrix.GetLength(0)]}");

            }
            Console.WriteLine();
        }
        public static double[] SimpleIterat(double[,] matrix, int e)
        {
            int n = matrix.GetLength(0);
            double[,] tempMatrix = new double[n, n + 1];
            double eps = double.MaxValue;
            double[] result = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        tempMatrix[i, j] = -matrix[i, j] / matrix[i, i];
                    }
                }
                tempMatrix[i, n] = matrix[i, n] / matrix[i, i];
                result[i] = tempMatrix[i, n];
            }
            while (Math.Round(eps, e) != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    double temp = 0;
                    for (int j = 0; j < n; j++)
                    {
                        temp += tempMatrix[i, j] * result[j];
                    }
                    temp += tempMatrix[i, n];
                    if (Math.Abs(temp - result[i]) < eps)
                    {
                        eps = Math.Abs(temp - result[i]);
                    }
                    result[i] = temp;
                }
            }
            return result;
        }
        public static void ShowIterationMethod(double[,] matrix)
        {

            Console.WriteLine("Вариант 8:");
            Show(matrix);

            var res = SimpleIterat(matrix, 10);

            Console.WriteLine("\nX:");

            foreach (var i in res)
            {
                Console.Write($"{Math.Round(i, 2)} ");
            }
            Console.WriteLine();
        }
    }
}
    

