using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion2
    {
        // Parameterized Recursion 

        // Sum of n Numbers
        public int sum(int n)
        {
            return sumHelper(n, n);
        }
        private int sumHelper(int i, int n)
        {
            if(i < 1)
            {
                return 0;
            }
            return i + sumHelper(i-1, n);
        }


        public void sum2(int n)
        {
            sumHelper2(n, 0); // initial sum = 0
        }
        private void sumHelper2(int n, int sum)
        {
            if (n < 1)
            {
                Console.WriteLine(sum);
                return;
            }
            sumHelper2(n - 1, sum+n);
        }
        /*
         Recursion tree for sum2 looks like 
        f(3,0) -> f(2,3) - > f(1,5) - > f(0,6) -> base case hit and 6 is printed and returned from all recursive calls 
         

        we saw how to carry the parameters in recursive calls 
         */


        /*
         Functional Recursion 
        we do not want parameterized function calls 
        we want the function to return 
         */

        public int sum3(int n )
        {
            if( n == 0)
                return 0;
            return n + sum(n - 1);
        }


        // How to reverse an array using recursion 
        public void reverseArr(int[] arr) // functional recursion 
        {
            reverseArrHelper(arr, 0, arr.Length - 1);
            
        }
        private void reverseArrHelper(int[] arr, int left, int right)
        {
            if (left > right)
                return;
            int temp = arr[right];
            arr[right] = arr[left];
            arr[left] = temp;
            reverseArrHelper(arr, left+1, right-1);
        }

        // given a string recursively check if the strings is palindrom or not 
        /*
         a string reads the same on reversal , if we reverse it, it should be them string
         */
        public bool isPalendrom(string str)
        {
            return isPalendromHelper(str, 0, str.Length-1);
        }
        private bool isPalendromHelper(string str, int left, int right) 
        {
            if (str[left] != str[right])
                return false;
            else if(left > right)
                return true;
            return isPalendromHelper(str, left+1, right-1);
        }

        public bool isPalendrom2(string str) // O(n/2) , stack space O(n/2) 
        {
            return isPalendrom2Helper(str, 0);
        }
        private bool isPalendrom2Helper(string s, int i)
        {
            if(i > s.Length/2) 
                return true;
            if (s[i] != s[s.Length-1-i])
                return false;
            return isPalendrom2Helper(s, i + 1);
        }
    }
}
