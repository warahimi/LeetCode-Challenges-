using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element 
    appears at most twice. The relative order of the elements should be kept the same.

    Since it is impossible to change the length of the array in some languages, you must instead have the result be placed 
    in the first part of the array nums. More formally, if there are k elements after removing the duplicates, 
    then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

    Return k after placing the final result in the first k slots of nums.

    Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
 */
namespace LeetCodeChallenges
{
    internal class _80RemoveDuplicatesfromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
            { // If array length is 2 or less, no duplicates to remove
                return nums.Length;
            }

            int count = 2; // Count of allowed duplicates

            for (int i = 2; i < nums.Length; i++)
            { // Iterate through the array starting from the third element
                if (nums[i] != nums[count - 2])
                { // If current element is different from element at count-2, it is a non-duplicate
                    nums[count] = nums[i]; // Overwrite duplicates with non-duplicates
                    count++; // Increment count of non-duplicates
                }
            }

            return count; // Length of modified array with duplicates removed
        }
        public int RemoveDuplicates22(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }
            int j = 2;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 2])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }
        public int RemoveDuplicates2(int[] nums)
        {
            int i = 0;
            foreach (int num in nums)
            {
                if (i < 2 || num != nums[i - 2])
                {
                    nums[i] = num;
                    i++;
                }
            }
            return i;
        }
    }
}
