using System;

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                    numbers[i] = ReadNumber(start, end);                  
            }
        }

        public static int ReadNumber(int start, int end)
        {
            try
            {
                Console.Write("Enter number [{0}...{1}]: ", start, end);
                int number = int.Parse(Console.ReadLine());

                if (number <= start || number >= end)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("You should enter number. Try again: ");
                return ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number should be in range [{0}...{1}]. Try again: ", start, end);
                return ReadNumber(start, end);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message + " Try again: ");
                return ReadNumber(start, end);
            }
        }
    }
}