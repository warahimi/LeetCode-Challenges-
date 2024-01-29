using BackTracking_and_Recursion;
using System;
using System.Linq.Expressions;
using System.Text;

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
            //int[] arr = {11,1,2,3,11,3, 7, 8, 9, 11,11,11};
            //Console.WriteLine(o.isSorted(arr));
            //Console.WriteLine(o.isSortedRec(arr));

            //int n = 11;

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


            //Recursion_Subset_Subsequence_String_Questions o = new Recursion_Subset_Subsequence_String_Questions();

            //Console.WriteLine(o.removeAllA("Wahidullah Rahimi"));
            //Console.WriteLine(o.removeAllA2("Wahidullah Rahimi"));
            //Console.WriteLine(o.removeAllARec("Wahidullah Rahimi"));
            //Console.WriteLine(o.removeAllARec2("Wahidullah Rahimi"));

            //Console.WriteLine(o.skipString("this is a good day. today is Friday", "is"));
            //Console.WriteLine(o.skipString2("this is a good day. today is Friday", "is"));
            //Console.WriteLine(o.skipString3("this is a good day. today is Friday", "is"));
            //Console.WriteLine(o.skipStringRec("this is a good day. today is Friday", "is"));


            //_78_Subsets_BackTracking o = new _78_Subsets_BackTracking();
            //Back_Tracking o = new Back_Tracking();

            //int[] arr = { 1, 2, 3, 2 };

            //foreach (var subset in o.Subsets(arr))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();
            //foreach (var subset in o.Subsets2(arr))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();
            //foreach (var subset in o.Subsets2UniqueSubSet(arr))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //int length = 2;
            //Console.WriteLine();
            //Console.WriteLine("Subsets of length: "+ length);
            //foreach (var subset in o.SubsetsOfSpecificLength(arr,length))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();

            //string s = "abcb";
            //foreach (var subset in o.stringSubSet(s)) 
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();
            //foreach (var subset in o.UniqueStringSubSets(s))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();
            //string input = "abcde";
            //foreach (var subset in o.SubsetsWithEqualVowelsAndConsonants(input))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}
            //Console.WriteLine();

            //foreach (var subset in o.SubsetsWithCharCount(input))
            //{
            //    Console.Write("{" + String.Join(",", subset) + "}");
            //}


            //Recursion_Permutation o = new Recursion_Permutation();
            //string str = "ABC";
            //char[] arr = str.ToCharArray();
            //o.Permute(arr, 0, arr.Length - 1);
            //Console.WriteLine();
            //foreach (string s in o.PermuteString(str))
            //{
            //    Console.WriteLine(s);
            //}


            //int[] arr = { 1, 2, 3 };
            //o.permuteArray(arr);
            //Console.WriteLine();
            //foreach (var i in o.permuteArray2(arr))
            //{
            //    PrintArray(i);
            //}
            //Console.WriteLine();
            //foreach (var i in o.permuteArray3(arr))
            //{
            //    PrintArray(i);
            //}

            //Remove_a_Sub_String_from_String o = new Remove_a_Sub_String_from_String();
            //Console.WriteLine(o.removeString("this is an apple. I eat apple all the time.", "game"));
            //Console.WriteLine(o.removeString2("this is an apple. I eat apple all the time.", "game"));
            //Console.WriteLine(o.RemoveSubstring("this is an apple. I eat apple all the time.", "game"));
            //Console.WriteLine(o.RemoveSubstring2("this is an apple. I eat apple all the time.", "game"));


            //Recursion_Dice_Throw_and_Letter_combination_of_phone_number o = new Recursion_Dice_Throw_and_Letter_combination_of_phone_number();
            //o.dice(4); 
            //foreach(var i in o.dice2(4))
            //{
            //    printList(i);
            //}

            //foreach(var i in o.diceList(4))
            //{
            //    Console.Write(i +" ");
            //}

            //Backtracking_Maze_Problem o = new Backtracking_Maze_Problem();

            //int m = 3, n = 3;
            //Console.WriteLine(o.countPaths(m,n));
            //Console.WriteLine(o.countPaths2(m,n));
            //Console.WriteLine(o.countPaths3(m,n));
            //o.PrintPath(3, 3);
            //Console.WriteLine();
            //foreach (string s in o.PrintPath2(3,3))
            //    Console.WriteLine(s);
            //Console.WriteLine();
            //foreach (string s in o.PrintPath3(3, 3))
            //    Console.WriteLine(s);

            //Console.WriteLine(o.CountPathsDiagonally(m,n));
            //foreach(string s in o.PrintPathDiagonally(m,n))
            //{
            //    Console.WriteLine(s);
            //}

            //bool[,] maze =
            //{
            //    {true, true, true },
            //    {true, true, true },
            //    {true, true, true }
            //};
            //int[,] mazeInt = {
            //    { 1, 1, 1 },
            //    { 1, 1, 1 },
            //    { 1, 1, 1 }
            // };


            //o.PrintPathRestrictions(maze);
            //Console.WriteLine();
            //Console.WriteLine("All Directions");
            //o.PrintPathRestrictionsAllDirection(maze);
            //Console.WriteLine(o.CountPathsAllDirections2(maze,0,0));
            //Console.WriteLine(o.StartTraversal(maze));
            //Console.WriteLine(o.StartTraversal(mazeInt));

            //Backtracking_N_Queens o = new Backtracking_N_Queens();
            //int n = 5;
            //bool[,] board = new bool[n,n];
            //Console.WriteLine("Number of ways: " + o.NQueens(board));

            //Recursion.printNTmes(5, "Wahid");

            //Backtracking2 o = new Backtracking2();
            //int n = 5;
            //o.print(n);
            //Console.WriteLine();
            //o.print1toN(n);
            //Console.WriteLine();
            //o.printNto1(n);
            //Console.WriteLine();
            //o.print1toN2(n);
            //Console.WriteLine();
            //o.printNto1_2(n);

            //int n = 5;
            //Recursion2 o = new Recursion2();
            //Console.WriteLine(o.sum(n));
            //o.sum2(n);
            //int[] arr = {1,2,3, 4,5};
            //o.reverseArr(arr);
            //foreach (int i in arr) Console.Write(i + " ");
            //Console.WriteLine();
            //Console.WriteLine(o.isPalendrom("mmalayalamm"));
            //Console.WriteLine(o.isPalendrom2("mmalayalamm"));


            //Recursion_Multiple_Recursion_Calls o = new Recursion_Multiple_Recursion_Calls();
            //Console.WriteLine(o.fib(3));

            //Recursion3_Subsequence o = new Recursion3_Subsequence();
            //int[] arr = { 3,1,2 ,4,5,6};

            //Displaying all subsequences
            //foreach (var subsequence in o.GetSubsequence(arr))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}
            //Console.WriteLine();
            //foreach (var subsequence in o.GetSubsequenceRev(arr))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}

            //foreach (var subsequence in o.GetSubSequenceSumK(arr, 6))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}
            //Console.WriteLine();
            //foreach (var subsequence in o.GetSubSequenceSumK2(arr, 6))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}

            //Console.WriteLine();
            //foreach (var subsequence in o.GetSubSequenceSumK3(arr, 6))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}

            //Console.WriteLine();
            //foreach (var subsequence in o.GetSubSequenceSumK5(arr, 6))
            //{
            //    Console.WriteLine("[" + string.Join(", ", subsequence) + "]");
            //}
            //Console.WriteLine();
            //Console.WriteLine(o.GetSubSequenceSumK6(arr,6));
            //Console.WriteLine(o.GetSubSequenceSumK7(arr,6));
            //Console.WriteLine(o.GetSubSequenceSumK8(arr,6));

            //Merge_Sort_Using_Recursion o = new Merge_Sort_Using_Recursion();
            //int[] arr = { 10, 1, 2, 22, 3, 56, 0 };
            //o.MergeSort(arr);
            //o.MergeSort2(arr);
            //o.MergeSort3(arr);
            //o.MergeSort4(arr);

            //QuickSort_Using_Recursion o = new QuickSort_Using_Recursion();
            //o.QuickSort(arr);
            //PrintArray(arr);

            //_39_Combination_Sum_Reursion_and_BackTracking o = new _39_Combination_Sum_Reursion_and_BackTracking();
            //int[] arr = { 2, 3, 5 };
            //foreach( var list in o.CombinationSum3(arr, 8))
            //{
            //    printList(list);
            //}


            //_40_Combination_Sum_II o = new _40_Combination_Sum_II();
            //int[] arr = { 10, 1, 2, 7, 6, 1, 5 };
            //foreach (List<int> list in o.CombinationSum2(arr, 8))
            //{
            //    printList(list);
            //}


            //Subset_Sums o = new Subset_Sums();
            //List<int> arr = new List<int>() { 3,1,2};
            //printList(o.subsetSums(arr, arr.Count));
            //printList(o.subsetSums2(arr, arr.Count));
            //printList(o.subsetSumsA(arr));


            
        }
        private static void printList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }

    
}