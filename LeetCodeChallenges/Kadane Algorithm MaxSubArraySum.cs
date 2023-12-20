using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    
    Kadane's Algorithm is an efficient method to find the maximum sum subarray in a given array. 
    This subarray contains the largest sum of consecutive elements in the array. The beauty of Kadane's Algorithm
    lies in its simplicity and efficiency, as it can solve the problem in linear time, i.e., in O(n) time complexity.

    Here's a brief overview of how the algorithm works:

    1- Initialize Two Variables: One to store the maximum sum found so far (max_so_far) and another to store the maximum
    sum of subarray ending at the current position (max_ending_here).

    2- Iterate Through the Array: For each element in the array, update max_ending_here by adding the current element to it.

    3- Check for Maximum: If max_ending_here is greater than max_so_far, update max_so_far with the value of max_ending_here.

    4- Negative Values Handling: If max_ending_here becomes negative, reset it to zero. This step ensures that only 
    subarrays with positive sums are considered.

    Result: After completing the iteration through the array, max_so_far contains the maximum sum of any subarray in the given array.

    This algorithm is highly useful in various applications, particularly in the fields of computer science and data analysis, 
    where finding such subarrays efficiently can be critical.
 */
namespace LeetCodeChallenges
{
    internal class Kadane_Algorithm_MaxSubArraySum
    {
        public int MaxSubArraySum(int[] arr)
        {
            int size = arr.Length;
            int maxSoFar = int.MinValue;
            int maxEndingHere = 0;

            for (int i = 0; i < size; i++)
            {
                // Add current element to maxEndingHere
                maxEndingHere = maxEndingHere + arr[i];

                // If maxSoFar is less than maxEndingHere, update maxSoFar
                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;

                // If maxEndingHere is negative, reset it to 0
                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }
            return maxSoFar;
        }
        public int MaxSubArrayBruteForce(int[] arr)
        {
            int size = arr.Length;
            int curSum = 0;
            int maxSum = 0; 

            for(int i = 0; i < size; ++i)
            {
                curSum = 0;
                for(int j = i; j < size; ++j)
                {
                    curSum += arr[j];
                    if(curSum > maxSum)
                    {
                        maxSum = curSum;
                    }
                }
            }
            return maxSum;
        }
        public int MaxSubArray2(int[] arr)
        {
            int size = arr.Length;
            int curSum = arr[0];
            int maxSum = arr[0];
            for(int i =1; i<size; ++i)
            {
                curSum  = Math.Max(arr[i], arr[i]+curSum);

                maxSum = Math.Max(maxSum, curSum);
            }

            return maxSum;
        }
    }
}
