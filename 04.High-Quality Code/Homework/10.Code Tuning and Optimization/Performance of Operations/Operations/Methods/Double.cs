namespace Operations.Methods
{
    using System;

    using Operations.Enum;

    public class Double
    {
        private const double DefaultNumberForLog = 4.9;

        private const double DefaultNumberForLogBase = 1.2;

        private const double DefaultNumberForSin = 3.4;

        public static void Add()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n += (double)Constants.DefaultNumberForAdd;
            }
        }

        public static void Subtract()
        {
            double n = (double)Constants.DefaultCount;
            for (double i = 0; i < n; i++)
            {
                n -= (double)Constants.DefaultNumberForSubtract;
            }
        }

        public static void PrefixIncrement()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n++;
            }
        }

        public static void PostfixIncrement()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                ++n;
            }
        }

        public static void SimpleIncrement()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n += 1;
            }
        }

        public static void Multiply()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n *= (double)Constants.DefaultNumberForMultiply;
            }
        }

        public static void Divide()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n /= (double)Constants.DefaultNumberForDivide;
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
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n = Math.Log(DefaultNumberForLog, DefaultNumberForLogBase);
            }
        }

        public static void MathSine()
        {
            double n = 0;
            for (double i = 0; i < (double)Constants.DefaultCount; i++)
            {
                n = Math.Sin(DefaultNumberForSin);
            }
        }
    }
}