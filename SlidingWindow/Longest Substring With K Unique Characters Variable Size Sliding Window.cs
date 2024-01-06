using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given a string you need to print the size of the longest possible substring that has exactly K unique characters. 
 * If there is no possible substring then print -1.
    Example 1:

    Input:
    S = "aabacbebebe", K = 3
    Output: 
    7
    Explanation: 
    "cbebebe" is the longest substring with 3 distinct characters.
    Example 2:

    Input: 
    S = "aaaa", K = 2
    Output: -1
    Explanation: 
    There's no substring with 2 distinct characters. 

        https://www.youtube.com/watch?v=FsIyn_oe3eo
 */
namespace SlidingWindow
{
    internal class Longest_Substring_With_K_Unique_Characters_Variable_Size_Sliding_Window // variable sized window 
    {
        // brue force 

        public int longestKSubstr2(string s, int k)
        {
            int longestLen = -1; // Initialize the longest length as -1 (indicating no valid substring found yet)

            // Outer loop: Start of the substring
            for (int start = 0; start < s.Length; start++)
            {
                HashSet<char> uniqueChars = new HashSet<char>(); // A set to store unique characters in the current substring

                // Inner loop: End of the substring
                for (int end = start; end < s.Length; end++)
                {
                    uniqueChars.Add(s[end]); // Add the current character to the set of unique characters

                    // Check if the current substring has exactly k unique characters
                    if (uniqueChars.Count == k)
                    {
                        // Update the longest length if the current substring is longer
                        longestLen = Math.Max(longestLen, end - start + 1);
                    }

                    // If the number of unique characters exceeds k, break the inner loop
                    if (uniqueChars.Count > k)
                    {
                        break;
                    }
                }
            }

            return longestLen; // Return the longest length found
        }

        public int longestKSubstr(string s, int k)
        {
            int longestLen = -1;
            int i = 0; 
            int j = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            while (j < s.Length)
            {
                if (map.ContainsKey(s[j]))
                {
                    map[s[j]]++;
                }
                else
                {
                    map[s[j]] = 1;
                }

                while(map.Count > k) // slide / shrink the window until there more characters in map than k
                {
                    map[s[i]]--;
                    if (map[s[i]] == 0)
                    {
                        map.Remove(s[i]);
                    }
                    i++;
                }
                if(map.Count == k)
                {
                    longestLen = Math.Max(longestLen, j-i+1);
                }
                j++;
            }

            return longestLen;
        }

        public int longestSubStr(string s, int k)
        {
            int longestLen = -1;

            for(int i = 0; i < s.Length; i++)
            {
                HashSet<char> set = new HashSet<char>();

                for (int j = i; j < s.Length; j++)
                {
                    set.Add(s[j]);
                    if(set.Count == k)
                    {
                        longestLen = Math.Max(longestLen, j-i+1);
                    }
                    if(set.Count > k)
                    {
                        break;
                    }
                }
            }
            return longestLen;
        }

        public int longestSubStr2(string s, int k)
        {
            int longestLen = -1;
            int i = 0; 
            int j = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            while(j < s.Length)
            {
                if (map.ContainsKey(s[j]))
                {
                    map[s[j]]++;
                }
                else
                {
                    map.Add(s[j], 1);
                }

                if(map.Count == k )
                {
                    longestLen = Math.Max(longestLen, j - i + 1);
                }
                while(map.Count > k)
                {
                    map[s[i]]--;
                    if (map[s[i]] == 0)
                    {
                        map.Remove(s[i]);
                    }
                    i++;
                }
                j++;
            }
            return longestLen;
        }

    }
}
