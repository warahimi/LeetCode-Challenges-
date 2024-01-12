using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _1TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int diff;
            for (int i = 0; i < nums.Length; i++)
            {
                diff = target - nums[i];
                if (d.ContainsKey(diff))
                {
                    return new int[] { d[diff], i };
                }
                else if (!d.ContainsKey(nums[i]))
                {
                    d.Add(nums[i], i);
                }
            }
            return null;
        }
    }
}
