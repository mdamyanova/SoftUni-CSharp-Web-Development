using System;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction result = new Fraction(((a.Numerator * b.Denominator) + (a.Denominator * b.Numerator)), 
                (a.Denominator * b.Denominator));
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction result = new Fraction(((a.Numerator * b.Denominator) - (a.Denominator * b.Numerator)), 
                (a.Denominator * b.Denominator));
            return result;
        }

        public override string ToString()
        {
            return $"{(decimal)this.Numerator/this.Denominator}\n";
        }
    }
}