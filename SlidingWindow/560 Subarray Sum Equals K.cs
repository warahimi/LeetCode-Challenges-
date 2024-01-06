using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class _560_Subarray_Sum_Equals_K
    {
        // Brute Force
        public int totalSubArrays(int[] array, int k) // O(n^2) O(1)
        {
            int total = 0;
            for(int i = 0; i<array.Length; i++)
            {
                int curSum = 0;
                for(int j = i; j< array.Length;j++)
                {
                    curSum += array[j];
                    if(curSum == k)
                    {
                        total++;
                    }
                    
                }
            }
            return total;
        }

        public int totalSubArrays2(int[] array, int k) // O(n^2) O(n)
        {
            int total = 0;
            int[] prerixSum = new int[array.Length];
            int curSum = 0;

            for(int i = 0; i < array.Length; i++)
            {
                curSum += array[i];
                if(curSum == k)
                    total++;
                prerixSum[i] = curSum;
                for(int j = 0; j < i; j++)
                {
                    if (prerixSum[j] == curSum - k)
                    {
                        total++;
                        break;
                    }
                }
            }
            return total;
        }

        /*
            Optimization: to O(n)
        Sub arrays with given sum k may start at any poin and end at any point, but always start index <= end index
        instead of int[] prerixSum we can use a dictionary/map/hashmap that gives us O(1) lookup time 

         */
        public int SubarraySum(int[] nums, int k)
        {
            if(nums.Length == 0 || nums == null)
                return 0;
            int total = 0;
            Dictionary<int, int> prefixSum = new Dictionary<int, int>(); // key is the accumaltive sume and value is number of times it happens
            int accumalativeSum = 0;                                                             
            for (int i = 0; i < nums.Length; i++)
            {
                accumalativeSum += nums[i];
                if(accumalativeSum == k)
                    total++;

                if(prefixSum.ContainsKey(accumalativeSum - k))
                {
                    //total++;
                    total += prefixSum[accumalativeSum - k];
                }

                if(prefixSum.ContainsKey(accumalativeSum))
                {
                    prefixSum[accumalativeSum]++;
                }
                else
                {
                    prefixSum.Add(accumalativeSum, 1);
                }
            }
            return total;
        }
    }
}
