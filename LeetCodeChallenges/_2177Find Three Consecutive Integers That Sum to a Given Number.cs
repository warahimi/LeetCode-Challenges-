using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _2177Find_Three_Consecutive_Integers_That_Sum_to_a_Given_Number
    {
        //n-1 + n + n +1 = num
        // 3n = num the given number has to be a multiple of 3
        public long[] SumOfThree(long num)
        {
            if (num % 3 == 0)
            {
                long n = num / 3;
                return new long[] { n - 1, n, n + 1 };
            }
            else
            {
                return new long[0];
            }
        }
    }
}
