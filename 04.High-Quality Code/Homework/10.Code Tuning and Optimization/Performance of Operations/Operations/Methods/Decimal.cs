namespace Operations.Methods
{
    using System;

    using Operations.Enum;

    public class Decimal
    {
        private const double DefaultNumberForLog = 4.9;
                     
        private const double DefaultNumberForLogBase = 1.2;
                      
        private const double DefaultNumberForSin = 3.4;

        public static void Add()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                n += (decimal)Constants.DefaultNumberForAdd;
            }
        }

        public static void Subtract()
        {
            decimal n = (decimal)Constants.DefaultCount;
            for (decimal i = 0M; i < n; i++)
            {
                n -= (decimal)Constants.DefaultNumberForSubtract;
            }
        }

        public static void PrefixIncrement()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                n++;
            }
        }

        public static void PostfixIncrement()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                ++n;
            }
        }

        public static void SimpleIncrement()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                n += 1M;
            }
        }

        public static void Multiply()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                n *= (decimal)Constants.DefaultNumberForMultiply;
            }
        }

        public static void Divide()
        {
            decimal n = 0M;
            for (decimal i = 0M; i < (decimal)Constants.DefaultCount; i++)
            {
                n /= (decimal)Constants.DefaultNumberForDivide;
            }
        }

        public static void MathSquare()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n = Math.Sqrt((double)Constants.DefaultNumberForSquareRoot);
            }
        }

        public static void MathLog()
        {
            decimal n = 0;
            for (decimal i = 0; i < (decimal)Constants.DefaultCount; i++)
            {
                n = (decimal)Math.Log(DefaultNumberForLog, DefaultNumberForLogBase);
            }
        }

        public static void MathSine()
        {
            decimal n = 0;
            for (decimal i = 0; i < (decimal)Constants.DefaultCount; i++)
            {
                n = (decimal)Math.Sin(DefaultNumberForSin);
            }
        }
    }
}