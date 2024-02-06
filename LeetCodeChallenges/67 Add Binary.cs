using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _67_Add_Binary
    {
        public class Solution
        {
            public string AddBinary(string a, string b)
            {
                int i = a.Length - 1; // Initialize index for string a
                int j = b.Length - 1; // Initialize index for string b
                int carry = 0; // Initialize carry value
                StringBuilder result = new StringBuilder(); // To store the result

                // Iterate through both strings from right to left
                while (i >= 0 || j >= 0)
                {
                    int sum = carry; // Start with the current carry value

                    if (i >= 0)
                    {
                        sum += a[i] - '0'; // Add the current digit from string a
                        i--;
                    }

                    if (j >= 0)
                    {
                        sum += b[j] - '0'; // Add the current digit from string b
                        j--;
                    }
                    char c = Convert.ToChar(sum % 2);
                    result.Insert(0, c); // Insert the least significant bit of the sum at the beginning of the result
                    //result.Insert(0, sum % 2); // Insert the least significant bit of the sum at the beginning of the result
                    carry = sum / 2; // Update carry for the next iteration
                }

                // If there's still a carry left after iterating through both strings
                if (carry > 0)
                {
                    result.Insert(0, carry);
                }

                return result.ToString(); // Convert the StringBuilder to a string and return the result
            }


            // Method to add two binary strings and return the result as a binary string.
            public string AddBinary2(string a, string b)
            {
                // This will hold the result of the binary addition.
                string result = "";
                // This variable is used to carry the 1 in case of a sum like 1+1 in binary.
                int carry = 0;

                // Calculate the length of the longer string between a and b
                // and pad the shorter one with leading zeros to match this length.
                int maxLength = Math.Max(a.Length, b.Length);
                a = a.PadLeft(maxLength, '0');
                b = b.PadLeft(maxLength, '0');

                // Start from the end of both strings and iterate backwards.
                for (int i = maxLength - 1; i >= 0; i--)
                {
                    // Convert binary character to integer by subtracting '0'.
                    int digitA = a[i] - '0';
                    int digitB = b[i] - '0';

                    // Add both digits along with the carry from the previous addition.
                    int total = digitA + digitB + carry;
                    // Compute the bit to place in the result (0 or 1).
                    /*
                     The result of total % 2 is a numeric value (0 or 1), but in C#, characters are represented by their ASCII values. The ASCII value for the character '0' is 48, and for '1', it is 49.

When you add '0' (which is shorthand for its ASCII value, 48) to the numeric result of total % 2, you get either 48 or 49, which are the ASCII values for the characters '0' and '1', respectively.

Finally, (char) is a cast that tells the compiler to treat the numeric ASCII value as a character.
                     */
                    char charResult = (char)((total % 2) + '0'); //convert a numerical digit (0 or 1) to its corresponding character representation ('0' or '1').
                    // Prepend the computed bit to the result string.
                    result = charResult + result;
                    // Calculate the new carry (either 0 or 1).
                    carry = total / 2;
                }

                // If there is a carry left after the final addition, prepend it to the result.
                if (carry > 0)
                {
                    result = "1" + result;
                }

                // Return the binary sum as a string.
                return result;
            }
        }

    }
}

/*
string original = "1001";
string padded = original.PadLeft(8, '0'); // result is "00001001"

string original = "1001";
string padded = original.PadRight(8, '0'); // result is "10010000"

 */

/*
In C#, you can convert a character representing a number to its integer value by subtracting the character '0' from it. 
Here's how you can do it:

csharp
Copy code
char charNumber = '1'; // This could be any digit from '0' to '9'
int number = charNumber - '0'; // Subtracting '0' converts the character to the corresponding integer value.
When you subtract '0', which has an ASCII value of 48, from the character '1', which has an ASCII value of 49, 
the result is the integer 1. This works for any character representing a single digit because the ASCII values of '0' through
'9' are sequentially ordered from 48 to 57.

For example:

csharp
Copy code
char charNine = '9';
int numberNine = charNine - '0'; // The result is the integer 9.
This code will convert the character '9' to the integer 9. The subtraction works because '9' has an ASCII value of 57 and '0'
has an ASCII value of 48, so 57 - 48 = 9.
 */