using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /*
     You are climbing a staircase. It takes n steps to reach the top.

        Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
     */
    internal class _70Climbing_Stairs
    {
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        public int ClimbStairs2(int n)
        {
            int result = 1;
            int a = 1;
            int b = 1;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }

        public int climbStairs3Steps(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1; 
            dp[1] = 1;
            dp[2] = 2;

            for(int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i-2] + dp[i-3];
            }
            return dp[n];
        }
        public int climbStairs3Steps2(int n)
        {
            if(n == 0) return 1;
            if(n == 1) return 1;
            if(n == 2) return 2;
            int res = 0; 
            int a = 1; // way to climb 1 step
            int b = 1; 
            int c = 2; // ways to climb, 2 step

            for (int i = 3; i <= n; i++)
            {
                res = a + b + c;
                a = b;
                b = c;
                c = res;
            }
            return res;
        }
    }
}
