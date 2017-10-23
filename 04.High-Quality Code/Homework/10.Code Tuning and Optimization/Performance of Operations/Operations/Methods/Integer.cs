namespace Operations.Methods
{
    using Operations.Enum;

    public class Integer
    {
        public static void Add()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                n += (int)Constants.DefaultNumberForAdd;
            }
        }

        public static void Subtract()
        {
            int n = (int)Constants.DefaultCount;
            for (int i = 0; i < n; i++)
            {
                n -= (int)Constants.DefaultNumberForSubtract;
            }
        }

        public static void PrefixIncrement()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                n++;
            }
        }

        public static void PostfixIncrement()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                ++n;
            }
        }

        public static void SimpleIncrement()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                n += 1;
            }
        }

        public static void Multiply()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                n *= (int)Constants.DefaultNumberForMultiply;
            }
        }

        public static void Divide()
        {
            int n = 0;
            for (int i = 0; i < (int)Constants.DefaultCount; i++)
            {
                n /= (int)Constants.DefaultNumberForDivide;
            }
        }
    }
}