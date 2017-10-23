namespace _03.Game.Core.Factories
{
    using System;
    using System.Collections.Generic;

    public class BombFactory
    {
        public const int DefaultBoardRows = 5;

        public const int DefaultBoardColumns = 10;

        public const int DefaultBombsCount = 15;

        public static char[,] PutBombsOnField()
        {
            char[,] playground = new char[DefaultBoardRows, DefaultBoardColumns];
            for (int row = 0; row < DefaultBoardRows; row++)
            {
                for (int col = 0; col < DefaultBoardColumns; col++)
                {
                    playground[row, col] = '-';
                }
            }

            //Puts random and unique numbers in list as bombs 
            List<int> bombs = new List<int>();
            while (bombs.Count < DefaultBombsCount)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!bombs.Contains(number))
                {
                    bombs.Add(number);
                }
            }

            //Fill the board with bombs
            foreach (int bomb in bombs)
            {
                int col = bomb / DefaultBoardColumns;
                int row = bomb % DefaultBoardColumns;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = DefaultBoardColumns;
                }
                else
                {
                    row++;
                }

                playground[col, row - 1] = '*';
            }

            return playground;
        }
    }
}