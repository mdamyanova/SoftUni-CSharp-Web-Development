namespace _03.Game.Core
{
    using System;
    using System.Collections.Generic;

    using _03.Game.Core.Factories;
    using _03.Game.Models;

    public class CommandManager
    {
        public static void ShowRanking(IList<Player> players)
        {
            Console.WriteLine(Environment.NewLine + "Points: ");

            //Check if there's any players
            if (players.Count > 0)
            {
                for (int index = 0; index < players.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", index + 1, players[index].Name, players[index].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There's no players" + Environment.NewLine);
            }
        }

        public static void RestartGame(char[,] playground, char[,] bombs, bool isDestroyed, bool isNewGame)
        {
            playground = PlaygroundFactory.CreatePlayground();
            bombs = BombFactory.PutBombsOnField();
            Playground.ShowThePlayground(playground);
        }
    }
}