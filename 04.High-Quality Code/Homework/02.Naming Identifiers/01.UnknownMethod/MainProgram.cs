namespace _01.UnknownMethod
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            double[,] firstArray = { { 1, 3 }, { 5, 7 } };

            double[,] secondArray = { { 4, 2 }, { 1, 5 } };

            double[,] multipliedArray = MultiplyMatrix(firstArray, secondArray);

            for (int row = 0; row < multipliedArray.GetLength(0); row++)
            {
                for (int col = 0; col < multipliedArray.GetLength(1); col++)
                {
                    Console.Write(multipliedArray[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplyMatrix(double[,] firstArray, double[,] secondArray)
        {
            if (firstArray.GetLength(1) != secondArray.GetLength(0))
            {
                throw new Exception("Number of cols on the first array must be equal to the rows of the second array");
            }

            int length = firstArray.GetLength(1);
            double[,] resultArray = new double[firstArray.GetLength(0), secondArray.GetLength(1)];

            for (int row = 0; row < resultArray.GetLength(0); row++)
            {
                for (int col = 0; col < resultArray.GetLength(1); col++)
                {
                    for (int i = 0; i < length; i++)
                    {
                        resultArray[row, col] += firstArray[row, i] * secondArray[i, col];
                    }
                }
            }

            return resultArray;
        }
    }
}