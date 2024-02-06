using System;
using System.Security.Cryptography.X509Certificates;

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

            //Merge_two_sorted_array o = new Merge_two_sorted_array();
            //_4_Median_of_Two_Sorted_Arrays o2 = new _4_Median_of_Two_Sorted_Arrays();
            //int[] arr1 = { 1,2,3,9,10,11,12,13};
            //int[] arr2 = { 3, 4 ,5,6,7,100,111,123};
            //int[] arr3 = o.merge(arr1, arr2 );

            //Console.WriteLine(o2.FindMedianSortedArrays(arr1, arr2));
            //Console.WriteLine(o2.FindMedianSortedArrays2(arr1, arr2));

            //foreach ( int i in arr3 )
            //{
            //    Console.Write(i + " ");
            //}

            //_424_Longest_Repeating_Character_Replacement o = new _424_Longest_Repeating_Character_Replacement();

            //string s = "ABAB";
            //int k = 2;
            //Console.WriteLine(o.CharacterReplacement(s,k));

            //for(char i = 'A'; i <= 'z'; i++)
            //{
            //    if(i > 90 && i < 97 )
            //    {
            //        continue;
            //    }
            //    Console.Write(i);
            //}


            //var permutations = StringPermutations.GetAllPermutations("wahid");
            //Console.WriteLine(permutations.Count);
            ////foreach (var perm in permutations)
            ////{
            ////    Console.WriteLine(perm);
            ////}
            //Console.WriteLine(permutations.Count);

            //Anagram o = new Anagram();
            //Console.WriteLine(o.isAnagram("wiu ahiid ","iiw ahid u"));


            //int[] a = { 1, 2 };
            //int[] b = { 1, 2 };
            //Console.WriteLine(a == b);

            //(int, int, int, string) triplet = (108, 2, 3, "Wahid");
            //Console.WriteLine(triplet.Item1);
            //triplet.Item1 = 800;
            //Console.WriteLine(triplet.Item1);
            //Console.WriteLine(triplet.Item3);
            //Console.WriteLine(triplet.Item4);

            //Dictionary<char, int> d = new();
            //d['c'] = 30;
            //d.Add('d', 4);
            //foreach(var kvp in d)
            //{
            //    Console.WriteLine(kvp.Key + ":" + kvp.Value);
            //}

            _13_Roman_to_Integer o = new _13_Roman_to_Integer();

            //Console.WriteLine(o.RomanToInt("LVIII"));
            //Console.WriteLine(o.RomanToInt2("LVIII"));
            //Console.WriteLine(o.IntToRoman(58));
            //Console.WriteLine(o.IntToRoman2(58));
            //Console.WriteLine(o.ToRoman(58));

            //string s = "Wahid";
            //int n = 6;
            //Console.WriteLine(s.Substring(2));
            //s = s.PadLeft(s.Length + n, '_');
            //Console.WriteLine(s.PadRight(s.Length+ n,'_'));
            //s = 'R' + s; // prepend a char to a string
            //Console.WriteLine(s);
            //s = 'A' + s;
            //Console.WriteLine(s);
            //while (true) // rotating a string
            //{
            //    Console.ReadLine();
            //    string left = s.Substring(0, 1);
            //    string right = s.Substring(1);
            //    s = right + left;
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine(RotateString.RotateRight("Wahid",2));
            //string s = "Wahid";
            //Console.WriteLine("abcde".Contains("acd"));



            string s = "Wahidullah Rahimi jan abdullah jan rahimi hosna jan rahimi";
            Dictionary<char, List<int>> charIndices = new Dictionary<char, List<int>>();
            for(int i = 0; i < s.Length; i++) 
            {
                if (!charIndices.ContainsKey(s[i]))
                {
                    charIndices.Add(s[i], new List<int>());
                }
                charIndices[s[i]].Add(i);
            }
            foreach(var kvp in charIndices)
            {
                Console.Write(kvp.Key + ": ");
                printList(kvp.Value);
            }

        }
        public static void print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        private static void printList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}