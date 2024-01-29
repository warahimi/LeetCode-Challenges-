using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
 */
namespace BackTracking_and_Recursion
{
    /*
     there will total number of n! permutations
    give arr = [1,2,3] there are 3 ways to decicde to pick the 1st number in our premutation 
    we can either take the first number as first element in our premutation arr[0], 
            for secodn element in permutation 
            we can pick the end element or the 3rd ...
  
    or 

    we can either take the second number as first element in our premutation arr[1], 
            .....
    or 
    we can either take the third number as first element in our premutation arr[2],

    for secodn element in permutation 
    we can
     */
    internal class _46_Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            GeneratePermutations(nums, 0, result);
            return result;
        }

        private void GeneratePermutations(int[] nums, int start, IList<IList<int>> result)
        {
            // If we've reached the end of the array, add a copy of it to the result
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                // Swap the current element with the start element
                Swap(nums, start, i);

                // Recursively call the function for the next element
                GeneratePermutations(nums, start + 1, result);

                // Backtrack and undo the previous swap
                Swap(nums, start, i);
            }
        }

        public IList<IList<int>> Permute2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            GeneratePermutations2(nums, 0, result);
            return result;
        }

        private void GeneratePermutations2(int[] nums, int start, IList<IList<int>> result)
        {
            // If we've reached the end of the array, add a copy of it to the result
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }

            // Swap the current element with each element including itself
            SwapAndRecurse(nums, start, start, result);
        }

        private void SwapAndRecurse(int[] nums, int start, int current, IList<IList<int>> result)
        {
            if (current == nums.Length)
            {
                // No more elements to swap with, go back to previous level
                return;
            }

            // Swap the start element with the current element
            Swap(nums, start, current);

            // Recursively call the function for the next element
            GeneratePermutations2(nums, start + 1, result);

            // Backtrack and undo the previous swap
            Swap(nums, start, current);

            // Recurse with the next element
            SwapAndRecurse(nums, start, current + 1, result);
        }



        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        } 
    }
}
