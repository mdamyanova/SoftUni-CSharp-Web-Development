namespace _03.Game.Core
{
    using System;
    using System.Collections.Generic;

    using _03.Game.Core.Factories;
    using _03.Game.Models;

    public static class Engine
    {
        public const int MaximumTurns = 35;

        public const int MaximumPlayersCount = 5;

        public static int Counter;

        public static void Run()
        {
            string command = string.Empty;
            char[,] playground = PlaygroundFactory.CreatePlayground();
            char[,] bombs = BombFactory.PutBombsOnField();
            bool isDestroyed = false;
            List<Player> players = new List<Player>();
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            bool isWinTheGame = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(
                        "Lets play Mines." + Environment.NewLine
                        + "Try your luck to find the fields without mines on them." + Environment.NewLine
                        + "The commands are:" + Environment.NewLine + " top - shows the rating, " + Environment.NewLine
                        + "restart - start a new game, " + Environment.NewLine + "exit - exit the game");
                    Playground.ShowThePlayground(playground);
                    isNewGame = false;
                }

                Console.Write("Enter command or row and column: ");
                command = Console.ReadLine().Trim();

                //Check if the given input is coordinates and they are in the range of the playground
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= playground.GetLength(0) && col <= playground.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        CommandManager.ShowRanking(players);
                        break;
                    case "restart":
                        CommandManager.RestartGame(playground, bombs, isDestroyed, isNewGame);
                        isDestroyed = false;
                        isNewGame = false;

                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                RespondToTheTurn(playground, bombs, row, col);
                                Counter++;
                            }

                            if (MaximumTurns == Counter)
                            {
                                isWinTheGame = true;
                            }

                            else
                            {
                                Playground.ShowThePlayground(playground);
                            }
                        }

                        else
                        {
                            isDestroyed = true;
                        }

                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Unknown command");
                        break;
                }

                if (isDestroyed)
                {
                    Playground.ShowThePlayground(bombs);
                    Console.WriteLine(Environment.NewLine + "You die with {0} points. Enter your name: ", Counter);
                    string name = Console.ReadLine();
                    Player player = new Player(name, Counter);

                    if (players.Count < MaximumPlayersCount)
                    {
                        players.Add(player);
                    }

                    else
                    {
                        //If the new player's points are more than
                        //any of the previous players, add the new player
                        for (int index = 0; index < players.Count; index++)
                        {
                            if (players[index].Points < player.Points)
                            {
                                players.Insert(index, player);

                                //Removes the last player
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player player1, Player player2) => player2.Name.CompareTo(player1.Name));
                    players.Sort((Player player1, Player player2) => player2.Points.CompareTo(player1.Points));

                    playground = PlaygroundFactory.CreatePlayground();
                    bombs = BombFactory.PutBombsOnField();
                    Counter = 0;
                    isDestroyed = false;
                    isNewGame = true;
                }

                if (isWinTheGame)
                {
                    Console.WriteLine(
                        Environment.NewLine + "Congratulations! You openned every cell without finding a bomb");
                    Playground.ShowThePlayground(bombs);
                    Console.WriteLine("Enter you name: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, Counter);
                    players.Add(player);
                    CommandManager.ShowRanking(players);
                    playground = PlaygroundFactory.CreatePlayground();
                    bombs = BombFactory.PutBombsOnField();
                    Counter = 0;
                    isWinTheGame = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void RespondToTheTurn(char[,] playground, char[,] bombs, int row, int col)
        {
            char bombsCounter = Bomb.CountBombs(bombs, row, col);
            bombs[row, col] = bombsCounter;
            playground[row, col] = bombsCounter;
        }
    }
}