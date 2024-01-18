using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _424_Longest_Repeating_Character_Replacement
    {
        public int CharacterReplacement(string s, int k)
        {
            // Dictionary to store the count of each character in the current window
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            int left = 0; // Left pointer for the sliding window
            int maxCount = 0; // Maximum count of a single character in the current window
            int maxLength = 0; // Result to store the max length of substring

            for (int right = 0; right < s.Length; right++)
            {
                // Increase the count of the rightmost character
                if (charCount.ContainsKey(s[right]))
                {
                    charCount[s[right]]++;
                }
                else
                {
                    charCount[s[right]] = 1;
                }

                // Update maxCount if the count of the current character is greater
                maxCount = Math.Max(maxCount, charCount[s[right]]);

                // Check if the current window size minus the count of the most frequent character
                // is greater than k, if so, shrink the window from the left
                if (right - left + 1 - maxCount > k)
                {
                    charCount[s[left]]--; // Decrease the count of the leftmost character
                    left++; // Move the left pointer
                }

                // Update the maxLength with the size of the current window
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}
