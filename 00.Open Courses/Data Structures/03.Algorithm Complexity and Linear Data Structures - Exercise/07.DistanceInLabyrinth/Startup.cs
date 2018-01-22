namespace _07.DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static readonly int size = int.Parse(Console.ReadLine());
        private static readonly string[,] labyrinth = new string[size, size];
        private static Cell startingPosition;
        private static readonly Queue<Cell> visitedCells = new Queue<Cell>();

        public static void Main()
        {
            GetLabyrinthParams();

            visitedCells.Enqueue(startingPosition);

            //BFS
            while (visitedCells.Count > 0)
            {
                var currentCell = visitedCells.Dequeue();

                FindAvailableSteps(currentCell);
            }

            Print();
        }

        private static void FindAvailableSteps(Cell currentCell)
        {
            var row = currentCell.Row;
            var col = currentCell.Col;
            var value = currentCell.Value + 1;

            //Check available steps and mark them with their sequence
            if (row + 1 < size && labyrinth[row + 1, col] == "0")
            {
                visitedCells.Enqueue(new Cell(row + 1, col, value));
                labyrinth[row + 1, col] = value.ToString();
            }
            if (row - 1 >= 0 && labyrinth[row - 1, col] == "0")
            {
                visitedCells.Enqueue(new Cell(row - 1, col, value));
                labyrinth[row - 1, col] = value.ToString();
            }
            if (col + 1 < size && labyrinth[row, col + 1] == "0")
            {
                visitedCells.Enqueue(new Cell(row, col + 1, value));
                labyrinth[row, col + 1] = value.ToString();
            }
            if (col - 1 >= 0 && labyrinth[row, col - 1] == "0")
            {
                visitedCells.Enqueue(new Cell(row, col - 1, value));
                labyrinth[row, col - 1] = value.ToString();
            }
        }

        //Get matrix from the console and find starting position
        private static void GetLabyrinthParams()
        {
            for (int i = 0; i < size; i++)
            {
                var signs = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (signs != null)
                    {
                        labyrinth[i, j] = signs[j].ToString();
                    }
                    if (labyrinth[i, j] == "*")
                    {
                        startingPosition = new Cell(i, j, 0);
                    }
                }
            }

            if (startingPosition == null)
            {
                throw new AccessViolationException("Missing starting point!");
            }
        }

        private static void Print()
        {
            for (int i = 0; i < labyrinth.GetLongLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                {
                    Console.Write(labyrinth[i, j] == "0" ? "u" : labyrinth[i, j]);
                }

                Console.WriteLine();
            }
        }

        private class Cell
        {
            public int Row { get; }
            public int Col { get; }
            public int Value { get; }

            public Cell(int row, int col, int value)
            {
                this.Row = row;
                this.Col = col;
                this.Value = value;
            }
        }
    }
}