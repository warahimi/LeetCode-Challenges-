using System;

namespace SlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MaxSubArraySumWithSizeK obj = new MaxSubArraySumWithSizeK();

            //int[] arr = { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
            //Console.WriteLine(obj.maxSubArraySumWithSizeK(arr, 4));
            //Console.WriteLine(obj.MaxSum(arr, 4));
            //Console.WriteLine(obj.MaximumSumSubarray(arr, 4));
            //Console.WriteLine(obj.MaximumSumSubarray2(arr, 4));
            //Console.WriteLine(obj.maxSubArraySum(arr, 4));

            //Console.WriteLine();
            //// Test case 1
            //int[] arr1 = { 100, 200, 300, 400 };
            //int K1 = 2;
            //Console.WriteLine(obj.MaxSum(arr1, K1));
            //Console.WriteLine(obj.maxSubArraySumWithSizeK(arr1,K1));
            //Console.WriteLine(obj.MaximumSumSubarray(arr1,K1));
            //Console.WriteLine(obj.MaximumSumSubarray2(arr1,K1));
            //Console.WriteLine(obj.maxSubArraySum(arr1,K1));
            //Console.WriteLine();

            //// Test case 2
            //int[] arr2 = { 100, 200, 300, 400 };
            //int K2 = 4;
            //Console.WriteLine(obj.MaxSum(arr2, K2));
            //Console.WriteLine(obj.maxSubArraySumWithSizeK(arr2, K2));
            //Console.WriteLine(obj.MaximumSumSubarray(arr2, K2));
            //Console.WriteLine(obj.MaximumSumSubarray2(arr2, K2));
            //Console.WriteLine(obj.maxSubArraySum(arr2, K2));


            First_negative_integer_in_every_window_of_size_k obj = new First_negative_integer_in_every_window_of_size_k();
            long[] arr = { -8, 2, 3, -6, 10 };
            int k = 3; 
            long[] arr2 = { 12, -1, -7, 8, -15, 30, 16, 28};
            long[] result = obj.printFirstNegativeInteger(arr2, k);

            foreach (long value in result)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            obj.printFirstNeg(arr2, k);
            Console.WriteLine();
            obj.printFirstNeg2(arr2, k);
            Console.WriteLine();
            long[] result2 = obj.firstNegativeOptimized(arr2, k);

            foreach (long value in result)
            {
                Console.Write(value + " ");
            }
        }
    }
}