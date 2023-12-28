using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Given an integer array nums, find the 
    subarray
     with the largest sum, and return its sum.

 

    Example 1:

    Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
    Output: 6
    Explanation: The subarray [4,-1,2,1] has the largest sum 6.
    Example 2:

    Input: nums = [1]
    Output: 1
    Explanation: The subarray [1] has the largest sum 1.
    Example 3:

    Input: nums = [5,4,-1,7,8]
    Output: 23
    Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
 */
namespace SlidingWindow
{
    internal class _53Maximum_Subarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int curSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                curSum += nums[i];
                maxSum = Math.Max(curSum, maxSum);
                if (curSum < 0)
                {
                    curSum = 0;
                }
            }
            return maxSum;
        }

        public int MaxSubArray2(int[] nums)
        {
            int maxEnding = nums[0];
            int max = nums[0];
            for (int i = 1; nums.Length > i; i++)
            {
                maxEnding = Math.Max(nums[i], maxEnding + nums[i]);
                max = Math.Max(max, maxEnding);
            }
            return max;
        }
        public int MaxSubArray3(int[] nums)
        {
            int sum = 0;
            int maxSum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (nums[i] > sum)
                {
                    sum = nums[i];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            return maxSum;
        }
    }
}
