using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
/*
 * Divid and conqure alg 
Quick Sort is a popular sorting algorithm that is based on the divide-and-conquer strategy. Here's a step-by-step explanation 
of how it works:

1- Choose a Pivot: Select an element from the array as the pivot. The choice of pivot can affect the efficiency of the sort. 
Common strategies include picking the first element, the last element, a random element, or the median.

2- Partitioning: Rearrange the array so that all elements with values less than the pivot come before it, 
while all elements with values greater than the pivot come after it. After this partitioning, the pivot is in its final 
position.

3- Recursion: Recursively apply the above steps to the sub-array of elements with smaller values and the sub-array of 
elements with greater values.

The recursion ends when the size of the sub-array becomes 1, as a single element is always sorted.

Quick sort also take O(n logn) but with (1) space, because unlike merge sort we do not use extra memory to store the sorted merge of two sub arrays 
Qucik sort is slighty better than the merge sort , because we use 2 pointers to sort the sub arrays instead of creating a new temp list

Steps:
    1- pick a pivot: a pivot can be any element in the array (first or last or median or random)
    2- once picked a pivot placed in its correct sorted order in the array 
    3- smaller on the left and bigger on the right 
        all the element in the left of pavite will be smaller thatn pivot and all the elements in the rgith sub array will be greater 
        than the pivot 
    after these 3 steps one element or the pivote is sorted it will at its right position in sorted array 
    
    so far the left sub array and right sub arrays are not sorted 
    we keep reapting these steps for each elements of the right sub array and left sub array 


    we can apply recursion becase the same algorithm is applied on left and right sub array 


    lets say we take the first element as the pivot 
    low = 0 
    high = n-1
    
    i = 0; 
    j = n-1 
    using i loop throught the array until you find an element that is greater than the pivit and stop 
    if(arr[i] > pivit)
        stope 
    using j traverse backward until you find an element that is smaller than pivot and stop 

then    swap(arr[i], arr[j])
and continue doing this until i crosses j

once j crosses i , j will be at place where all elements ti right of it will smaller than pivot so 
swap(pivot, arrp[j]) this will place the pivot in the correct order 
the pivot index will act as partion index , where all element to the left of pivot will be smaller than pivot (but not sorted) 
and all elements to the right of the pivot will be greater than the pivot but not sorted 

left subarray will be [low, partion-1] or piovote index -1
right subarray will be [partition+1, hight]
perform quick sort on left and right sub arrays 

pseudo code:

QS(arr, low, high) // the arr we want to sort is from low to high
{
    if(low < high) // array should have more than one element if(low == hight) there is one element 
    {
        // sort it
        int partitionIndex = partition(arr, low, high) //step1 for this array from low to high place the pivot in the right location and return its index
        QS(arr, low, partitionIndex-1) // left sub array
        QS(arr, partitionIndex+1, high)
    }
}

int partition(arr, low, high)
{
    pivot = arr[low] // first element of the array 
    int i = low; 
    int j = high; 
    while ( i < j ) 
    {
        // find the first element that is greater than the pivot 
        while(arr[i] <= pivot) // this is not the element we are looking for 
        {
            i++;
        }
}

*/
namespace BackTracking_and_Recursion
{

    
    internal class QuickSort_Using_Recursion
    {
        public void QuickSort(int[] arr) // O(n log n) 
        {
            QuickSort(arr, 0 , arr.Length-1);
        }
        private void QuickSort(int[] arr, int low, int high) // the arr we want to sort is from low to high
        {
            if (low < high) // array should have more than one element if(low == hight) there is one element 
            {
                // sort it
                int partitionIndex = partition(arr, low, high); //step1 for this array from low to high place the pivot in the right location and return its index
                QuickSort(arr, low, partitionIndex - 1); // left sub array
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        private int partition(int[] arr, int low, int high)
        {
            int pivot = arr[low]; // first element of the array 
            int i = low;
            int j = high;
            while (i < j) //  o(n)
            {
                //start from left and find the first element that is greater than the pivot 
                while (arr[i] <= pivot && i <= high-1) // this is not the element we are looking for, i should not cross the array boundary (i<=high) 
                {
                    // looking for an item greater than pivot 
                    i++;
                }
                // start from the right / end of array and look for item that is less than the pivot 
                while (arr[j] > pivot && j >= low+1)
                {
                    // finding the element that is less than the pivot 
                    j--;
                }
                // if i and j have not crossed swap them 
                if(i < j)
                {
                    Swap(arr, i, j); // putting smaller elements to the left of pivot and greater element to the right of pivot
                }
                // if i cross j do not swap 
            }
            // swap pivite with arr[j]
            Swap(arr, low, j); // pivot is at arr[low]
            return j; // the pivot came to jth index 
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        // Method to perform QuickSort
        private void QuickSort2(int[] arr)
        {
            QuickSort2(arr, 0, arr.Length - 1);
        }
        private void QuickSort2(int[] arr, int start, int end)
        {
            if (start < end)
            {
                // Partition the array and get the pivot index
                int pivotIndex = Partition2(arr, start, end);

                // Sort the elements before and after the partition
                QuickSort2(arr, start, pivotIndex - 1); // Before the pivot
                QuickSort2(arr, pivotIndex + 1, end);   // After the pivot
            }
        }

        // Method to partition the array
        static int Partition2(int[] arr, int start, int end)
        {
            // Use the last element as pivot for simplicity
            int pivot = arr[end];
            int i = (start - 1);

            for (int j = start; j <= end - 1; j++)
            {
                // If current element is smaller than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;    // increment index of smaller element
                    Swap2(arr, i, j);
                }
            }
            Swap2(arr, i + 1, end); // Place the pivot at the correct position
            return (i + 1); // Return the pivot index
        }

        // Method to swap elements in the array
        static void Swap2(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
