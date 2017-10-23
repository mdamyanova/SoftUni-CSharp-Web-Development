using System;

namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            try
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }

                double sqrt = Math.Sqrt(number);
                Console.WriteLine(sqrt);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");               
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}