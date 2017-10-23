using System;

namespace Operations
{
    using System.Diagnostics;

    using Operations.Enum;
    using Operations.Methods;

    public class Program
    {
        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int count = (int)Constants.DefaultCount;

            DisplayTimeNumbersAdd(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersSubtract(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersPrefixIncrement(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersPostfixIncrement(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersSimpleIncrement(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersMultiply(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersDivide(count);

            Console.WriteLine("---------------------------");
            DisplayTimeNumbersSquareRoot(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersLog(count);
            Console.WriteLine("---------------------------");
            DisplayTimeNumbersSin(count);

            //CalculateAverage.CalcAverage();

        }

        
        private static void DisplayTimeNumbersAdd(int count)
        {
            Console.WriteLine("Add integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.Add);

            Console.WriteLine("Add long {0} times: ", count);
            DisplayExecutionTime(
                Long.Add);

            Console.WriteLine("Add double {0} times: ", count);
            DisplayExecutionTime(
                Double.Add);

            Console.WriteLine("Add decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.Add);
        }

        private static void DisplayTimeNumbersSubtract(int count)
        {
            Console.WriteLine("Subtract integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.Subtract);

            Console.WriteLine("Subtract long {0} times: ", count);
            DisplayExecutionTime(
                Long.Subtract);

            Console.WriteLine("Subtract double {0} times: ", count);
            DisplayExecutionTime(
                Double.Subtract);

            Console.WriteLine("Subtract decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.Subtract);
        }

        private static void DisplayTimeNumbersPrefixIncrement(int count)
        {
            Console.WriteLine("Prefix increment integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.PrefixIncrement);

            Console.WriteLine("Prefix increment long {0} times: ", count);
            DisplayExecutionTime(
                Long.PrefixIncrement);

            Console.WriteLine("Prefix increment double {0} times: ", count);
            DisplayExecutionTime(
                Double.PrefixIncrement);

            Console.WriteLine("Prefix increment decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.PrefixIncrement);
        }

        private static void DisplayTimeNumbersPostfixIncrement(int count)
        {
            Console.WriteLine("Postfix increment integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.PostfixIncrement);

            Console.WriteLine("Postfix increment long {0} times: ", count);
            DisplayExecutionTime(
                Long.PostfixIncrement);

            Console.WriteLine("Postfix increment double {0} times: ", count);
            DisplayExecutionTime(
                Double.PostfixIncrement);

            Console.WriteLine("Postfix increment decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.PostfixIncrement);
        }

        private static void DisplayTimeNumbersSimpleIncrement(int count)
        {
            Console.WriteLine("Simple increment integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.SimpleIncrement);

            Console.WriteLine("Simple increment long {0} times: ", count);
            DisplayExecutionTime(
                Long.SimpleIncrement);

            Console.WriteLine("Simple increment double {0} times: ", count);
            DisplayExecutionTime(
                Double.SimpleIncrement);

            Console.WriteLine("Simple increment decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.SimpleIncrement);
        }

        private static void DisplayTimeNumbersMultiply(int count)
        {
            Console.WriteLine("Multiply integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.Multiply);

            Console.WriteLine("Multiply long {0} times: ", count);
            DisplayExecutionTime(
                Long.Multiply);

            Console.WriteLine("Multiply double {0} times: ", count);
            DisplayExecutionTime(
                Double.Multiply);

            Console.WriteLine("Multiply decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.Multiply);
        }

        private static void DisplayTimeNumbersDivide(int count)
        {
            Console.WriteLine("Divide integer {0} times: ", count);
            DisplayExecutionTime(
                Integer.Divide);

            Console.WriteLine("Divide long {0} times: ", count);
            DisplayExecutionTime(
                Long.Divide);

            Console.WriteLine("Divide double {0} times: ", count);
            DisplayExecutionTime(
                Double.Divide);

            Console.WriteLine("Divide decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.Divide);
        }

        private static void DisplayTimeNumbersSquareRoot(int count)
        {
            Console.WriteLine("Square root double {0} times: ", count);
            DisplayExecutionTime(
                Double.MathSquare);

            Console.WriteLine("Square root decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.MathSquare);
        }

        private static void DisplayTimeNumbersLog(int count)
        {
            Console.WriteLine("Find log double {0} times: ", count);
            DisplayExecutionTime(
                Double.MathLog);

            Console.WriteLine("Find log decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.MathLog);
        }

        private static void DisplayTimeNumbersSin(int count)
        {
            Console.WriteLine("Find sin double {0} times: ", count);
            DisplayExecutionTime(
                Double.MathSine);

            Console.WriteLine("Find sin decimal {0} times: ", count);
            DisplayExecutionTime(
                Decimal.MathSine);
        }
    }
}