using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _392_Is_Subsequence
    {
        public bool IsSubsequence(string s, string t)
        {
            if (s == "")
            {
                return true;
            }
            if (s.Length > t.Length)
            {
                return false;
            }
            int j = 0;
            for (int i = 0; i < t.Length; i++)
            {

                if (t[i] == s[j]) // if found a match , increment the j pointer 
                {
                    if (j == s.Length - 1) // if j reaches end of the s, means we found all characters of s in t, return true 
                    {
                        return true;
                    }
                    j++;
                }
            }
            return false;
        }

        public bool IsSubsequence2(string s, string t)
        {
            int sIndex = 0, // 
                tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }
                tIndex++;
            }
            return sIndex == s.Length;
        }
        public bool IsSubsequence3(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;

            int sIndex = 0;
            for (int index = 0; index < t.Length && sIndex < s.Length; index++)
            {
                if (t[index] == s[sIndex])
                    sIndex++;

                if (sIndex == s.Length)
                    return true;
            }

            return false;
        }
    }
}
