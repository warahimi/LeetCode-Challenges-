using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion_Subset_Subsequence_String_Questions
    {
        // given a string containing letter a's , remove all the a's and return a new string without a's
        
        // using string builder object 
        public string removeAllA(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (c == 'a' || c == 'A')
                    continue;
                sb.Append(c);
            }
            return sb.ToString();
        }
        /*
         The Replace() method in C# is a string method used to replace all occurrences of a specified substring or 
        character within the string with another specified substring or character. It's part of the System.String 
        class and is very useful for modifying strings.
         */
        public string removeAllA2(string input)
        {
            return input.Replace("a", "").Replace("A", ""); // Removes both lowercase and uppercase 'a'
        }

        // Removing All A using recursion 
        public string removeAllARec(string input)
        {
            return removeAllARecHelper(input, new StringBuilder(), 0).ToString();
        }
        private StringBuilder removeAllARecHelper(string input, StringBuilder sb, int index)
        {
            if(index == input.Length)
            {
                return sb;
            }
            if (input[index] == 'a' || input[index] == 'A')
            {
                return removeAllARecHelper(input, sb, index+1);
            }
            return removeAllARecHelper(input, sb.Append(input[index]), index+1);
        }

        // without using extra space
        public string removeAllARec2(string input)
        {
            return RemoveAllAHelper(input, 0);
        }

        // Recursive helper method
        private static string RemoveAllAHelper(string input, int index)
        {
            // Base case: if index reaches the end of the string
            if (index == input.Length)
            {
                return "";
            }

            // Current character
            char currentChar = input[index];

            // If current character is 'a' or 'A', do not include it in the result
            if (currentChar == 'a' || currentChar == 'A')
            {
                return RemoveAllAHelper(input, index + 1);
            }
            else // Include the current character and continue recursion
            {
                return currentChar + RemoveAllAHelper(input, index + 1);
            }
        }
    }
}
