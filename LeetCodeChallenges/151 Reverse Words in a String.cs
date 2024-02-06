using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _151_Reverse_Words_in_a_String
    {

        /*
         Trim Leading and Trailing Spaces: Remove any spaces at the beginning and end of the input string to handle cases where the input may have unnecessary spaces.
Split the Words: Use string.Split to divide the string into an array of words, eliminating spaces.
Reverse the Array: Reverse the order of words in the array to achieve the desired word order in the final string.
Join the Words: Use string.Join to concatenate the reversed array of words into a single string, inserting a single space between each word.
         */

        public static string ReverseWords(string s)
        {
            // 1. Trim leading and trailing spaces
            s = s.Trim();

            // 2. Split the words, removing any extra spaces between words
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 3. Reverse the array of words
            Array.Reverse(words);

            // 4. Join the words into a single string with a space as separator
            string reversedSentence = string.Join(" ", words);

            return reversedSentence;
        }

        public string ReverseWords3(string s)
        {
            string[] splitString = s.Split(' ');
            Array.Reverse(splitString);
            string finalString = string.Empty;

            for (int i = 0; i < splitString.Length; i++)
            {
                finalString = finalString.Trim() + " " + splitString[i];
            }
            return finalString.Trim();

        }
        public string ReverseWords2(string s)
        {
            s = s.Trim();
            s = reverse(s);
            string[] arrStr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = reverse(arrStr[i]);
            }
            return string.Join(' ', arrStr);

        }
        private string reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
