using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideTwoIntegers_29
{
    internal class Solution
    {
        /// <summary>
        /// Ordinary solution
        /// O(n)
        /// O(1)
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            // Handle special case for INT_MIN dividend by -1 to prevent overflow
            if(dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            // Determine final sign through XOR (true, when different values)
            bool sign = ((dividend > 0) ^ (divisor > 0)) ? false : true;

            // Use long to avoid overflow during negation
            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);

            int quotient = 0;
            while(absDividend > absDivisor)
            {
                absDividend -= absDivisor;
                ++quotient;
            }

            return sign ? quotient : -quotient;
        }

        /// <summary>
        /// O(log(n)), n - absulte value of the dividend
        /// O(1)
        /// left shift << by 1 bit increases by 2
        /// right shift >> by 1 bit is equvivalent of integer divison by half </increases>
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int DivideEfficient(int dividend, int divisor)
        {
            // Special case handling
            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            // Determine final sign through XOR (true, when different values)
            bool sign = ((dividend > 0) ^ (divisor > 0)) ? false : true;

            // Use long to avoid overflow during negation
            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);

            int quotient = 0;
            while (absDividend > absDivisor)
            {
                long tempDivisor = absDivisor;
                int multiple = 1;

                // Double the divisor efficiently
                while(tempDivisor <= absDividend >> 1)
                {
                    tempDivisor <<= 1;
                    multiple <<= 1;
                }

                absDividend -= tempDivisor;
                quotient += multiple;
            }

            return sign ? quotient : -quotient;
        }
    }


}
