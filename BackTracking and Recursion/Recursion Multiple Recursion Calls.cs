using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion_Multiple_Recursion_Calls
    {
        // give the nth fib number 
        public int fib(int n)
        {
            if (n <= 1)
                return n; 
            return fib(n - 1) + fib(n-2);
        }

        public int fib2(int n) // nearly O(2^n) it is exponential , beacause for each recursive call we call 2 more calls 
        {
            if (n <= 1)
                return n;
            int last = fib2(n - 1);
            int secondLast  = fib2(n - 2); // this will not execute untill the first recursive call has not fully finished and has not hit the base case 
            return last + secondLast;
        }
    }
}
