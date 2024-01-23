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
        /*Combination*/
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
        public string removeAllA_(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (c == 'a' || c == 'A')
                    continue;
                result += c;
            }
            return result;
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

        // given a string skip a substring of that 
        public string skipString(string input, string skip)
        {
            string[] strArr = input.Split(" ");
            string result = "";
            foreach(string str in strArr)
            {
                if(str == skip)
                {
                    continue;
                }
                result += str+" ";
            }
            return result;
        }
        public string skipString2(string input, string skip)
        {
            return input.Replace(skip, ""); // Replaces all occurrences of 'skip' with an empty string
        }

        public string skipString3(string input, string skip)
        {
            if (string.IsNullOrEmpty(skip))
            {
                return input;
            }

            StringBuilder result = new StringBuilder();
            int index = 0;

            while (index < input.Length)
            {
                // Check if the substring at the current position matches 'skip'
                if (index <= input.Length - skip.Length && input.Substring(index, skip.Length) == skip)
                {
                    // Skip over the length of 'skip'
                    index += skip.Length;
                }
                else
                {
                    // Add the current character to the result
                    result.Append(input[index]);
                    index++;
                }
            }

            return result.ToString();
        }

        public string skipStringRec(string input, string skip)
        {
            return skipStringRecHelper(input.Split(), skip, 0, "");
        }
        private string skipStringRecHelper(string[] strArr, string skip, int index, string result)
        {
            if(index > strArr.Length-1)
            {
                return result;
            }
            if (strArr[index] == skip)
            {
                return skipStringRecHelper(strArr, skip, index + 1, result);
            }
            else
            {
                return skipStringRecHelper(strArr, skip, index + 1, result + strArr[index] +" ");
            }
        }

        public string skipStringRec2(string input, string skip)
        {
            // Call to the recursive helper function
            return RemoveSubstringHelper(input, skip, 0);
        }

        // Recursive helper method
        private static string RemoveSubstringHelper(string input, string skip, int startIndex)
        {
            // Base case: If we've reached the end of the input string
            if (startIndex >= input.Length)
            {
                return "";
            }

            // Check if the substring at the current position matches 'skip'
            if (startIndex <= input.Length - skip.Length && input.Substring(startIndex, skip.Length) == skip)
            {
                // Skip over the length of 'skip' and continue recursion
                return RemoveSubstringHelper(input, skip, startIndex + skip.Length);
            }
            else
            {
                // Include the current character and continue recursion
                return input[startIndex] + RemoveSubstringHelper(input, skip, startIndex + 1);
            }
        }


        /*
         * Sub set string and sub set array questions (sub sequences)
         * some thing dealing with permutationa and combination 
         * 
         * sub set means non adjacent collection 
         * 
         * given an array [3,5,9] all the sub set are : [], [3], [5], [9], [3, 5], [3, 9], [5, 9], [3, 5, 9]
            
        For an array with n elements, there will be 2^N subsets, including the empty set and the set itself.

        Empty Subset: This is always a subset of any set.
        []
        Subsets with One Element: These are the subsets containing only a single element from the array.

        [3]
        [5]
        [9]
        Subsets with Two Elements: These subsets are formed by combining two elements from the array.

        [3, 5]
        [3, 9]
        [5, 9]
        Subset with All Three Elements: This is the subset that contains all elements of the array.

        [3, 5, 9]

        we select consecutive and non consecutive elements 
         * 
         */
    }
}
