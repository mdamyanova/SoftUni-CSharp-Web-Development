namespace Operations.Methods
{
    using Operations.Enum;

    public class Long
    {
        public static void Add()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                n += (long)Constants.DefaultNumberForAdd;
            }
        }

        public static void Subtract()
        {
            long n = (long)Constants.DefaultCount;
            for (long i = 0; i < n; i++)
            {
                n -= (long)Constants.DefaultNumberForSubtract;
            }
        }

        public static void PrefixIncrement()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                n++;
            }
        }

        public static void PostfixIncrement()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                ++n;
            }
        }

        public static void SimpleIncrement()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                n += 1;
            }
        }

        public static void Multiply()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                n *= (long)Constants.DefaultNumberForMultiply;
            }
        }

        public static void Divide()
        {
            long n = 0;
            for (long i = 0; i < (long)Constants.DefaultCount; i++)
            {
                n /= (long)Constants.DefaultNumberForDivide;
            }
        }
    }
}