using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.


Example 1:

Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.
Example 2:

Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.
Example 3:

Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.
 */
namespace LeetCodeChallenges
{
    internal class _268_Missing_Number
    {
        // brute force since numbers in array is 0 - n, take a counter that starts from 0 t0 n and each time you increament the counter
        //travers the entire array and see if counter is present in the array of not return the counter 

        public int MissingNumberBrute(int[] nums) // O(n^2)
        {
            int counter = 0;
            int n = nums.Length+1;
            bool notFount = true;
            while (counter <= n)
            {
                notFount = true;
                foreach (int i in nums)
                {
                    if(i == counter)
                    {
                        notFount = false;
                        break;
                    }
                }
                if(notFount)
                {
                    return counter;
                }
                counter++;
            }
            return counter + 1;
        }
        public int MissingNumber(int[] nums) // O(n)
        {
            HashSet<int> set = new HashSet<int>(nums);
            for (int i = 0; i <= nums.Length; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }
            return 0;
        }
        public int MissingNumber2(int[] nums)
        {
            Array.Sort(nums);
            if (nums[0] == 1) // first element which is 0 is missing 
            {
                return 0;
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] + 1 != nums[i + 1])
                {
                    return nums[i] + 1;
                }
            }
            return nums[nums.Length - 1] + 1; // last element is missing 
        }

        // using mathematic formulla of summation of n number 
        /*
         the summation numbers from 0 t0 n is sigma(n) = n * ( n+1) / 2
        first find the sigma of n and then subract each element of array from it the remaining will be the missing number 
         */
        public int MissingNumber3(int[] nums)
        {
            int n = nums.Length;
            int sigma = (n * (n + 1)) / 2;
            foreach (int i in nums)
            {
                sigma -= i;
            }
            return sigma;
        }

        // using bit manipulation technique XOR
        public int MissingNumber4(int[] nums)
        {
            int xor = 0;
            foreach (int num in nums)
            {
                xor ^= num;
            }
            for (int i = 0; i <= nums.Length; i++)
            {
                xor ^= i;
            }
            return xor;
        }

    }
}
/*
The XOR (exclusive OR) operator is a binary operator that operates on two bits at a time. The symbol for XOR is ^ in many programming languages, including C, C++, Java, and Python. The XOR operation follows these basic rules:

0 XOR 0 equals 0 (any number xor to itself is 0)
0 XOR 1 equals 1 ( 0 xor any number = that number)
1 XOR 0 equals 1
1 XOR 1 equals 0 (any number xor to itself is 0)

A ^ B = B ^ A
In other words, the XOR operation returns 1 if and only if the two bits are different. If the two bits are the same, XOR returns 0. This property makes XOR particularly useful in various computing contexts, such as cryptography, error detection and correction algorithms, and for performing certain arithmetic operations without using arithmetic operators.

Properties of XOR
The XOR operation has several notable properties:

Commutative: A XOR B is the same as B XOR A.
Associative: (A XOR B) XOR C is the same as A XOR (B XOR C).
Identity: A XOR 0 equals A. XOR with 0 leaves a value unchanged.
Inverse: A XOR A equals 0. Any value XOR'd with itself returns 0.
Uses of XOR
Swapping Values: XOR can be used to swap two values without using a temporary variable:

c
Copy code
a = a ^ b;
b = a ^ b; // Now b is a
a = a ^ b; // Now a is b
This works because the XOR operation is its own inverse.

Finding the Missing Number: In a sequence where each number except one appears twice, XOR can be used to find the missing number, as XORing all the numbers will cancel out the pairs and leave the unique number.

Cryptography: XOR is widely used in cryptography algorithms. Since XORing a value with a key can encrypt it, applying the XOR operation again with the same key decrypts it back to the original value.

Parity Checks: XOR can be used to generate a simple parity bit for error detection in data transmission. The parity bit represents whether the count of bits with a value of 1 is odd or even.

Bit Manipulation: XOR is useful in algorithms that involve bit manipulation for setting, toggling, or clearing bits

AND and OR operators 

1 && 1 = 1
1 && 0 = 0

1 OR 1 = 1 
1 OR 0 = 1 

they are also comutative 
 */
