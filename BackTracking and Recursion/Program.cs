using BackTracking_and_Recursion;
using System;

namespace BackTrackingAndRecursion 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Recursion o = new Recursion();
            //o.print("Wahid", 10);
            //o.printNNumbers(10);
            //int n = 1002001102;
            //Console.WriteLine(o.fib(n));
            //int[] arr = new int[n+1];
            //Console.WriteLine(o.fibDP(n, arr));
            //Console.WriteLine(o.fibDP(n));

            //Console.WriteLine(o.sumOfDigits(n));
            //Console.WriteLine(o.sumOfDegitsRec(n));

            //Console.WriteLine(o.reverse(n));
            //o.reverseRec(n);
            //Console.WriteLine(Recursion.sum);
            //Console.WriteLine(o.reverseRec2(n));
            //Console.WriteLine(o.ReverRec3(n));

            //Console.WriteLine(o.IsPalindrome(n));
            //Console.WriteLine(o.IsPalindrome2(n));
            //Console.WriteLine(o.IsPalindrome3Rec(n));

            //Console.WriteLine(o.countZeros(n));
            //Console.WriteLine(o.countZeros2(n));
            //Console.WriteLine(o.countZeros3(n));
            //Console.WriteLine(o.countZeros4(n));

            //Recursion__Array_Questions o = new Recursion__Array_Questions();
            int[] arr = {11,1,2,3,11,3, 7, 8, 9, 11,11,11};
            //Console.WriteLine(o.isSorted(arr));
            //Console.WriteLine(o.isSortedRec(arr));

            int n = 11;

            //Console.WriteLine(o.searchRec(arr, n));
            //Console.WriteLine(o.searchRec2(arr, n));
            //Console.WriteLine(o.findIndex(arr,n));
            //Console.WriteLine(o.findIndexFromLast(arr,n));
            //foreach(int i in o.findAllIndexes(arr,n)) 
            //    Console.Write(i + " ");
            //Console.WriteLine();
            //foreach (int i in o.findAllIndexes2(arr, n))
            //    Console.Write(i + " ");

            //List<int> list = new List<int> { 1,2,3,4};
            //List<int> list2 = new List<int> {5,6,7,8};

            //list.AddRange(list2);
            //list.AddRange(arr);
            //list.AddRange(new List<int>());
            //list.AddRange(new List<int>() { 5});

            //foreach (int i in list) 
            //{
            //    Console.Write(i + " ");
            //}

            //int[] rotatedArray = { 4, 5, 6, 7, 0, 1, 2 };
            //int target = 1;
            //int foundIndex = o.SearchInRotatedArray(rotatedArray, target);
            //Console.WriteLine(foundIndex != -1 ? $"Element found at index {foundIndex}" : "Element not found");
            //int foundIndexRec = o.SearchInRotatedArrayRec(rotatedArray, target);
            //Console.WriteLine(foundIndex != -1 ? $"Element found at index {foundIndexRec}" : "Element not found");


            Recursion_Subset_Subsequence_String_Questions o = new Recursion_Subset_Subsequence_String_Questions();

            Console.WriteLine(o.removeAllA("Wahidullah Rahimi"));
            Console.WriteLine(o.removeAllA2("Wahidullah Rahimi"));
            Console.WriteLine(o.removeAllARec("Wahidullah Rahimi"));
            Console.WriteLine(o.removeAllARec2("Wahidullah Rahimi"));


        }
    }
}