namespace _01.OOPIntro.Models
{
    class MathUtil
    {
        public static double Sum(double first, double second)
        {
            return first + second;
        }

        public static double Subtract(double first, double second)
        {
            return first - second;
        }

        public static double Multiply(double first, double second)
        {
            return first * second;
        }

        public static double Divide(double dividend, double divisor)
        {
            return dividend / divisor;
        }

        public static double Percentage(double total, double percent)
        {
            return total * (percent / 100);
        }
    }
}
