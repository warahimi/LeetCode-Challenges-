using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    /*
     * Given an integer num, return the number of steps to reduce it to zero.

    In one step, if the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.
     */
    internal class _1342_Number_of_Steps_to_Reduce_a_Number_to_Zero
    {
        public int NumberOfSteps(int num)
        {
            return helper(num, 0);
        }
        private int helper(int num, int steps)
        {
            if (num == 0)
            {
                return steps;
            }
            if (num % 2 == 0)
            {
                return helper(num / 2, steps + 1);
            }
            else
            {
                return helper(num - 1, steps + 1);
            }
        }

        // non recursive solution 
        public int NumberOfSteps2(int num)
        {
            int steps = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }
                steps++;
            }
            return steps;
        }
    }
}
