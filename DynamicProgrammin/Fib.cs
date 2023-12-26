using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    internal class Fib
    {
        public int fib(int n)
        {
            if(n == 1 || n == 2)
            {
                return 1;
            }
            return fib(n-1) + fib(n-2);
        }
        public int fib2(int n, int[] dp)
        {
            int result = 0;

            // Check if the value has already been computed
            if (dp[n] != 0)
            {
                return dp[n];
            }
            else
            {
                
                // handling base case 
                if (n == 1 || n == 2)
                {
                    result = 1;
                }
                else
                {
                    result = fib2(n-1, dp) + fib2(n-2, dp);
                }
                dp[n] = result;
                
            }


            return result;
        }

        public int fib3(int n )
        {
            if(n==1 || n == 2)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 1;
            for(int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        public int fib4(int n)
        {
            // Base cases: return 1 if n is 1 or 2
            if (n == 1 || n == 2)
            {
                return 1;
            }

            // Initialize the dynamic programming array
            int[] dp = new int[n + 1];
            dp[1] = 1; // First Fibonacci number
            dp[2] = 1; // Second Fibonacci number

            // Compute Fibonacci numbers from 3 to n
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            // Return the nth Fibonacci number
            return dp[n];
        }

    }
}
