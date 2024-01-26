using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion
    {
        // recursively print something n times
        public void print(string message, int n)
        {
            if(n < 1)
            {
                return;
            }
            //Console.WriteLine(n + ": "+ message);
            print(message, n-1);
            Console.WriteLine(n + ": " + message);
        }

        public void printNNumbers(int n)
        {
            if(n < 1)
            {
                return;
            }
            printNNumbers(n-1);
            Console.WriteLine(n);
        }

        public int factorial(int n )
        {
            if(n <= 0)
            {
                return 1;
            }
            return n * factorial(n-1);
        }
        public int sumOfNNumbers(int n)
        {
            if(n <= 1)
            {
                return 1;
            }
            return n + sumOfNNumbers(n-1);
        }
        public int fib(int n)
        {
            if( n < 2 )
            {
                return n;
            }
            return fib(n-1) + fib(n-2);
        }

        public int fibDP(int n, int[] arr)
        {
            if( arr.Length < n +1 )
            {
                return -1;
            }
            if (n < 2) // base case
                return n;
            // check if arr[n-1] and arr[n-2] are already calculated
            if (arr[n-1] == 0)
            {
                arr[n-1] = fibDP(n-1, arr); // calculate and store arr[n-1]
            }
            if (arr[n-2] == 0)
            {
                arr[n-2] = fibDP(n-2, arr); // calculate and store arr[n-2]
            }

            // calculate the result using the precomputed values in arr
            int result = arr[n-1] + arr[n-2];
            arr[n] = result;

            return arr[n];
            // return result;
        }

        // DP without recursion 
        public int fibDP(int n)
        {
            if (n < 2)
                return n;

            int[] arr = new int[n+1];
            arr[0] = 0; // initialize the first and secon fibonacci number
            arr[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }


        /*
          Sum of digis of a given number 1234 => 1+2+3+4 = 10
         */
        public int sumOfDigits(int n)
        {
            if(n <= 10)
                return n;
            int sum = 0;
            int r = 0; 
            while(n > 0)
            {
                r = n % 10; 
                n /= 10;
                sum += r;
            }
            return sum;
        }

        public int sumOfDegitsRec(int n)
        {
            if(n <= 0)
            {
                return 0;
            }
            return n % 10 + sumOfDegitsRec(n/10);
        }

        // print a word n times using recursion 
        public static void printNTmes(int n, string word = "default")
        {
            if(n == 0)
                return;
            Console.WriteLine(word);
            printNTmes(n-1, word);
        }

        // Concept --n VS n--
        public void func(int n) // infinite recursion 
        {
            if (n == 0)
                return;
            Console.WriteLine(n); // it will just keep printing n , until stack overflow
            func(n--); // first passes the value of n to the next call then subtract one from 
            // one will be subtracted when the current function call finishes execution 
            // so the next function call will alway get n , not decremented n 
        }

        public void func2(int n)
        {
            if(n == 0) return;
            Console.WriteLine(n);
            func2(--n); // first decrements and then passes the decremented value to the next call. 
        }

        // revers a number 
        public int reverse(int n)
        {
            int rev = 0; 
            while (n > 10)
            {
                rev += n % 10;
                rev *= 10;
                n /= 10;
            }
            rev += n;
            return rev ;
        }
        public int Reverse(int n)
        {
            int rev = 0;

            while (n != 0) // Change the condition from "n > 10" to "n != 0"
            {
                rev = rev * 10 + n % 10; // Reverse the number digit by digit
                n /= 10; // Move to the next digit
            }

            return rev;
        }

        public static int sum = 0; 
        public void reverseRec(int n)
        {
            if (n  == 0)
                return ;
            int r = n % 10;
            sum  = sum * 10 + r;
            reverseRec(n / 10);
        }

        public int reverseRec2(int n)
        {
            return ReverseRecursive(n, 0);
        }
        /*
         The ReverseRecursive function is a private helper function that performs the actual reversal. 
        It takes two parameters: n (the remaining part of the number to process) and rev (the reversed number being built).
         
         
In the recursive version of the code, we pass 0 as the initial value for the rev parameter in the helper function to keep track of the reversed number being built during the recursion. This initial value is important because it starts the process of reversing the number. Here's why we do that:

Initialization: When you start reversing a number, you don't have any reversed digits yet. So, you initialize rev to 0 to represent an empty reversed number.

Accumulation: As you recursively process the digits of the input number, you accumulate the reversed number digit by digit. The rev parameter holds the reversed number at each step.

Base Case: In the base case of the recursion, when there are no more digits to process (i.e., n == 0), you return the rev value as the fully reversed number.

Here's a breakdown of how rev evolves during the recursion:

Initially, rev is 0.

As you process the rightmost digit of the input number, you update rev to be that digit.

In the next recursive call, you multiply rev by 10 and add the next digit, effectively shifting the existing digits one place to the left and adding the new digit at the rightmost position.

This process continues until all digits are processed, and the final value of rev represents the fully reversed number.

So, passing 0 as the initial value for rev allows you to build and accumulate the reversed number correctly during the recursive calls.
         */
        private int ReverseRecursive(int n, int rev)
        {
            // Base case: When there are no more digits left in n
            if (n == 0)
            {
                return rev;
            }

            // Reverse the number digit by digit
            rev = rev * 10 + n % 10;

            // Recursive call to process the next digit
            return ReverseRecursive(n / 10, rev);
        }


        /*
         * 
         or
        to revers 1234 
        4 * 1000 + 123
                   3 * 100 + 12
                        2 * 10 +
                            1 
         */
        public int ReverRec3(int n)
        {
            int numberOfDigitsInN = Convert.ToInt32(Math.Log10(n)) + 1; // gives the number of digigs in n
            return helper(n, numberOfDigitsInN);
        }
        private int helper(int n, int numberOfDigitsInN)
        {
            //if the number is a one digit number return the number itself
            if(n % 10 == n)
            {
                return n;
            }
            int r = n % 10;
            return r * Convert.ToInt32(Math.Pow(10, numberOfDigitsInN-1)) + helper(n/10, numberOfDigitsInN-1);
        }



        /*
         * A palindrome number is a number that remains the same when its digits are reversed. 
         * For example, 121 is a palindrome, but 123 is not.
         */
        // Function to check if a number is a palindrome
        public bool IsPalindrome(int number)
        {
            // If the number is negative, it's not a palindrome
            if (number < 0) return false;

            // Convert the number to a string
            string numStr = number.ToString();

            // Initialize pointers for the start and end of the string
            int start = 0;
            int end = numStr.Length - 1;

            // Loop through the string
            while (start < end)
            {
                // If characters at start and end are not the same, it's not a palindrome
                if (numStr[start] != numStr[end])
                {
                    return false;
                }

                // Move the pointers closer to the center
                start++;
                end--;
            }

            // If the loop completes without returning false, it's a palindrome
            return true;
        }
        public bool IsPalindrome2(int number)
        {
            return number == Reverse(number);
        }

        // Recursive function to check if a number is a palindrome
        public bool IsPalindrome3Rec(int number)
        {
            // Convert the number to a string to work with individual digits
            string numStr = number.ToString();
            return IsPalindromeRecursive(numStr, 0, numStr.Length - 1);
        }

        // Helper function for recursive palindrome check
        static bool IsPalindromeRecursive(string numStr, int start, int end)
        {
            // Base case: if start crosses end, or they are the same, it's a palindrome
            if (start >= end)
            {
                return true;
            }

            // Check if the current characters are different
            if (numStr[start] != numStr[end])
            {
                return false;
            }

            // Recursive call by moving the pointers towards the middle
            return IsPalindromeRecursive(numStr, start + 1, end - 1);
        }


        /*
         * Count number of zeros in agiven number
         */
        public int countZeros(int number)
        {
            int count = 0;

            // Handling the case where the number is 0
            if (number == 0)
            {
                return 1;
            }

            // Handling negative numbers by taking their absolute value
            number = Math.Abs(number);

            while (number > 0)
            {
                if (number % 10 == 0)  // Check if the last digit is zero
                {
                    count++;
                }
                number /= 10;  // Remove the last digit
            }

            return count;
        }
        public int countZeros2(int number)
        {
            int count = 0;
            string strNum = number.ToString();
            foreach(char c in strNum)
            {
                if (c == '0')
                    count++;
            }
            return count;
        }
        // recursive solution for counting number of 0s
        public int countZeros3(int number)
        {
            // Handle the case of the number being 0 at the beginning
            if (number == 0)
            {
                return 1;
            }

            // If the number is negative, work with its absolute value
            number = Math.Abs(number);

            // Start the recursive count
            return CountZerosRecursive(number);
        }

        private int CountZerosRecursive(int number)
        {
            // Base case: when the number is reduced to 0
            if (number == 0)
            {
                return 0;
            }

            // Check if the current last digit is zero, and add 1 to the count if it is
            int count = (number % 10 == 0) ? 1 : 0;

            // Recursive call, removing the last digit
            return count + CountZerosRecursive(number / 10);
        }

        public int countZeros4(int number)
        {
            return helperCount(number, 0);
        }
        private int helperCount(int number, int count)
        {
            if(number == 0)
            {
                // after the last function call, the same count value will be returned to previous functions calls 
                return count; // count is returned once, after the base cases is done it passes down the count to where it was called .... 
            }
            int r = number % 10;
            if(r == 0)
            {
                return helperCount(number / 10, count+1); // increment the count and reduce the number
            }
            // esle do not increment count just reduce thenumber 
            return helperCount(number / 10, count);
        }

        
    }
}
