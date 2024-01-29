using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given a list arr of N integers, return sums of all subsets in it.

 

Example 1:

Input:
N = 2
arr[] = {2, 3}
Output:
0 2 3 5
Explanation:
When no elements is taken then Sum = 0.
When only 2 is taken then Sum = 2.
When only 3 is taken then Sum = 3.
When element 2 and 3 are taken then 
Sum = 2+3 = 5.
Example 2:

Input:
N = 3
arr = {5, 2, 1}
Output:
0 1 2 3 5 6 7 8
 */
namespace BackTracking_and_Recursion
{
    internal class Subset_Sums
    {
        // Function to find the sum of all possible subsets of the given array.

        // number of sub set for n = 2^n 


        public List<int> subsetSumsA(List<int> arr)
        {
            List<int> result = new List<int>();
            subsetSumsA(arr, 0, 0, result);
            result.Sort();
            return result;
        }
        private void subsetSumsA(List<int> arr, int index, int sum, List<int> result)
        {
            if(index >= arr.Count)
            {
                result.Add(sum);
                return;
            }
            subsetSumsA(arr, index + 1, sum + arr[index], result); // pick the element 
            subsetSumsA(arr, index + 1, sum , result); // not pick the element 

        }
        public List<int> subsetSums(List<int> arr, int N)
        {
            List<int> result = new List<int>();
            subsetSums(arr, N, 0, new List<int>(), result);
            result.Sort(); // Adding this to sort the results
            return result;
        }

        private void subsetSums(List<int> arr, int N, int index, List<int> current, List<int> result)
        {
            if (index == N)
            {
                result.Add(current.Sum());
                return;
            }

            // Include the current element
            /*
             we cannot pass the same current to each function call 
            In C#, lists are reference types, so when you modify current in one recursive call, it affects current in all other calls. You need to create a new list instance for each recursive call where you add an element. This way, each recursive path will have its own separate list, and the results won't interfere with each other.
             
            Creating a new list based on an existing list: new List<int>(current) creates a new list, newCurrentWithElement, which is a copy of the current list. This means that all the elements in current are copied into newCurrentWithElement. This is important for preserving the current state of the subset being built in the recursive calls.

Adding an element to the new list: The { arr[index] } part is using collection initializer syntax to add the element at the current index (arr[index]) of the array arr to the newly created list newCurrentWithElement. This is equivalent to first copying the current list and then calling newCurrentWithElement.Add(arr[index]).
             */
            List<int> newCurrentWithElement = new List<int>(current) { arr[index] };
            subsetSums(arr, N, index + 1, newCurrentWithElement, result);

            // Exclude the current element
            /*
             Excluding the current element:

Another new list is created, but this time it's just a copy of the current list current without adding the current element.
The recursive call is then made with this new list, effectively considering the subset that excludes the current element.
             */
            subsetSums(arr, N, index + 1, new List<int>(current), result);
        }


        public List<int> subsetSums2(List<int> arr, int N)
        {
            List<int> result = new List<int>();
            subsetSums2(arr, N, 0, new List<int>(), result);
            result.Sort(); // Adding this to sort the results
            return result;
        }

        private void subsetSums2(List<int> arr, int N, int index, List<int> current, List<int> result)
        {
            if (index == N)
            {
                result.Add(current.Sum());
                return;
            }

            List<int> newCur = new List<int>(current);
            newCur.Add(arr[index]);
            subsetSums2(arr, N, index+1, newCur, result);
            newCur.RemoveAt(newCur.Count - 1);
            subsetSums2(arr, N, index + 1, new List<int>(newCur), result);
        }

    }
}
