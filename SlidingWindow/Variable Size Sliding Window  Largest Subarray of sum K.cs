using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * find all sub array that have of size K and return the size of the largest sub array among those  
 */
namespace SlidingWindow
{
    internal class Variable_Size_Sliding_Window__Largest_Subarray_of_sum_K
    {
        public int largestSubArraySize(int[] arr, int k)
        {
            int largest = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                int cursum = 0;
                int curLen = 0; 
                for(int j = i; j < arr.Length; j++)
                {
                    cursum += arr[j];
                    if(cursum < k)
                    {
                        curLen++;
                    }
                    else if(cursum == k)
                    {
                        curLen++;
                        largest = Math.Max(largest, curLen);
                        break;
                    }
                    else
                    {
                        // if(curSum > k)
                        break;
                    }
                }
            }

            return largest;
        }

        

        public int largestSubArraySize2(int[] arr, int k)
        {
            int i = 0, 
                j = 0, 
                largestLen = 0, 
                curSum = 0;

            while (j < arr.Length)
            {
                curSum += arr[j];

                while (curSum > k && i <= j)
                {
                    curSum -= arr[i++];
                }

                if (curSum == k)
                {
                    largestLen = Math.Max(largestLen, j - i + 1);
                }

                j++;
            }

            return largestLen;
        }

    }
}
