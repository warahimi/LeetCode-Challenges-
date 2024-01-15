using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _42_Trapping_Rain_Water
    {
        public int Trap1(int[] height) // O(n^2) , O(1)
        {
            int count = 0;
            int n = height.Length;

            for (int i = 1; i < n - 1; i++)
            {
                int leftMax = int.MinValue;
                int j = i - 1;
                while (j >= 0)  // calculating the leftMax for each eleemnt 
                {
                    leftMax = Math.Max(leftMax, height[j]);
                    j--;
                }
                int rightMax = int.MinValue;
                int k = i + 1;
                while (k < n) // calculating the right max for each element
                {
                    rightMax = Math.Max(rightMax, height[k]);
                    k++;
                }
                int traped = Math.Min(leftMax, rightMax) - height[i];
                if (traped <= 0)
                {
                    continue;
                }
                count += traped;
            }
            return count;
        }

        /*
         * before we traveresed the entire array to find the maxLeft and maxRight for each element, if we can store the maxLeft 
         * and maxRight for each element somehow then the time complexity will reduce */

        public int Trap2(int[] height) // O(n) time and O(n) space
        {
            int count = 0;
            int n = height.Length;
            int[] leftMax = new int[n]; // store max number to the left of each index
            int[] rightMax = new int[n]; // stores max number to the right of each index
            int max = height[0];
            leftMax[0] = 0; // there is no max to the right of the first element 
            for (int i = 1; i < n; i++)
            {
                max = Math.Max(max, height[i - 1]);
                leftMax[i] = max;
            }

            rightMax[n - 1] = 0; // there is not boundary or max to the right of the last element 
            max = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                max = Math.Max(max, height[i + 1]);
                rightMax[i] = max;
            }

            for (int i = 0; i < n; i++)
            {
                int res = Math.Min(leftMax[i], rightMax[i]) - height[i];
                if (res <= 0)
                {
                    continue;
                }
                count += res;
            }
            return count;
        }
        /*
         * O(n) tiem and O(1) space
         */
        public int Trap3(int[] height)
        {
            int count = 0;
            if(height == null || height.Count() < 2) // if there are one or two block we cannot store any water ,
                                                     // it should be at least 3 blocks
                                                     // also if the blocks / height elements are arranges in ascending or descending
                                                     // order then we canot form any bucket to trap water 
                                                     // to form a bucket there should a block greater than the current block to the 
                                                     // right and left of the current block
                                                     // the amount of traped water will depend on minimum boundary height

            {
                return 0;
            }
            /*
              Trapped water at each block equal to min(maxRighBoundary, maxLeftBoundary) - blockValue * width 
            the first and the last block can never trap water 
             */
            return count;
        }
    }
}
