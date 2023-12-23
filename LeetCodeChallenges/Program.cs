using System;

namespace LeetCodeChallenges
{

    internal class Program
    {
        static void Main(string[] args)
        {

            //// Sorting Dictionary Elements 
            //Dictionary<int, int> d = new Dictionary<int, int>
            //{
            //    {1, 5},
            //    {2, 3},
            //    {3, 1},
            //    {4, 4},
            //    {5, 2}
            //};

            //// Sort by values in ascending order
            //var sortedAscending = d.OrderBy(pair => pair.Value);

            //// Sort by values in descending order
            //var sortedDescending = d.OrderByDescending(pair => pair.Value);

            //Console.WriteLine("Ascending order:");
            //foreach (var kvp in sortedAscending)
            //{
            //    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            //}

            //Console.WriteLine("\nDescending order:");
            //foreach (var kvp in sortedDescending)
            //{
            //    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            //}

            //// Take the top 3 elements
            //var top3Elements = sortedDescending.Take(3);

            //Console.WriteLine("Top 3 elements in descending order:");
            //foreach (var kvp in top3Elements)
            //{
            //    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            //}


            //Dictionary<int, int> d = new Dictionary<int, int>();
            //int[] nums = { 6, 5, 5 };
            //foreach (int num in nums)
            //{
            //    if (d.ContainsKey(num))
            //    {
            //        d[num]++;
            //    }
            //    else
            //    {
            //        d[num] = 1;
            //    }
            //}
            //// Find the key with the largest value
            //int keyWithLargestValue = d.OrderByDescending(pair => pair.Value)
            //                       .First()
            //                       .Key;

            //Console.WriteLine("Key with the largest value: " + keyWithLargestValue);

            //Kadane_Algorithm_MaxSubArraySum k = new Kadane_Algorithm_MaxSubArraySum();
            //int[] arr = { -2, -5, 6,-2,-3,1,5,-6};
            //Console.WriteLine(k.MaxSubArraySum(arr));
            //Console.WriteLine(k.MaxSubArrayBruteForce(arr));
            //Console.WriteLine(k.MaxSubArray2(arr));

            _152Maximum_Product_Subarray c = new _152Maximum_Product_Subarray();
            int[] arr = { 3, 4, 5, 6, 1, 2 };

            Console.WriteLine(c.MaxProduct(arr));
            Console.WriteLine(c.MaxProduct2(arr));
            Console.WriteLine(c.MaxProduct3(arr));
        }
    }
}