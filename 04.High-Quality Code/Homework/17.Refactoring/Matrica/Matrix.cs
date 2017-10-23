namespace GameFifteen
{
    using System;
    using System.Text;

    public class Matrix
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number in range [0...100] ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int value = 1;
            int startRow = 0;
            int startCol = 0;
            int startDirectionX = 1;
            int startDirectionY = 1;

            while (true)
            {
                matrix[startRow, startCol] = value;

                if (!CheckMatrixIsInRange(matrix, startRow, startCol))
                {
                    break;
                }

                RotateMatrix(ref startRow, n, matrix, ref startDirectionX, ref startCol, ref startDirectionY, ref value);
            }
            Console.WriteLine(PrintMatrix(n, matrix));
        }

        public static void ChangeDirection(ref int startDirectionX, ref int startDirectionY)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };

            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int previousIndex = 0;

            for (int index = 0; index < 8; index++)
            {
                if (directionX[index] == startDirectionX && directionY[index] == startDirectionY)
                {
                    previousIndex = index;
                    break;
                }
            }

            if (previousIndex == 7)
            {
                startDirectionX = directionX[0];
                startDirectionY = directionY[0];
                return;
            }

            startDirectionX = directionX[previousIndex + 1];
            startDirectionY = directionY[previousIndex + 1];
        }

        public static bool CheckMatrixIsInRange(int[,] matrix, int startRow, int startCol)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };

            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (startRow + directionX[i] >= matrix.GetLength(0) || startRow + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (startCol + directionY[i] >= matrix.GetLength(0) || startCol + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[startRow + directionX[i], startCol + directionY[i]] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static void RotateMatrix(
            ref int startRow,
            int n,
            int[,] matrix,
            ref int startDirectionX,
            ref int startCol,
            ref int startDirectionY,
            ref int value)
        {
            while (startRow + startDirectionX >= n || startRow + startDirectionX < 0 || startCol + startDirectionY >= n
                   || startCol + startDirectionY < 0
                   || matrix[startRow + startDirectionX, startCol + startDirectionY] != 0)
            {
                ChangeDirection(ref startDirectionX, ref startDirectionY);
            }

            startRow += startDirectionX;
            startCol += startDirectionY;
            value++;
        }

        public static string PrintMatrix(int n, int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    sb.Append($" {matrix[row, col]}");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}