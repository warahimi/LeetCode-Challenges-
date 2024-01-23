using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Remove_a_Sub_String_from_String
    {
        public string removeString(string str, string skip)
        {
            if(str == "")
            {
                return "";
            }
            if (str.StartsWith(skip))
            {
                return removeString(str.Substring(skip.Length), skip); // skip the entir length of skip
            }
            else
            {

                return str[0] + removeString(str.Substring(1), skip); // return the first char an remove the first char for next recursive call 
            }
        }
        public string removeString2(string str, string skip)
        {
            return removeString2Helper(str, skip);
        }
        private string removeString2Helper(string str, string skip, string result = "") 
        {
            if(string.IsNullOrEmpty(str))
            {
                return result;
            }
            if (str.StartsWith(skip))
            {
                return removeString2Helper(str.Substring(skip.Length), skip, result);
            }
            else
            {
                return removeString2Helper(str.Substring(1), skip, result + str[0]);
            }
        }

        /*
         It uses IndexOf to find the first occurrence of skip in str.
If skip is not found (IndexOf returns -1), the base case is reached and the current string is returned as it is.
If skip is found, the function constructs a new string without the found occurrence of skip and calls itself recursively with this new string.
         */
        static string removeString3(string str, string skip)
        {
            int index = str.IndexOf(skip);

            if (index == -1)
            {
                // Base case: the substring is not found
                return str;
            }
            else
            {
                // Recursive case: remove the found substring and continue
                return removeString3(str.Substring(0, index) + str.Substring(index + skip.Length), skip);
            }
        }



        // with out using the Substring method 
        // Main recursive function to remove all occurrences of 'skip' from 'str'
        public string RemoveSubstring(string str, string skip)
        {
            int skipLength = skip.Length;
            // Find the first occurrence of 'skip' in 'str'
            int index = FindSubstring(str, skip, 0);

            if (index == -1)
            {
                // If 'skip' is not found, return the original string
                return str;
            }
            else
            {
                // If 'skip' is found, remove it and recursively call the function
                return RemoveSubstring(str.Remove(index, skipLength), skip);
            }
        }

        // Helper function to find the index of the first occurrence of 'skip' in 'str'
        static int FindSubstring(string str, string skip, int startIndex)
        {
            // Iterate through 'str' starting from 'startIndex'
            for (int i = startIndex; i <= str.Length - skip.Length; i++)
            {
                int j;
                // Check if 'skip' is found at the current index 'i'
                for (j = 0; j < skip.Length; j++)
                {
                    if (str[i + j] != skip[j])
                    {
                        // If any character doesn't match, break and check the next position
                        break;
                    }
                }
                // If the entire 'skip' string is found, return the start index
                if (j == skip.Length)
                {
                    return i;
                }
            }
            // Return -1 if 'skip' is not found
            return -1;
        }

        /*
         Remember, for large strings, a recursive solution might not be the most efficient in terms of performance and memory
        usage, so consider this when choosing an approach for your specific use case.

        For larger strings, an iterative approach is often more efficient than a recursive one, as it avoids the overhead 
        associated with recursive calls and the risk of stack overflow errors. A good iterative approach for removing all 
        occurrences of a substring from a string in C# would typically involve looping over the string and building a new 
        string without the specified substring.
         */

        public string RemoveSubstring2(string str, string skip)
        {
            StringBuilder result = new StringBuilder();
            int skipLength = skip.Length;
            int currentIndex = 0;

            while (currentIndex < str.Length)
            {
                int nextIndex = str.IndexOf(skip, currentIndex);
                if (nextIndex != -1)
                {
                    // Append the part of the string before the skip substring
                    result.Append(str, currentIndex, nextIndex - currentIndex);
                    // Skip over the substring
                    currentIndex = nextIndex + skipLength;
                }
                else
                {
                    // Append the rest of the string as no more occurrences of skip are found
                    result.Append(str, currentIndex, str.Length - currentIndex);
                    break;
                }
            }

            return result.ToString();
        }
    }
}
