using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.

 

Example 1:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]
Example 2:

Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
 */
namespace LeetCodeChallenges
{
    internal class _238_Product_of_Array_Except_Self
    {
        
        public int[] ProductExceptSelf(int[] nums)
        {
            // Get the length of the input array.
            int n = nums.Length;

            // Initialize arrays to store the left and right products.
            int[] leftProducts = new int[n];
            int[] rightProducts = new int[n];

            // This will be the final answer array.
            int[] answer = new int[n];

            // Initialize the first element of leftProducts to 1 
            // as there are no elements to the left of the first element.
            leftProducts[0] = 1;
            // Calculate the product of all elements to the left of each element.
            for (int i = 1; i < n; i++)
            {
                leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
            }

            // Similarly, initialize the last element of rightProducts to 1
            // as there are no elements to the right of the last element.
            rightProducts[n - 1] = 1;
            // Calculate the product of all elements to the right of each element.
            for (int i = n - 2; i >= 0; i--)
            {
                rightProducts[i] = rightProducts[i + 1] * nums[i + 1];
            }

            // Construct the answer array where each element is the product
            // of all the numbers to the left and right of the current element.
            for (int i = 0; i < n; i++)
            {
                answer[i] = leftProducts[i] * rightProducts[i];
            }

            // Return the final answer array.
            return answer;
        }
        /*
         * Space Optimization: Instead of using two additional arrays for left and right products, you can use only the answer 
         * array and a variable to store the right product. This reduces the space complexity to O(1), excluding the output array.
         */
        public int[] ProductExceptSelf2(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];

            // Initialize the first element of answer to 1
            answer[0] = 1;
            // Calculate the product of all elements to the left of each element.
            for (int i = 1; i < n; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // Use a variable to track the right product.
            int rightProduct = 1;
            // Calculate the product of all elements to the right of each element
            // and multiply it with the left product stored in answer array.
            for (int i = n - 1; i >= 0; i--)
            {
                answer[i] = answer[i] * rightProduct;
                rightProduct *= nums[i];
            }

            return answer;
        }
        public int[] ProductExceptSelf3(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];

            answer[0] = 1; 
            for(int i = 1; i < n;i++)
            {
                answer[i] = answer[i-1] * nums[i - 1];
            }
            int rightProduct = 1;
            for(int i = n - 1;i >= 0; i--)
            {
                answer[i] = answer[i] * rightProduct;
                rightProduct *= nums[i];
            }
            return answer;
        }
        public int[] ProductExceptSelf4(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];
            int[] leftProduct = new int[n];
            int[] rightProduct = new int[n];

            leftProduct[0] = 1;
            for(int i = 1; i < n; i++)
            {
                leftProduct[i] = leftProduct[i-1] * nums[i-1];
            }
            rightProduct[n-1] = 1;
            for(int i = n - 2; i>=0; i--)
            {
                rightProduct[i] = rightProduct[i+1] * nums[i+1];
            }

            for(int i = 0; i < n; i ++)
            {
                answer[i] = rightProduct[i] * leftProduct[i];
            }
            return answer;
        }
    }
}
