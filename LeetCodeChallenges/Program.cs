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

            //_152Maximum_Product_Subarray c = new _152Maximum_Product_Subarray();
            //int[] arr = { 3, 4, 5, 6, 1, 2 };

            //Console.WriteLine(c.MaxProduct(arr));
            //Console.WriteLine(c.MaxProduct2(arr));
            //Console.WriteLine(c.MaxProduct3(arr));

            //_238_Product_of_Array_Except_Self o = new _238_Product_of_Array_Except_Self();
            //int[] arr = { 1, 2, 3, 4 };
            //print(o.ProductExceptSelf(arr));
            //print(o.ProductExceptSelf2(arr));
            //print(o.ProductExceptSelf3(arr));
            //print(o.ProductExceptSelf4(arr));

            //Encode_and_Decode_Strings___Leetcode_271 o = new Encode_and_Decode_Strings___Leetcode_271();
            //string[] sl = { "wahid", "rahimi", "Abdullah", "Hosna" };
            //foreach (string s in o.EncodeDecode(sl))
            //{
            //    Console.Write(s + " ");
            //}
            //Console.WriteLine();
            //foreach (string s in o.EncodeDecode2(sl))
            //{
            //    Console.Write(s + " ");
            //}

            //Console.WriteLine(Math.Min(3,3));

            Merge_two_sorted_array o = new Merge_two_sorted_array();
            _4_Median_of_Two_Sorted_Arrays o2 = new _4_Median_of_Two_Sorted_Arrays();
            int[] arr1 = { 1,2,3,9,10,11,12,13};
            int[] arr2 = { 3, 4 ,5,6,7,100,111,123};
            int[] arr3 = o.merge(arr1, arr2 );

            Console.WriteLine(o2.FindMedianSortedArrays(arr1, arr2));
            Console.WriteLine(o2.FindMedianSortedArrays2(arr1, arr2));

            //foreach ( int i in arr3 )
            //{
            //    Console.Write(i + " ");
            //}
        }
        public static void print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}