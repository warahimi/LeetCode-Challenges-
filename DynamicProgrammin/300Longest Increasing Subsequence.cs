using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DynamicProgramming
{
    internal class _300Longest_Increasing_Subsequence
    {
        //Input: nums = [10,9,2,5,3,7,101,18]
        public int LengthOfLIS(int[] nums)
        {
            // 1. Create an array 'map' to store the length of the longest increasing subsequence
            // ending at each index.
            var map = new int[nums.Length];

            // 2. Iterate over the array in reverse.
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                // 3. For each element, check subsequent elements to find an increasing sequence.
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // 4. If a subsequent element is greater than the current element,
                    // update the 'map' for the current element to the maximum value found so far.
                    // This step essentially checks for all possible subsequences starting at 'i'
                    // and includes the best possible continuation from 'j'.
                    if (nums[i] < nums[j])
                    {
                        map[i] = Math.Max(map[i], map[j]);
                    }
                }

                // 5. Increment the count at 'map[i]' because the element itself forms a 
                // subsequence of length 1. This step accounts for the length of the current element itself.
                map[i] += 1;
            }

            // 6. Return the maximum value in 'map', which represents the length of the longest 
            // increasing subsequence in the entire array.
            return map.Max();
        }

        public int LengthOfLIS2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                        }
                    }
                }
            }
            return dp.Max() + 1;
        }

        public int LengthOfLIS3(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int[] dp = new int[nums.Length];
            int maxAns = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                maxAns = Math.Max(maxAns, dp[i]);
            }

            return maxAns + 1;
        }
    }
}
