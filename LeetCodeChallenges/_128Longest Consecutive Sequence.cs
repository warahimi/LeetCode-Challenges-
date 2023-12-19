using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _128Longest_Consecutive_Sequence
    {
        //Brute Forece O(nlogn)
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            Array.Sort(nums);
            int maxLength = 1;
            int curLength = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    continue;
                }
                if (nums[i] + 1 == nums[i + 1])
                {
                    curLength++;
                    maxLength = Math.Max(curLength, maxLength);
                }
                else
                {
                    curLength = 1;
                }
            }
            return maxLength;
        }

        //Using Dictionary/map/hashmap
        // O(n) time O(n) space
        public int LongestConsecutive2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            Dictionary<int, Boolean> exploredNum = new Dictionary<int, Boolean>();
            int longestLength = 0;
            foreach (int num in nums)
            {
                exploredNum[num] = false; // num is not explored 
            }

            foreach (int num in nums)
            {
                exploredNum[num] = true; // explored
                int curLength = 1;
                //Exploring in forward direction 
                int nextNum = num + 1;
                while (exploredNum.ContainsKey(nextNum) && exploredNum[nextNum] == false)
                {
                    curLength++;
                    exploredNum[nextNum] = true; // nextNum is explored 
                    // move to the next consecutive number
                    nextNum++;
                }
                //explore in backware direction
                int prevNum = num - 1;
                while (exploredNum.ContainsKey(prevNum) && exploredNum[prevNum] == false)
                {
                    curLength++;
                    exploredNum[prevNum] = true;

                    // move backward
                    prevNum--;
                }

                longestLength = Math.Max(longestLength, curLength);
            }
            return longestLength;
        }

        // using HashSet / set
        public int LongestConsecutive3(int[] nums)
        {
            // If the array is empty, return 0 as there are no sequences.
            if (nums.Length == 0)
            {
                return 0;
            }

            // Use a HashSet to store the numbers for efficient O(1) look-ups.
            // This helps in quickly determining if a consecutive number exists.
            HashSet<int> numSet = new HashSet<int>(nums);
            int longestLength = 0; // This will keep track of the longest sequence found.

            // Iterate through each number in the set.
            foreach (int num in numSet)
            {
                // Check if the current number is the start of a sequence.
                // It's the start of a new sequence if the previous number (num - 1) is not in the set.
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num; // The current number to extend the sequence from.
                    int curLength = 1; // Length of the current sequence, starts with 1.

                    // Keep extending the sequence forward.
                    // Check if the next consecutive number (currentNum + 1) is in the set.
                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++; // Move to the next number in the sequence.
                        curLength++; // Increment the length of the current sequence.
                    }

                    // Update the longest sequence length if the current sequence is longer.
                    longestLength = Math.Max(longestLength, curLength);
                }
            }

            // After checking all numbers, return the length of the longest sequence found.
            return longestLength;
        }
    }
}
