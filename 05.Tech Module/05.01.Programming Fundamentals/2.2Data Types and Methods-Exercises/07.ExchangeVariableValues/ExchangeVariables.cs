using System;

namespace _07.ExchangeVariableValues
{
    public class ExchangeVariables
    {
        public static void Main()
        {
            int a = 5;
            int b = 10;

            Console.WriteLine($"Before:\na = {a}\nb = {b}");

            int tempValue = a;
            a = b;
            b = tempValue;

            Console.WriteLine($"After:\na = {a}\nb = {b}");
        }
    }
}