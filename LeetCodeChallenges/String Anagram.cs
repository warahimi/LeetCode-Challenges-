using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class String_Anagram
    {
        public bool AreAnagrams(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            // Remove any whitespace and convert strings to lowercase
            str1 = str1.Replace(" ", "").ToLower(); // O(n)
            str2 = str2.Replace(" ", "").ToLower(); // O(n)

            // Check if lengths are different
            if (str1.Length != str2.Length)
                return false;

            // Convert strings to character arrays
            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();

            // Sort the character arrays
            Array.Sort(charArray1); // O(N log N)
            Array.Sort(charArray2); // O(N log N)

            // Compare sorted arrays character by character
            for (int i = 0; i < charArray1.Length; i++) // O(N)
            {
                if (charArray1[i] != charArray2[i])
                    return false;
            }

            return true;
        }

        /*
            Yes, the time complexity of the AreAnagrams function can be optimized by using a different approach. 
            Instead of sorting the characters of each string, which incurs an O(N log N) complexity, we can count the frequency 
            of each character in both strings and then compare these frequencies. This method works under the assumption that the 
            character set is relatively small and fixed, like the ASCII character set.
         */
        public bool AreAnagrams2(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            str1 = str1.Replace(" ", "").ToLower();
            str2 = str2.Replace(" ", "").ToLower();

            if (str1.Length != str2.Length)
                return false;

            int[] charCounts = new int[256]; // Assuming ASCII characters

            // Count characters in str1
            foreach (char c in str1)
            {
                charCounts[c]++;
            }

            // Subtract the count for characters in str2
            foreach (char c in str2)
            {
                charCounts[c]--;

                // If count goes negative, strings are not anagrams
                if (charCounts[c] < 0)
                    return false;
            }

            return true;
        }
    }
}
