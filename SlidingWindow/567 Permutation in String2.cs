using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class _567_Permutation_in_String2
    {
        /*
         * it is just a sliding window technique we just want to take a look at a window of size s1 in s2 and see that if that window 
         * is an anagram of the s1 
         * our goal is to find any sub string of s2 that is anagram of s1
         */
        public bool CheckInclusion(string s1, string s2) // O(m + 26 n)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }
            int[] s1Hash = new int[26];
            int[] s2WindowHash = new int[26];
            int k = s1.Length;
            int end = 0;
            foreach (char c in s1)
            {
                s1Hash[c - 'a']++;
            }
            for (int i = 0; i < k; i++) // filling the first window
            {
                s2WindowHash[s2[i] - 'a']++;
            }
            for (int start = k; start < s2.Length; start++)
            {
                if (areEqual(s1Hash, s2WindowHash))
                {
                    return true;
                }
                s2WindowHash[s2[start] - 'a']++;
                s2WindowHash[s2[end] - 'a']--;
                end++;
            }
            // checking the final window if that is a premutation of S1
            if (areEqual(s1Hash, s2WindowHash))
            {
                return true;
            }
            return false;
        }

        // a little optimization O(n)
        public bool CheckInclusion2(string s1, string s2)
        {
            int[] s1Hash = new int[26];
            int[] s2Hash = new int[26];
            int s1Len = s1.Length;
            int s2Len = s2.Length;

            if (s1Len > s2Len)
                return false; // s2 can't contain any permutation of s1 if length of s2 is less than s1

            int left = 0, right = 0;
            while (right < s1Len)
            {
                s1Hash[s1[right] - 'a']++;
                s2Hash[s2[right] - 'a']++;
                right++;
            }

            right--; // to point right to the end of the window
            while (right < s2Len)
            {
                if (areEqual(s1Hash, s2Hash))
                    return true;

                right++;
                if (right != s2Len)
                    s2Hash[s2[right] - 'a']++;
                s2Hash[s2[left] - 'a']--;
                left++;
            }

            return false;
        }
        private bool areEqual(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
