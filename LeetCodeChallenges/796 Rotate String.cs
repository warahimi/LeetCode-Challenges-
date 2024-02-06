using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given two strings s and goal, return true if and only if s can become goal after some number of shifts on s.

A shift on s consists of moving the leftmost character of s to the rightmost position.

For example, if s = "abcde", then it will be "bcdea" after one shift.
 

Example 1:

Input: s = "abcde", goal = "cdeab"
Output: true
Example 2:

Input: s = "abcde", goal = "abced"
Output: false
 */
namespace LeetCodeChallenges
{
    internal class _796_Rotate_String
    {
        public bool RotateString(string s, string goal)
        {
            if (s == goal)
            {
                return true;
            }
            int size = s.Length;
            while (size > 1)
            {
                string firstLetter = s.Substring(0, 1);
                string rest = s.Substring(1);
                s = rest + firstLetter;
                if (s == goal)
                {
                    return true;
                }
                size--;
            }
            return false;
        }
        /*
        To solve this problem efficiently, you can use a single line of code by checking if goal is a substring of s + s.
        This works because if goal can be obtained by shifting s, then goal will always be a substring of s + s.
        This method is highly optimized as it avoids manual string rotation and leverages the built-in string search 
        operation, which is usually very efficient
         
         */
        public bool RotateString2(string s, string goal)
        {
            // Check if s and goal are of the same length and if goal is a substring of s+s
            // This works because concatenating s with itself creates a superstring
            // that contains all possible rotations of s as its substrings.
            // If goal is one of s's rotations, it will appear in this superstring.
            return s.Length == goal.Length && (s + s).Contains(goal); // This checks if goal is a substring of s + s. If s can be rotated to form goal, then goal will appear within s + s as a contiguous sequence.
        }
    }
}
