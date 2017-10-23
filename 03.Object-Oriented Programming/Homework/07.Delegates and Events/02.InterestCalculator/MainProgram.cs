using System;

namespace _02.InterestCalculator
{
    class MainProgram
    {
        public const int DefaultTimesPerYear = 12;

        private static void Main()
        {
            var compoundCalculator = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);
            Console.WriteLine(compoundCalculator);

            var simpleCalculator = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);
            Console.WriteLine(simpleCalculator);
        }

        public static double GetSimpleInterest(decimal money, double interest, int years)
        {
            return (double)money * (1 + (interest / 100) * years);
        }

        public static double GetCompoundInterest(decimal money, double interest, int years)
        {
            return (double)money * Math.Pow((1 + (interest / 100) / DefaultTimesPerYear), years * DefaultTimesPerYear);
        }
    }
}