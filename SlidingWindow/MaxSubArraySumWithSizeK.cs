using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class MaxSubArraySumWithSizeK
    {
        // brute force
        public int maxSubArraySumWithSizeK(int[] arr, int k)
        {
            if(arr.Length < k)
            {
                return -1;
            }
            int maxSum = int.MinValue;
            for(int i = 0; i <= arr.Length - k; i++)
            {
                int curSum = 0;
                for(int j = i; j < i+ k; j++)
                {
                    curSum += arr[j];
                }
                maxSum = Math.Max(maxSum, curSum);
            }
            return maxSum;
        }
        /*
        To solve this problem in C#, we can use the sliding window technique. This technique involves maintaining a window of 
        size K that slides through the array, and at each step, we calculate the sum of elements in this window. We keep track of 
        the maximum sum encountered during this process.
         */
        public int MaxSum(int[] arr, int K)
        {
            int N = arr.Length;
            // Handling edge cases
            if (N < K)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            // Compute the sum of the first window of size K
            int maxSum = 0;
            for (int i = 0; i < K; i++)
            {
                maxSum += arr[i];
            }

            // Initialize sum of current window
            int windowSum = maxSum;

            // Slide the window over the array from start to end
            for (int i = K; i < N; i++)
            {
                // Add the next element of the array to the current window
                // and remove the first element of the current window
                windowSum += arr[i] - arr[i - K];

                // Update maxSum if needed
                maxSum = Math.Max(maxSum, windowSum);
            }

            // Return the maximum sum of a subarray of size K
            return maxSum;
        }

        public long MaximumSumSubarray(int[] Arr, int K)
        {
            // Initialize variables
            long max = 0; // To store the maximum sum
            long sum = 0; // To store the current window sum

            int left = 0, right = 0; // Pointers to the left and right ends of the window
            int N = Arr.Length;

            // Iterate over the array using the right pointer
            while (right < N)
            {
                sum += Arr[right]; // Add the current element to the sum
                max = Math.Max(sum, max); // Update max if the current window's sum is greater
                right++; // Move the right end of the window forward

                // Check if the window size is equal to K
                if (right - left == K)
                {
                    sum -= Arr[left]; // Remove the leftmost element from the sum
                    left++; // Move the left end of the window forward
                }
            }

            // Return the maximum sum found
            return max;
        }

        public long MaximumSumSubarray2(int[] Arr, int K)
        {
            // Initialize variables
            int start = 0; // Start of the window
            int end = 0; // End of the window
            long sum = 0; // Sum of elements in the current window
            long max = long.MinValue; // Maximum sum found, initialized to the smallest possible value
            int N = Arr.Length;
            // Iterate over the array
            while (end < N)
            {
                sum += Arr[end]; // Add the current element to the sum

                // Check if the window size is smaller than K
                if ((end - start) + 1 < K)
                {
                    end++; // Increase the window size by moving the end pointer
                }
                else if ((end - start) + 1 == K) // When window size is exactly K
                {
                    max = Math.Max(sum, max); // Update max if current sum is greater
                    sum -= Arr[start]; // Remove the start element from sum
                    start++; // Move the window forward
                    end++; // Move the window forward
                }
            }

            // Return the maximum sum found
            return max;
        }

        public int maxSubArraySum(int[] arr, int k)
        {
            int n = arr.Length;
            int curSum = 0;
            int maxSum = 0;
            int i = 0;
            int j = 0;

            while(j < n)
            {
                curSum += arr[j];
                maxSum = Math.Max(curSum, maxSum);
                j++;

                if(j - i  == k)
                {
                    curSum -= arr[i];
                    i++;
                }
            }
            return maxSum;
        }
    }
}
