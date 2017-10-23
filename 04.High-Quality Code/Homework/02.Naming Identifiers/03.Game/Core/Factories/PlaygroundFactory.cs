namespace _03.Game.Core.Factories
{
    public class PlaygroundFactory
    {
        public const int DefaultBoardRows = 5;

        public const int DefaultBoardColumns = 10;

        public static char[,] CreatePlayground()
        {
            int boardRows = DefaultBoardRows;
            int boardColumns = DefaultBoardColumns;

            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }
    }
}