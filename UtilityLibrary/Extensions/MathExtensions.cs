using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Extensions
{

    public static class MathExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }
        public static long Factorial(this int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be non-negative for factorial calculation.");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double Power(this double baseValue, double exponent)
        {
            if (baseValue == 0 && exponent < 0)
                throw new ArgumentException("Cannot raise 0 to a negative exponent.");

            return Math.Pow(baseValue, exponent);
        }

        public static bool IsPrime(this int number)
        {
            if (number < 2)
                throw new ArgumentException("Input must be greater than or equal to 2 for prime check.");

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static long Fibonacci(this int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be non-negative for Fibonacci calculation.");

            if (n == 0 || n == 1)
                return n;

            long a = 0, b = 1, result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }

        public static int Gcd(this int a, int b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Inputs must be positive for GCD calculation.");

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }


        public static long Permutations(this int n, int r)
        {
            if (n < 0 || r < 0)
                throw new ArgumentException("Inputs must be non-negative for permutations calculation.");

            if (n < r)
                throw new ArgumentException("n must be greater than or equal to r for permutations calculation.");

            long result = 1;

            for (int i = 0; i < r; i++)
            {
                result *= (n - i);
            }

            return result;
        }
    }
}
