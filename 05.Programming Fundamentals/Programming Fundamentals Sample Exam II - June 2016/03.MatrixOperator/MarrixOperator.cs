using System;

namespace _03.MatrixOperator
{
    using System.Collections.Generic;
    using System.Linq;

    public class MarrixOperator
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();

            for (int row = 0; row < rows; row++) matrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] == "end") break;


                if (input[0] == "remove")
                {

                    int index = int.Parse(input[3]);

                    if (input[1] == "positive")
                    {
                        if (input[2] == "row")
                        {
                            matrix[index].RemoveAll(x => x >= 0);
                        }
                        if (input[2] == "col")
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                if (index < matrix[i].Count) if (matrix[i][index] >= 0) matrix[i].RemoveAt(index);
                            }
                        }
                    }

                    if (input[1] == "negative")
                    {
                        if (input[2] == "row")
                        {
                            matrix[index].RemoveAll(x => x < 0);
                        }
                        if (input[2] == "col")
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                if (index < matrix[i].Count) if (matrix[i][index] < 0) matrix[i].RemoveAt(index);
                            }
                        }
                    }
                    if (input[1] == "odd")
                    {
                        if (input[2] == "row")
                        {
                            matrix[index].RemoveAll(x => x % 2 != 0);
                        }
                        if (input[2] == "col")
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                if (index < matrix[i].Count) if (matrix[i][index] % 2 != 0) matrix[i].RemoveAt(index);
                            }
                        }
                    }
                    if (input[1] == "even")
                    {
                        if (input[2] == "row")
                        {
                            matrix[index].RemoveAll(x => x % 2 == 0);
                        }
                        if (input[2] == "col")
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                if (index < matrix[i].Count) if (matrix[i][index] % 2 == 0) matrix[i].RemoveAt(index);
                            }
                        }
                    }
                }
                if (input[0] == "swap")
                {
                    int firstRow = int.Parse(input[1]);
                    int secondRow = int.Parse(input[2]);
                    List<int> tempArr = matrix[firstRow];
                    matrix[firstRow] = matrix[secondRow];
                    matrix[secondRow] = tempArr;
                }

                if (input[0] == "insert")
                {
                    int row = int.Parse(input[1]);
                    int element = int.Parse(input[2]);
                    matrix[row].Insert(0, element);
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}