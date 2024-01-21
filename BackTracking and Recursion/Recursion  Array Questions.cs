using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackTracking_and_Recursion
{
    internal class Recursion__Array_Questions
    {
        // give an array using recursion check if the array is sorted in ascending order
        public bool isSorted(int[] arr) // linear approach
        {
            if (arr == null || arr.Length <= 1)
            {
                // An empty array or a single-element array is considered sorted
                return true;
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i+1])
                    return false;
            }
            return true;
        }

        // the whole idea behind recursion is to break down the problem into smaller problem and solve them 
        // here in each recursion we just check 2 number from array arr[start] and arr[start+1]
        public bool isSortedRec(int[] arr)
        {
            return helper(arr, 0);
        }
        private bool helper(int[] arr, int start)
        {
            if(start ==  arr.Length - 1) // if the start pointer reached end of the array means the array is sorted and 
                // we did not find a arr[start] > arr[start+1]
            {
                return true;
            }
            else if (arr[start] > arr[start+1]) // found a voilation ? return false no need to check the rest of the array
            {
                return false;
            }
            return helper(arr, start+1);
        }

        static bool IsArraySorted(int[] array, int index = 0)// array points to the same object in each recursive call 
        {
            // Base case: If the array is empty, or we've reached the last element
            if (array == null || index >= array.Length - 1)
            {
                return true;
            }

            // Check if the current element is greater than the next element
            if (array[index] > array[index + 1])
            {
                return false; // Not sorted
            }
            else
            {
                // Recursive call with next element
                return IsArraySorted(array, index + 1);
            }
        }
        static bool IsArraySorted2(int[] array, int index = 0)
        {
            if(index == array.Length - 1)
                return true;
            return array[index] < array[index + 1] && IsArraySorted2(array, index+1);
        }


        /*
         * Given an array search for a target value
         *
         */

        public bool searchRec(int[] arr, int target)
        {
            return searchHelper(arr, target,0);
        }
        private bool searchHelper(int[] arr, int target, int index)
        {
            if (arr[index] == target)
            { return true; }
            else if(index == arr.Length - 1)
                return false;
            return searchHelper(arr, target, index+1);
        }



        public bool searchRec2(int[] arr, int target)
        {
            return searchHelper2(arr, target, 0);
        }

        private bool searchHelper2(int[] arr, int target, int index)
        {
            // Base case: if index reaches the end of the array
            if (index >= arr.Length)
                return false;

            // If the target is found
            if (arr[index] == target)
                return true;

            // Recursive call to check the next element
            return searchHelper2(arr, target, index + 1);
        }



        public int findIndex(int[] arr, int target)
        {
            return findIndexHelper(arr, target, 0);
        }
        private int findIndexHelper(int[] arr, int target, int index)
        {
            if (index == arr.Length )
            {
                return -1;
            }
            else if (arr[index] == target)
            {
                return index;
            }
            else
            {
                return findIndexHelper(arr, target, index + 1);
            }
        }

        public int findIndexFromLast(int[] arr, int target)
        {
            return findIndexHelperFromLast(arr, target, arr.Length-1);
        }
        private int findIndexHelperFromLast(int[] arr, int target, int index)
        {
            if (index < 0)
            {
                return -1;
            }
            else if (arr[index] == target)
            {
                return index;
            }
            else
            {
                return findIndexHelperFromLast(arr, target, index - 1);
            }
        }

        public List<int> findAllIndexes(int[] arr, int target)
        {
            List<int> result = new List<int>();
            findAllIndexesHelper(arr, target, 0, result);
            return result;
        }
        private void findAllIndexesHelper(int[] arr, int target, int index, List<int> result)
        {
            if(index >=  arr.Length)
            {
                return; 
            }
            else if (arr[index] == target)
            {
                result.Add(index);
            }
            findAllIndexesHelper(arr, target, index+1, result);
        }

        public List<int> findAllIndexes2(int[] arr, int target)
        {
            return findAllIndexesHelper2(arr, target, 0, new List<int>()); ;
        }
        private List<int> findAllIndexesHelper2(int[] arr, int target, int index, List<int> result)
        {
            if (index >= arr.Length)
            {
                return result;
            }
            else if (arr[index] == target)
            {
                result.Add(index);
            }
            return findAllIndexesHelper2(arr, target, index + 1, result);
        }

        /*
         Challenge / Concept
            now lets try to find all the indices of target and return a list without taking a list a arugument in recursive function call 
            we will create the list inside the body of th recursive function call instead of passsing it as argument. 
            when we create a list inside the body a new list will be created for each recursive call 
         */

        public List<int> findAllIndexes3(int[] arr, int target)
        {
            return findAllIndexesHelper3(arr, target, 0);
        }

        private List<int> findAllIndexesHelper3(int[] arr, int target, int index)
        {
            List<int> result = new List<int>();

            if (index >= arr.Length)
            {
                return result;
            }

            if (arr[index] == target)
            {
                result.Add(index);
            }

            result.AddRange(findAllIndexesHelper3(arr, target, index + 1));
            return result;
        }
        /*
         * A List<int> called result is created in each call, but it's only used to hold the indexes found in that specific call.
If the target is found at the current index, that index is added to result.
The method then calls itself recursively to check the rest of the array and uses AddRange to merge the results from the recursive call into the current result.
Finally, the combined result list is returned.

        The AddRange() method in C# is a member of the List<T> class, which is used to add multiple elements to the end of a List<T>. 
        This method is particularly useful when you want to append a collection of items 
        (like an array, another list, or any enumerable collection) to an existing list.

        Here's a breakdown of how AddRange() works:

Syntax:

public void AddRange(IEnumerable<T> collection)
The method takes a single argument, collection, which is an enumerable collection of the same type as the list.
Functionality:

The AddRange() method iterates over the elements in the provided collection and adds each of them to the end of the list.
This operation does not replace the existing elements in the list but rather appends the new elements to the list.
Use Case:

AddRange() is particularly useful when you need to concatenate two lists or add multiple elements to a list at once, rather than inserting them one by one using the Add() method.
Performance Consideration:

Using AddRange() can be more efficient than adding elements individually in a loop, especially for large collections, because AddRange() can optimize the resizing of the internal array used by the List<T>.

        each recursive call return either an empty list or a list with at most one item in it 
        An Empty List: This occurs if the current element at the index is not equal to the target, and the recursive call has reached the end of the array.

        A List with One Element: This happens when the current element at the index is equal to the target. In this case, the list will contain just that index
         */




        // Rotated Binary Search using recursion 
        // given a rotated sorted array do Binary Search 
        /*
         * To implement a binary search for a sorted and rotated array, you need a modified version of the standard binary search. 
         * A sorted and rotated array means the array was sorted and then rotated some number of times from a pivot point. 
         * For example, [3, 4, 5, 1, 2] is a sorted array [1, 2, 3, 4, 5] rotated at the pivot point between 5 and 1.

        The key to the modified binary search is to determine which part of the array (left or right half) is properly 
        sorted and then decide whether to search in the sorted or unsorted half based on the target value.
         */

        /*
         *  in both iterative and recursive approach, We need to determine which part of the array is properly sorted 
         *  and then decide in which part to continue the search
         */
        public int SearchInRotatedArray(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Finding the middle element

                if (arr[mid] == target) // Check if the middle element is the target
                {
                    return mid;
                }

                

                // Check if the left half is sorted
                if (arr[left] <= arr[mid]) // [5,6,7,8,9,1,2,3,4] target = 7
                {
                    // 2 condition either the target lies withing the left sorted part or not
                    // Target is in the left sorted half
                    if (target >= arr[left] && target < arr[mid])
                    {
                        right = mid - 1;
                    }
                    else // Target is in the right half
                    {
                        left = mid + 1;
                    }
                }
                else // Right half is sorted , // [5,6,7,8,9,1,2,3,4], target = 2 
                {
                    // Target is in the right sorted half
                    if (target > arr[mid] && target <= arr[right])
                    {
                        left = mid + 1;
                    }
                    else // Target is in the left half
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1; // Target not found
        }


        // recursive approach 
        public int SearchInRotatedArrayRec(int[] arr, int target)
        {
            return RecursiveSearch(arr, 0, arr.Length - 1, target);
        }
        static int RecursiveSearch(int[] arr, int left, int right, int target)
        {
            if (left > right)
            {
                return -1; // Base case: target not found
            }

            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid; // Target found
            }

            // Check if left side is sorted
            if (arr[left] <= arr[mid])
            {
                if (target >= arr[left] && target < arr[mid])
                {
                    return RecursiveSearch(arr, left, mid - 1, target); // Search left half
                }
                else
                {
                    return RecursiveSearch(arr, mid + 1, right, target); // Search right half
                }
            }

            // Right side is sorted
            if (target > arr[mid] && target <= arr[right])
            {
                return RecursiveSearch(arr, mid + 1, right, target); // Search right half
            }
            else
            {
                return RecursiveSearch(arr, left, mid - 1, target); // Search left half
            }
        }

        

    }
}
