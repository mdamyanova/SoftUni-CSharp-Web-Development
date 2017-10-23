namespace _03.Game.Models
{
    public class Bomb
    {
        public static char CountBombs(char[,] bombs, int row, int column)
        {
            int bombsCounter = 0;
            int rows = bombs.GetLength(0);
            int columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, column] == '*')
                {
                    bombsCounter++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, column] == '*')
                {
                    bombsCounter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (bombs[row, column - 1] == '*')
                {
                    bombsCounter++;
                }
            }

            if (column + 1 < columns)
            {
                if (bombs[row, column + 1] == '*')
                {
                    bombsCounter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (bombs[row - 1, column - 1] == '*')
                {
                    bombsCounter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (bombs[row - 1, column + 1] == '*')
                {
                    bombsCounter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (bombs[row + 1, column - 1] == '*')
                {
                    bombsCounter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (bombs[row + 1, column + 1] == '*')
                {
                    bombsCounter++;
                }
            }

            return char.Parse(bombsCounter.ToString());
        }
    }
}