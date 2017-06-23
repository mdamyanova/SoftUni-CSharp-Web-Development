using System;
using System.Collections.Generic;

namespace _01.JediMeditation
{
    public class JediMeditation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var masters = new List<string>();
            var knights = new List<string>();
            var toshkoandslav = new List<string>();
            var padawans = new List<string>();
            var yodaCame = false;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var jedi in input)
                {
                    switch (jedi[0])
                    {
                        case 'm':
                            masters.Add(jedi);
                            break;
                        case 'k':
                            knights.Add(jedi);
                            break;
                        case 'p':
                            padawans.Add(jedi);
                            break;
                        case 'y':
                            yodaCame = true;
                            break;
                        default:
                            toshkoandslav.Add(jedi);
                            break;

                    }
                }
            }

            var result = new List<string>();

            if (yodaCame)
            {
                result.AddRange(masters);
                result.AddRange(knights);
                result.AddRange(toshkoandslav);
                result.AddRange(padawans);
            }
            else
            {
                result.AddRange(toshkoandslav);
                result.AddRange(masters);
                result.AddRange(knights);
                result.AddRange(padawans);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
} 