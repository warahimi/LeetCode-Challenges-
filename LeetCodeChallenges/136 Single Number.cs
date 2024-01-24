using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    /*
     Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

 

Example 1:

Input: nums = [2,2,1]
Output: 1
Example 2:

Input: nums = [4,1,2,1,2]
Output: 4
Example 3:

Input: nums = [1]
Output: 1
     */

    /*
     we can use the XOR operator 
    any number XOR to itself will be zero 
    1 ^ 1 = 0 
    x ^ x = 0

    any number xor zero will be that number , this way we can find the one odd or single element , all other couple elements 
    will lead to 0 using xor
    1 ^ 0 = 1 
    x ^ 0 = x

    so we basically loop through elemnets of array and xor all the elements and store the result in a vaiable 
    all the pairs will be 0 and 0 ^ the single eleemnt = the single element 
     */
    internal class _136_Single_Number
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (int i in nums)
            {
                result = result ^ i;
            }
            return result;
        }

        public int SingleNumber2(int[] nums)
        {
            List<int> list = new List<int>();
            foreach (int i in nums)
            {
                if(list.Contains(i))
                {
                    list.Remove(i);
                }
                else
                {
                    list.Add(i);
                }
            }
            return list[0];
        }
    }
}
