using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

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


            //First_negative_integer_in_every_window_of_size_k obj = new First_negative_integer_in_every_window_of_size_k();
            //long[] arr = { -8, 2, 3, -6, 10 };
            //int k = 3; 
            //long[] arr2 = { 12, -1, -7, 8, -15, 30, 16, 28};
            //long[] result = obj.printFirstNegativeInteger(arr2, k);

            //foreach (long value in result)
            //{
            //    Console.Write(value + " ");
            //}
            //Console.WriteLine();
            //obj.printFirstNeg(arr2, k);
            //Console.WriteLine();
            //obj.printFirstNeg2(arr2, k);
            //Console.WriteLine();
            //long[] result2 = obj.firstNegativeOptimized(arr2, k);

            //foreach (long value in result)
            //{
            //    Console.Write(value + " ");
            //}

            //String s = "Wahidullah Rahimi";
            //Console.WriteLine(s.Substring(0,4));

            //var dictionary1 = new Dictionary<char, int> { { 'a', 1 }, { 'b', 2 } };
            //var dictionary2 = new Dictionary<char, int> { { 'a', 1 }, { 'b', 2 } };

            //bool areEqual = AreDictionariesEqual(dictionary1, dictionary2);
            //areEqual = isEq(dictionary1, dictionary2);

            //Console.WriteLine("The dictionaries are " + (areEqual ? "equal." : "not equal."));

            //string txt = "forxxorfxdofr";
            //string pat = "for";

            //Count_Occurrences_Of_Anagrams obj = new Count_Occurrences_Of_Anagrams();
            //Console.WriteLine(obj.search(pat,txt));
            //Console.WriteLine(obj.search2(pat,txt));
            //Console.WriteLine(obj.countAnagrams(pat,txt));

            //txt = "aabaabaa";
            //pat = "aaba";
            //Console.WriteLine();
            //Console.WriteLine(obj.search(pat, txt));
            //Console.WriteLine(obj.search2(pat, txt));
            //Console.WriteLine(obj.countAnagrams(pat, txt));

            //Sliding_Window_Maximum obj = new Sliding_Window_Maximum();

            //List<int> A = new List<int>() { 1, 3, -1, -3, 5, 3, 6, 7 };
            //int B = 3;

            ////out put C = [3, 3, 5, 5, 6, 7]
            //foreach (int i in obj.slidingMaximum(A,B)) 
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //foreach (int i in obj.slidingMaximum2(A, B))
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //foreach (int i in obj.slidingMaximum3(A, B))
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();
            //foreach (int i in obj.slidingMaximum4(A, B))
            //{
            //    Console.Write(i + " ");
            //}

            //Variable_Size_Sliding_Window__Largest_Subarray_of_sum_K o = new Variable_Size_Sliding_Window__Largest_Subarray_of_sum_K();
            //int[] arr = { 4, 1, 1, 1, 2, 3, 5 };
            //int k = 5;
            ////Console.WriteLine(o.largestSubArraySize(arr,k));
            //Console.WriteLine(o.largestSubArraySize2(arr,k));


            //_560_Subarray_Sum_Equals_K o = new _560_Subarray_Sum_Equals_K();

            //int[] arr = { 3, 4, 7, 2, -3, 1, 4, 2 };
            //int k = 7;
            //int[] arr2 = { 1, 2, 3};
            ////k = 3;
            //Console.WriteLine(o.totalSubArrays(arr,k));
            //Console.WriteLine(o.totalSubArrays2(arr,k));
            //Console.WriteLine(o.SubarraySum(arr,k));

            Longest_Substring_With_K_Unique_Characters_Variable_Size_Sliding_Window o = new Longest_Substring_With_K_Unique_Characters_Variable_Size_Sliding_Window();
            string S = "aabacbebebe";
            int K = 3;
            Console.WriteLine(o.longestKSubstr(S,K));
            Console.WriteLine(o.longestKSubstr2(S,K));
            Console.WriteLine(o.longestSubStr(S,K));
            Console.WriteLine(o.longestSubStr2(S,K));
        }

        public static bool AreDictionariesEqual(Dictionary<char,int> dict1, Dictionary<char,int> dict2)
        {
            if(dict1.Count != dict2.Count)
                return false;
            if(dict1 == null && dict2 == null)
                return dict1 == dict2;

            foreach(var pair1 in dict1)
            {
                int value; 
                if(!dict2.TryGetValue(pair1.Key, out value))
                    return false;
                if(pair1.Value != value) 
                    return false;
            }
            return true;
        }
        public static bool isEq(Dictionary<char,int> d1, Dictionary<char, int> d2)
        {
            if (d1.Count != d2.Count)
                return false;
            if(d1 == null && d2 == null)
                return true;
            foreach(var p1 in d1)
            {
                int val;
                if(!d2.TryGetValue(p1.Key, out val) || val != p1.Value)
                    return false;
            }
            return true;
        }
    }
}