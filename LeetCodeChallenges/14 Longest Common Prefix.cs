using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 */
namespace LeetCodeChallenges
{
    /*
     the length of the longest common prefix cannot exceed the length of the shortes string in the given array of strings

     */
    internal class _14_Longest_Common_Prefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            int shortesIndex = 0;
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < strs[shortesIndex].Length)
                {
                    shortesIndex = i;
                }
            }
            string result = "";
            bool flag = false;
            for (int i = 0; i < strs[shortesIndex].Length; i++)
            {
                foreach (string str in strs)
                {
                    if (str[i] != strs[shortesIndex][i])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                result += strs[shortesIndex][i];
            }
            return result;
        }

        // Optimized solution 
        // first sort the given array of strings and compare the first and last string and see howmany letters they have in 
        // common 
        public string LongestCommonPrefix2(string[] strs) // O(n log n)
        {
            Array.Sort(strs);
            string result = "";
            for (int i = 0; i < strs[0].Length; i++) // comparing the first and last string of sorted array and find out the commond letters among them 
            {
                if (strs[0][i] != strs[strs.Length - 1][i])
                {
                    break;
                }
                result += strs[0][i];
            }
            return result;
        }
    }
}
