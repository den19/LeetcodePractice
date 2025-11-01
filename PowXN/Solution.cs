using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowXN
{
    public class Solution
    {
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPowOrdinary(double x, int n)
        {
            if (n == 0) return 1;

            bool isNegativeExponent = false;
            long exponent = n;
            if (exponent < 0)
            {
                isNegativeExponent = true;
                exponent *= -1; // Change sign
            }

            double result = 1;
            for (long i = 0; i < exponent; i++) {
                result *= x;
            }

            return isNegativeExponent ? 1 / result : result;
        }

        public double MyPow(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return FastPower(x, N);
        }

        public double FastPower(double baseNum, long exp)
        {
            if(exp == 0) return 1;
            double half = FastPower(baseNum, exp / 2);

            if ((exp % 2) == 0)
            {
                return half * half;
            }
            else
            {
                return half = half * baseNum;
            }
        }
    }
}
