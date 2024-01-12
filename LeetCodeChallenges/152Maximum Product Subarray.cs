using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    /*
        Given an integer array nums, find a subarray that has the largest product, and return the product.

        The test cases are generated so that the answer will fit in a 32-bit integer.
    */
    internal class _152Maximum_Product_Subarray
    {
        public int MaxProduct(int[] nums)
        {
            int largestProduct = nums[0];
            int rightProduct = 1;
            int leftProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                // reset to 1 when the product becomes zero
                rightProduct = (rightProduct == 0 ? 1 : rightProduct) * nums[i];
                leftProduct = (leftProduct == 0 ? 1 : leftProduct) * nums[nums.Length - 1 - i];
                largestProduct = Math.Max(largestProduct, Math.Max(leftProduct, rightProduct));
            }
            return largestProduct;
        }
        public int MaxProduct2(int[] nums)
        {
            int maxProduct = nums[0];
            int n = nums.Length;
            int rightProduct = 1;
            int leftProduct = 1;

            for (int i = 0; i < n; i++)
            {
                rightProduct = rightProduct == 0 ? 1 : rightProduct;
                leftProduct = leftProduct == 0 ? 1 : leftProduct;
                rightProduct = rightProduct * nums[i];
                leftProduct *= nums[n-1-i];

                maxProduct = Math.Max(maxProduct, Math.Max(leftProduct, rightProduct));
            }
            return maxProduct;
        }

        // brute force 
        public int MaxProduct3(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int maxProduct = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int currentProduct = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    currentProduct *= nums[j];
                    maxProduct = Math.Max(maxProduct, currentProduct);
                }
            }

            return maxProduct;
        }
    }
}
