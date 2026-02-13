using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chome4
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new Exception("Знаменник не може бути 0!");

            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            return new Fraction(Numerator / gcd, Denominator / gcd);
        }
        private int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator
            ).Simplify();
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator
            ).Simplify();
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Numerator,
                a.Denominator * b.Denominator
            ).Simplify();
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new Exception("Ділення на нуль!");

            return new Fraction(
                a.Numerator * b.Denominator,
                a.Denominator * b.Numerator
            ).Simplify();
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            Fraction fa = a.Simplify();
            Fraction fb = b.Simplify();
            return fa.Numerator == fb.Numerator && fa.Denominator == fb.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            Fraction f = this.Simplify();
            if (f.Denominator == 1)
                return f.Numerator.ToString();
            return $"{f.Numerator}/{f.Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction f)
                return this == f;
            return false;
        }

        public override int GetHashCode()
        {
            Fraction f = this.Simplify();
            return (f.Numerator, f.Denominator).GetHashCode();
        }
    }
}
