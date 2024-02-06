using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class RotateString
    {
        public static string RotateLeft(string input, int positions)
        {
            if (string.IsNullOrEmpty(input) || positions < 1)
            {
                return input;
            }

            positions = positions % input.Length; // Ensure the positions is within the string's bounds
            string leftPart = input.Substring(0, positions);
            string rightPart = input.Substring(positions);

            return rightPart + leftPart;
        }
        public static string RotateRight(string input, int positions)
        {
            if (string.IsNullOrEmpty(input) || positions < 1)
            {
                return input;
            }

            positions = positions % input.Length; // Ensure the positions is within the string's bounds
            string leftPart = input.Substring(0, input.Length - positions);
            string rightPart = input.Substring(input.Length - positions);

            return rightPart + leftPart;
        }
        public static string reverse(string str)
        {
            char[] chars = str.ToCharArray();
            int left = 0; 
            int right = chars.Length - 1;
            while (left < right)
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }
            return new string(chars);
        }
        public static string ReverseStringUsingStringBuilder(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
        public static string ReverseStringUsingArrayReverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string ReverseStringUsingLinq(string str)
        {
            return new string(str.Reverse().ToArray());
        }





        // split each word of a string 
        //Remember, StringSplitOptions.RemoveEmptyEntries is used to ensure that if there are multiple consecutive delimiters (like multiple spaces), they won't result in empty strings being included in the resulting array of words.
        public static string[] GetWordsFromString(string sentence)
        {
            // Split the sentence by spaces
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries); //This method splits a string into an array of strings based on specified delimiter characters.
            return words;
        }
        // If you want to split by multiple characters, such as spaces, commas, periods, and other punctuation marks, you can specify all those characters in the Split method:
        public static string[] GetWordsFromStringIncludingPunctuation(string sentence)
        {
            char[] delimiters = new char[] { ' ', ',', '.', ';', ':', '!', '?' };
            string[] words = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        /*
         To join an array of strings back into a single string or sentence in C#, you can use the string.Join method. 
        This method concatenates an array or enumerable of strings, inserting a specified separator between the elements. 
        This is particularly useful when you want to create a sentence from an array of words, possibly inserting spaces or 
        commas as separators.
         */
        public static string JoinWordsIntoSentence(string[] words)
        {
            // Join the array of words using a space as the separator
            string sentence = string.Join(" ", words);
            return sentence;
        }
        // If you want to include a different separator, such as a comma and a space, you can easily change the first argument to the string.Join method:
        public static string JoinWordsWithComma(string[] words)
        {
            // Join the array of words using a comma and a space as the separator
            string sentence = string.Join(", ", words);
            return sentence;
        }

    }
}
