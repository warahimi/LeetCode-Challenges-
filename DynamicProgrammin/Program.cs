using System;

namespace DynamicProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //_300Longest_Increasing_Subsequence o = new _300Longest_Increasing_Subsequence();
            //int[] nums = {10, 9, 2, 5, 3, 7, 101, 18};
            //Console.WriteLine(o.LengthOfLIS(nums));
            //Console.WriteLine(o.LengthOfLIS2(nums));
            //Console.WriteLine(o.LengthOfLIS3(nums));
            Fib f = new Fib();
            int n = 9;
            Console.WriteLine(f.fib(n));
            int[] dp = new int[n+1];
            Console.WriteLine(f.fib2(n, dp));
            Console.WriteLine(f.fib3(n));
            Console.WriteLine(f.fib4(n));

        }
    }
}