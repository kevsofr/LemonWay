using System;
using log4net;
using System.Numerics;

namespace LemonWayTools
{
    public static class Fibonacci
    {
        /// <summary>
        /// Gets the fibonacci.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        /// result
        /// </returns>
        public static BigInteger GetFibonacci(int n)
        {
            
            if (n >= 1 && n <= 100)
                return DoFibonacci(n);
            else
                return -1;
        }

        /// <summary>
        /// Does the fibonacci.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        /// result
        /// </returns>
        private static BigInteger DoFibonacci(int n)
        {
            BigInteger f1 = 1, res = 1, f2 = 1;
            for (int i = 2; i < n; i++)
            {
                f2 = res + f1;
                f1 = res;
                res = f2;
            }
            return res;
        }
    }
}
