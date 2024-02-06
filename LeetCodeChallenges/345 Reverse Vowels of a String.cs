using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _345_Reverse_Vowels_of_a_String
    {
        public string ReverseVowels(string s)
        {
            List<char> vowels = new List<char>
        {
            'a','e','i','o','u','A','E','I','O','U'
        };
            char[] charArr = s.ToCharArray();
            int left = 0;
            int right = charArr.Length - 1;
            while (left < right)
            {
                if (!vowels.Contains(charArr[left]))
                {
                    left++;
                    continue;
                }
                if (!vowels.Contains(charArr[right]))
                {
                    right--;
                    continue;
                }
                else
                {
                    char temp = charArr[right];
                    charArr[right] = charArr[left];
                    charArr[left] = temp;
                    left++;
                    right--;
                }
            }
            return new string(charArr);
        }

        // Helper method to check if a character is a vowel
        private bool IsVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }

        public string ReverseVowels2(string s)
        {
            // Convert the string to a character array for easy manipulation
            char[] chars = s.ToCharArray();
            int left = 0; // Start pointer
            int right = s.Length - 1; // End pointer

            while (left < right)
            {
                // Move the left pointer until a vowel is found
                while (left < right && !IsVowel(chars[left]))
                {
                    left++;
                }
                // Move the right pointer until a vowel is found
                while (left < right && !IsVowel(chars[right]))
                {
                    right--;
                }
                // Swap the vowels
                if (left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;

                    // Move both pointers towards the center
                    left++;
                    right--;
                }
            }

            // Convert the character array back to a string and return it
            return new string(chars);
        }

        public string ReverseVowels3(string s)
        {
            var foundVowels = new Stack<char>();
            var sReplacement = new StringBuilder(s);
            foreach (var currentChar in s)
            {
                if (Vowels.Contains(currentChar))
                    foundVowels.Push(currentChar);
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (Vowels.Contains(s[i]))
                    sReplacement[i] = foundVowels.Pop();
            }
            return sReplacement.ToString();
        }

        public HashSet<char> Vowels = new HashSet<char>() {
        'a', 'e', 'i', 'o', 'u',
        'A', 'E', 'I', 'O', 'U'
            };
    }
}
