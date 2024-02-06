using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 */
namespace LeetCodeChallenges
{
    internal class _28_Find_the_Index_of_the_First_Occurrence_in_a_String
    {
        public int StrStr(string haystack, string needle)
        {
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Substring(i).StartsWith(needle))
                {
                    return i;
                }
            }
            return -1;
        }
        // Method to find the index of the first occurrence of a substring in a string
        public static int FindSubstringIndex(string mainString, string substring)
        {
            // Use IndexOf method to find the index of the first occurrence of the substring
            int index = mainString.IndexOf(substring);

            // IndexOf returns -1 if the substring is not found, otherwise returns the index of the first occurrence
            return index;
        }

        // Method to manually find the index of the first occurrence of needle in haystack
        public static int StrStr2(string haystack, string needle)
        {
            // Edge case: If needle is empty, return 0
            if (string.IsNullOrEmpty(needle)) return 0;

            // Main loop to iterate over haystack
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                // Assume found is true at the beginning of each iteration
                bool found = true;

                // Inner loop to match needle with a substring in haystack starting at i
                for (int j = 0; j < needle.Length; j++)
                {
                    // If any character does not match, set found to false and break out of the loop
                    if (haystack[i + j] != needle[j])
                    {
                        found = false;
                        break;
                    }
                }

                // If needle was found in haystack, return the starting index
                if (found) return i;
            }

            // If needle was not found in haystack, return -1
            return -1;
        }
    }
}
