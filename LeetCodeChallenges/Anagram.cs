using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class Anagram
    {
        public bool isAnagram(string s1, string s2)
        {
            if(s1.Length != s2.Length) return false;
            if(s1 == s2) return true;

            // Remove any white space and convert strings to lowercase
            s1 = new string(s1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            s2 = new string(s2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            int[] map = new int[26];
            foreach(char c in s1)
            {
                map[c - 'a']++;
            }
            foreach(char c in s2)
            {
                map[c - 'a']--;
            }
            foreach(int i in map)
            {
                if (i != 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Function to check if two strings are anagrams
        public static bool AreAnagrams(string str1, string str2)
        {
            // Remove any white space and convert strings to lowercase
            str1 = new string(str1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            str2 = new string(str2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();

            // If the length of strings is different, they cannot be anagrams
            if (str1.Length != str2.Length)
            {
                return false;
            }

            // Count the frequency of each character in the first string
            var charCount = new int[256]; // Assuming ASCII characters
            foreach (char c in str1)
            {
                charCount[c]++;
            }

            // Subtract the frequency based on the second string
            foreach (char c in str2)
            {
                charCount[c]--;
            }

            // Check if all counts are zero
            return charCount.All(count => count == 0);
        }
    }
}
