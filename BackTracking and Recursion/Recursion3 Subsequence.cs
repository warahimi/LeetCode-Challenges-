using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackTracking_and_Recursion
{
    /* a sub sequence is a contiguous or noncontiguou sequence of elements that follows the order
      a sub array is always contiguous but a sub sequence can be contiguous or non contiguous 

    Subsequences include all possible combinations of elements from the original array, including the empty subsequence and the 
    full array itself.

    arr = {3,1,2} => subsequence = { {}, {3}, {1}, {3}, {3,1}, {1,2}, {3,2}(not contiguouse), {3,1,2} } 
    all the sub sets are contiguous except {3,2} since subsequence accepts non contiguous 



    {3,2,1} cannot be a sub sequence since it does not follow the order 

    8 subsequence for n = 3

    for each eleemnts we have 2 options , either pick it or not 
    {1,2} => {not take, take, take}
    {3,2} => {take, take, not take} 


    Pttern: remember this pattern 

    f(index, list[]}
    {
        if(index >= n)
        {
            print(List[])
            return
        }
        list[].add(arr[index]) // take
        f(index+1, list[])
        list[].remove(arr[index]) // not take 
        f(index+1, list[]) // index+1 skips the current element 
    }

     */
    internal class Recursion3_Subsequence
    {
        public List<List<int>> GetSubsequence(int[] arr)
        {
            var subsequences = new List<List<int>>();
            FindSubsequences(arr, 0, new List<int>(), subsequences);
            return subsequences;
        }

        // Recursive function to find all subsequences
        static void FindSubsequences(int[] arr, int index, List<int> current, List<List<int>> subsequences)
        {
            if (index == arr.Length)
            {
                // When index reaches the end of the array, add the current subsequence to the list
                subsequences.Add(new List<int>(current)); //  The list of all subsequences found so far.
                return;
            }

            /*
             * For each element in the array, there are two recursive calls:
                One call includes the current element (current.Add(arr[index])).
                The other call excludes it (current.RemoveAt(current.Count - 1)), effectively backtracking to explore other
                combinations.
             */
            // Include the current element
            current.Add(arr[index]); // The current subsequence being constructed., take the element at index in the current subsequence
            FindSubsequences(arr, index + 1, current, subsequences);

            // Exclude the current element (backtrack)
            current.RemoveAt(current.Count - 1); // do not take the current element of element at index in the current subsequence 
            FindSubsequences(arr, index + 1, current, subsequences);

        }
        /*
         Removing (Backtracking) Explained:
In the recursive solution to find all subsequences, the algorithm uses a temporary list current to keep track of the elements that are currently being considered as part of a subsequence. For each element in the original array, the algorithm explores two possibilities: including the element in the current subsequence or excluding it.

Including the Element:

The first recursive call includes the current element (current.Add(arr[index])).
After adding the element, it calls the function again with the next index (index + 1).
Excluding the Element (Backtracking):

Before the second recursive call, the element added in the previous step is removed (current.RemoveAt(current.Count - 1)). This step is the backtracking step.
The removal undoes the addition of the current element, returning the current list to its state before the element was added. This is necessary because the next recursive call will explore the scenario where the current element is not included in the subsequence.
Second Recursive Call Explained:
The second recursive call is responsible for exploring the subsequences that do not include the current element.

After the first recursive call returns, the algorithm has explored all subsequences that include the current element.
The algorithm then removes the current element from the current list to backtrack.
Following this, the second recursive call is made. This call moves to the next element (index + 1), but with the current element excluded from the current subsequence.
This way, all subsequences that do not include the current element are explored.
Overall Process:
By alternating between including and excluding each element and recursively calling the function with the next index, the algorithm systematically explores all possible combinations of the elements in the array. Each time the base case is reached (when index == arr.Length), a complete subsequence (either including or excluding certain elements) is added to the list of subsequences.

This method ensures that every possible subsequence, from the empty subsequence to the full array, is generated and added to the list subsequences.

         */



        // if you want to return the subsequence list in reverse order first you do not take then take the current elelemnt 
        public List<List<int>> GetSubsequenceRev(int[] arr)
        {
            var subsequences = new List<List<int>>(); // carrying this Data Structure over the recursion calls 
            FindSubsequencesRev(arr, 0, new List<int>(), subsequences);
            return subsequences;
        }

        // Recursive function to find all subsequences
        static void FindSubsequencesRev(int[] arr, int index, List<int> current, List<List<int>> subsequences)
        {
            if (index == arr.Length)
            {
                // When index reaches the end of the array, add the current subsequence to the list
                subsequences.Add(new List<int>(current)); //  The list of all subsequences found so far.
                return;
            }

            FindSubsequences(arr, index + 1, current, subsequences);

            // Include the current element
            current.Add(arr[index]); // The current subsequence being constructed., take the element at index in the current subsequence
            FindSubsequences(arr, index + 1, current, subsequences);
            current.RemoveAt(current.Count - 1);  

        }


        /*
         return or print list of subsequences whose sum is equal to K 
        remember this technique , it will be used a lot in DP

        [1,2,3] k =2  => {1,1}, {2}

         */

        public List<List<int>> GetSubSequenceSumK(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            GetSubSequenceSumKRec(arr, 0, new List<int>(), result, k);
            return result;
        }
        private void GetSubSequenceSumKRec(int[] arr, int index, List<int> current, List<List<int>> result, int k)
        {
            if(index == arr.Length)
            {
                if(current.Sum() == k)
                    result.Add(new List<int>(current));
                return;
            }
            current.Add(arr[index]);
            GetSubSequenceSumKRec(arr, index+1, current, result, k);
            current.RemoveAt(current.Count - 1);
            GetSubSequenceSumKRec(arr, index+1, current, result, k);
        }

        public List<List<int>> GetSubSequenceSumK2(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            GetSubSequenceSumKRec2(arr, 0, 0, new List<int>(), result, k);
            return result;
        }
        private void GetSubSequenceSumKRec2(int[] arr, int index, int sum, List<int> current, List<List<int>> result, int k)
        {
            if (index == arr.Length)
            {
                if (sum == k)
                    result.Add(new List<int>(current));
                return;
            }
            current.Add(arr[index]);
            sum += arr[index];
            GetSubSequenceSumKRec2(arr, index + 1, sum, current, result, k);
            current.RemoveAt(current.Count - 1);
            sum -= arr[index];
            GetSubSequenceSumKRec2(arr, index + 1, sum, current, result, k);
        }

        // what if we want to print only the first sub sequence that is equal to k , not all of them 


        //using global variable
        bool flag = false; // global variable not recommended 
        public List<List<int>> GetSubSequenceSumK3(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            GetSubSequenceSumKRec3(arr, 0, new List<int>(), result, k);
            return result;
        }
        private void GetSubSequenceSumKRec3(int[] arr, int index, List<int> current, List<List<int>> result, int k)
        {
            if (index == arr.Length)
            {
                if (current.Sum() == k && !flag)
                {
                    result.Add(new List<int>(current));
                    flag = true;
                }
                return;
            }
            current.Add(arr[index]);
            GetSubSequenceSumKRec3(arr, index + 1, current, result, k);
            current.RemoveAt(current.Count - 1);
            GetSubSequenceSumKRec3(arr, index + 1, current, result, k);
        }

        // when we want to print or return only the first occurance of the sub sequence that is = k , 
        // in the base case once we found an aswer there is not need to execute the rest of the recursive calls 
        /*
         so int base case 
        if(satisfied or found) 
            return true 
        else 
            return false 
         */



        // Function to find the first subsequence with a sum equal to k
        static List<int> FindSubsequenceWithSum(int[] arr, int k)
        {
            var result = new List<int>();
            bool found = FindSubsequenceRecursive(arr, 0, new List<int>(), k, result);
            return found ? result : null;
        }

        // Recursive function to find the subsequence
        static bool FindSubsequenceRecursive(int[] arr, int index, List<int> current, int k, List<int> result)
        {
            // If the sum of current subsequence is k, copy to result and return true
            if (Sum(current) == k)
            {
                result.AddRange(current);
                return true;
            }

            // If index reaches the end of the array, return false
            if (index == arr.Length) // condition not stisfied 
            {
                return false;
            }

            // Include the current element and check
            current.Add(arr[index]);
            if (FindSubsequenceRecursive(arr, index + 1, current, k, result))// we put the next function call in an if statement 
                // if true then imediately return there is no need to go beyond
            {
                return true;
            }

            // Exclude the current element (backtrack) and check
            current.RemoveAt(current.Count - 1);
            return FindSubsequenceRecursive(arr, index + 1, current, k, result);
        }

        // Helper function to calculate the sum of elements in a list
        static int Sum(List<int> list)
        {
            int sum = 0;
            foreach (int num in list)
            {
                sum += num;
            }
            return sum;
        }


        public List<List<int>> GetSubSequenceSumK5(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            GetSubSequenceSumKRec5(arr, 0, new List<int>(), result, k);
            return result;
        }
        private bool GetSubSequenceSumKRec5(int[] arr, int index, List<int> current, List<List<int>> result, int k)
        {
            if (index == arr.Length)
            {
                if (current.Sum() == k)
                {
                    result.Add(new List<int>(current));
                    return true;
                }
                return false; // if condition above is met this line will never be executed
            }
            current.Add(arr[index]);
            if(GetSubSequenceSumKRec5(arr, index + 1, current, result, k)) // using these if statements we prevent the future calls
                return true;
            current.RemoveAt(current.Count - 1);
            if(GetSubSequenceSumKRec5(arr, index + 1, current, result, k))
                return true;
            return false; // if non of the conditions meet 
        }

        /*
         write a function to return the number of subsequences that are equal to k 
        in the base case return 1 if the condition is stisfied and return 0 if the condition is not satisfied 
        l = f()
        r = f()
        return l+r;

        f()
        {
            base case
            if(true) 
                return 1
            else
                return 0

            l = f()
            r = f()
            return l+r
        }

        if we have n resursive calls 
        {
            int sum = 0; 
            for(i=0 -> n)
            {
                sum += f()
            }
            return sum
        }
         */
        public int GetSubSequenceSumK6(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            GetSubSequenceSumKRec6(arr, 0, new List<int>(), result, k);
            return result.Count;
        }
        private void GetSubSequenceSumKRec6(int[] arr, int index, List<int> current, List<List<int>> result, int k)
        {
            if (current.Sum() > k) // additional base case for optimization 
                return;
            if (index == arr.Length)
            {
                if (current.Sum() == k)
                {
                    result.Add(new List<int>(current));
                }
                return;
            }
            current.Add(arr[index]);
            GetSubSequenceSumKRec6(arr, index + 1, current, result, k);
            current.RemoveAt(current.Count - 1);
            GetSubSequenceSumKRec6(arr, index + 1, current, result, k);
        }

        public int GetSubSequenceSumK7(int[] arr, int k)
        {
            return GetSubSequenceSumKRec7(arr, 0, new List<int>(), k);
        }
        private int GetSubSequenceSumKRec7(int[] arr, int index, List<int> current, int k)
        {
            if (current.Sum() > k) // additional base case for optimization 
                return 0;
            if (index == arr.Length)
            {
                if (current.Sum() == k)
                {
                    return 1;
                }
                return 0;
            }
            current.Add(arr[index]);
            int left = GetSubSequenceSumKRec7(arr, index + 1, current, k);
            current.RemoveAt(current.Count - 1);
            int right = GetSubSequenceSumKRec7(arr, index + 1, current,  k);
            return left + right;
        }

        // Function to count the number of subsequences with a sum equal to k
        public int GetSubSequenceSumK8(int[] arr, int k) // O(2^n) because there are 2 options for each index 
        {
            return CountSubsequencesWithSum(arr, k, 0, 0);
        }
        static int CountSubsequencesWithSum(int[] arr, int k, int index, int currentSum)
        {
            // If we've reached the end of the array
            if (index == arr.Length)
            {
                // If the current sum is equal to k, we've found a valid subsequence
                return currentSum == k ? 1 : 0;
            }

            // Include the current element in the sum and recurse
            int countIncludingCurrent = CountSubsequencesWithSum(arr, k, index + 1, currentSum + arr[index]);

            // Exclude the current element from the sum and recurse
            int countExcludingCurrent = CountSubsequencesWithSum(arr, k, index + 1, currentSum);

            // Return the total count from both possibilities
            return countIncludingCurrent + countExcludingCurrent;
        }
    }
}

///*
// To immediately exit out of all recursive calls when a specific condition is met, without unwinding the entire call stack, you can use an exception-based approach in C#. This technique involves throwing a custom exception when the condition is met and catching it at the top-level caller of the recursive function.

//Let me show you how this can be implemented in the context of your previous example, where we need to find the first subsequence whose sum is equal to a given value k:
// */

//// Define a custom exception
//private class FoundSubsequenceException : Exception
//{
//    public List<int> Subsequence { get; private set; }

//    public FoundSubsequenceException(List<int> subsequence)
//    {
//        Subsequence = subsequence;
//    }
//}

//static void Main()
//{
//    int[] array = { 1, 2, 3, 4 };
//    int k = 5;

//    try
//    {
//        FindSubsequenceWithSum(array, k, new List<int>());
//    }
//    catch (FoundSubsequenceException e)
//    {
//        Console.WriteLine("Subsequence found with sum " + k + ": [" + string.Join(", ", e.Subsequence) + "]");
//    }
//}

//static void FindSubsequenceWithSum(int[] arr, int k, List<int> current)
//{
//    if (Sum(current) == k)
//    {
//        // Condition met, throw custom exception to exit all recursive calls
//        throw new FoundSubsequenceException(new List<int>(current));
//    }

//    if (current.Count == arr.Length) return;

//    for (int i = current.Count; i < arr.Length; i++)
//    {
//        current.Add(arr[i]);
//        FindSubsequenceWithSum(arr, k, current);
//        current.RemoveAt(current.Count - 1);
//    }
//}

//static int Sum(List<int> list)
//{
//    int sum = 0;
//    foreach (int num in list)
//    {
//        sum += num;
//    }
//    return sum;
//}