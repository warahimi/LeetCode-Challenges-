using BackTracking_and_Recursion;
using System;

namespace BackTrackingAndRecursion 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recursion o = new Recursion();
            //o.print("Wahid", 10);
            //o.printNNumbers(10);
            int n = 678;
            //Console.WriteLine(o.fib(n));
            //int[] arr = new int[n+1];
            //Console.WriteLine(o.fibDP(n, arr));
            //Console.WriteLine(o.fibDP(n));

            //Console.WriteLine(o.sumOfDigits(n));
            //Console.WriteLine(o.sumOfDegitsRec(n));

            Console.WriteLine(o.reverse(n));
            o.reverseRec(n);
            Console.WriteLine(Recursion.sum);
            Console.WriteLine(o.reverseRec2(n));
            Console.WriteLine(o.ReverRec3(n));
        }
    }
}