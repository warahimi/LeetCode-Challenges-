using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Backtracking2
    {
        // print a name N times
        public void print(int n) // O(n) time and O(n) stack space becase we call the function n times and each function waits 
            // in the stack untill the base case is hit => O(n) space in computer memory, we are not using O(n) space in terms of any data structure , coputer's internal memory uses O(n) space
        {
            printHelper(1, n);
        }
        private void printHelper(int start, int N)
        {
            if(start > N)
            {
                return;
            }
            Console.WriteLine(start + ": Wahid");
            printHelper(start+1, N);
        }

        // 1: print linearly from 1 - N using recursion 
        public void print1toN(int n)
        {
            print1toNHelper(1, n);
        }
        private void print1toNHelper(int start, int N)
        {
            if(start > N)
            {
                return;
            }
            Console.WriteLine(start);
            print1toNHelper(start+1, N);
        }

        // 2- print linearly from N to 1 usin recursion 
        /*
         Think quesion 1 in the reverse order 
         */
        public void printNto1(int n)
        {
            printNto1Helper(n , n);
        }
        private void printNto1Helper(int start, int n)
        {
            if (start < 1)
                return;
            Console.WriteLine(start);
            printNto1Helper(start-1, n);
        }

        // thin k reverse order
        // 3 : print linearly from 1 - N (By Backtracking)
        public void print1toN2(int n)
        {
            print1toNHelper2(n, n); // even starting from n (last) we can print in the linearly increasing order 1,2,3,4,5..n
        }
        private void print1toNHelper2(int start, int N)
        {
            if (start < 1)
            {
                return;
            }
            print1toNHelper2(start - 1, N);
            Console.WriteLine(start); // executing some lines of code after the recursive function calls

        }
        /*
          even starting from n (last) we can print in the linearly increasing order 1,2,3,4,5..n
        in order to print 1,2,3,4,5 ...n it is not neccessary to start from 1 and to to n 
        we can start from the back (n) , and do the task after the recursive function calls
        so we make sure the last guy is executed first 
        the print(start) will be the first line to be executed after we hit the base case and after we hit the base case and 
        returned the value of start in the previous function call was 1 and in the previous of previous was 2 and ... 
        so it prints 1,2....n we we return from the recursive function calls 
         */


        // 4: print from N to 1 (By Backtracking) 
        public void printNto1_2(int n)
        {
            printNto1Helper2(1, n); // starting from 1 and print n ....3,2,1
        }
        private void printNto1Helper2(int start, int n)
        {
            if (start > n)
                return;
            printNto1Helper2(start + 1, n);
            Console.WriteLine(start);

        }
    }
}
