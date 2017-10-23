namespace Huy_Phuong
{
    using System;
    using System.Linq;

    using Huy_Phuong.CommandManager;
    using Huy_Phuong.Engine;
    using Huy_Phuong.Interfaces;

    public class MainProgram
    {
        public static IPerformanceDatabase Database = new PerformanceDatabase();

        protected static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == null)
                {
                    return;
                }

                if (input != string.Empty)
                {
                    var inputParams = input.Split('(');
                    var command = inputParams[0];
                    var outputMessage = string.Empty;

                    try
                    {
                        switch (command)
                        {
                            case "AddTheatre":
                                inputParams = input.Split(
                                    new[] { '(', ',', ')' },
                                    StringSplitOptions.RemoveEmptyEntries);
                                var theatreName = inputParams.Skip(1).Select(t => t.Trim()).ToArray();

                                outputMessage = AddTheatre.ExecuteAddTheatreCommand(theatreName);
                                break;

                            case "PrintAllTheatres":
                                outputMessage = PrintAllTheatres.ExecutePrintAllTheatresCommand();
                                break;

                            case "AddPerformance":
                                inputParams = input.Split(
                                    new[] { '(', ',', ')' },
                                    StringSplitOptions.RemoveEmptyEntries);
                                var performanceParams = inputParams.Skip(1).Select(p => p.Trim()).ToArray();
                                outputMessage = AddPerformance.ExecuteAddPerformanceCommand(performanceParams);

                                break;

                            case "PrintAllPerformances":
                                outputMessage = PrintAllPerformances.ExecutePrintAllPerformancesCommand();
                                break;

                            case "PrintPerformances":
                                inputParams = input.Split(
                                    new[] { '(', ',', ')' },
                                    StringSplitOptions.RemoveEmptyEntries);
                                var theatreInfo = inputParams.Skip(1).Select(p => p.Trim()).ToArray();

                                outputMessage = PrintPerformances.ExecutePrintPerformancesCommand(theatreInfo);
                                break;

                            default:
                                outputMessage = "Invalid command!";
                                break;
                        }
                    }

                    catch (Exception ex)
                    {
                        outputMessage = "Error: " + ex.Message;
                    }

                    Console.WriteLine(outputMessage);
                }
            }
        }
    }
}