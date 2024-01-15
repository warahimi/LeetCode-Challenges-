using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _3_Longest_Substring_Without_Repeating_Characters
    {
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int end = 0;
            int count = 0;
            HashSet<int> set = new HashSet<int>();

            while (end < s.Length)
            {
                if (!set.Contains(s[end])) 
                {
                    set.Add(s[end]); // add the unique characters
                    end++;
                    count = Math.Max(count, set.Count);
                }
                else // if we found a duplicate remove it from list and in next round add the repeated back 
                {
                    // shrinking the window 
                    set.Remove(s[start]);
                    start++;
                }
            }
            return count;
        }
    }
}
