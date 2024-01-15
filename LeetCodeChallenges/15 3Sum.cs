using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _15_3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums); // Sort the array - O(n log n)
            // we sort the array to detect the duplicates by them self 
            HashSet<string> set = new HashSet<string>(); // To store unique triplets as strings
            List<IList<int>> result = new List<IList<int>>(); // Final result list

            for (int i = 0; i < n - 2; i++)
            {
                // Skip duplicate elements to avoid duplicate triplets
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int left = i + 1;
                int right = n - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        // Convert triplet to a string for unique checking
                        string triplet = $"{nums[i]},{nums[left]},{nums[right]}";
                        if (!set.Contains(triplet))
                        {
                            set.Add(triplet);
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        }
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return result; // Return the final list of triplets
        }

        /*
         Complexity Analysis:
            Time Complexity:

            Sorting the Array: O(n log n), where n is the number of elements in the array.
            Two-Pointer Traversal: O(n^2). For each element, we potentially traverse the rest of the array using the two pointers.
            Overall: O(n log n) + O(n^2), which is asymptotically equivalent to O(n^2).
            Space Complexity:

            O(1) (ignoring the output list). The space used does not depend on the size of the input array as we are not using any additional data structures that scale with input size.
            This solution efficiently finds all unique triplets in the array that give the sum of zero, avoiding duplicates and significantly reducing the runtime for large inputs.
         */
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums); // Sort the array to enable the two-pointer approach
            IList<IList<int>> res = new List<IList<int>>();
            int n = nums.Length;

            for (int i = 0; i < n - 2; i++)
            {
                // Avoid duplicates: skip the same value for 'i' to prevent duplicate triplets
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                // Two pointers approach starts here
                int left = i + 1, right = n - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    // Check if the sum is zero
                    if (sum == 0)
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Move pointers and skip over duplicates to avoid duplicate triplets
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        // Move pointers after processing to find other combinations
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        // If the sum is less than zero, move the left pointer to increase the sum
                        left++;
                    }
                    else
                    {
                        // If the sum is greater than zero, move the right pointer to decrease the sum
                        right--;
                    }
                }
            }

            return res;
        }
    }
}
