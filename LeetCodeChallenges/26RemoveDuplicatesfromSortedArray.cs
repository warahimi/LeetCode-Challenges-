using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _26RemoveDuplicatesfromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }
            int r = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[r] != nums[i])
                {
                    nums[++r] = nums[i];
                }
            }
            return r + 1;
        }
    }
}
