using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
-selection sort
-buble sort
- insertiosn sort
all these algorithms have O(n^2) time 

Merge SOrt has O(n logn) and nearly O(n) space 
 * 
 * 
1 - Divide : divid the problem into sub problems
2 - merge 
Merge sort is a divide-and-conquer algorithm that divides a list into equal halves until it has partitioned the entire array 
into segments containing a single element. Then it repeatedly merges these segments in a manner that results in a sorted list.
The basic steps of the merge sort algorithm are:

Divide: Divide the unsorted list into N sublists, each containing one element (a list of one element is considered sorted).
Conquer: Repeatedly merge sublists to produce new sorted sublists until there is only one sublist remaining. This will be 
the sorted list
*/
namespace BackTracking_and_Recursion
{
    internal class Merge_Sort_Using_Recursion
    {
        public void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length-1);
        }
        private void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                // Find the middle point
                int mid = left + (right - left) / 2;

                // Sort first and second halves
                MergeSort(arr, left, mid); // first sorts the left portion 
                MergeSort(arr, mid + 1, right); // once the left portions are all sorted and divided and return then this will sort the right portion 

                // Merge the sorted halves
                Merge(arr, left, mid, right);
            }
        }

        // Merges two subarrays of arr[]. First subarray is arr[l..m], Second subarray is arr[m+1..r]
        static void Merge(int[] arr, int left, int mid, int right) // left half of the array from left to mid, and right half from mid+1 to right
        {
            // Find sizes of two subarrays to be merged
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copy data to temp arrays
            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            // Merge the temp arrays back into arr[l..r]

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarray
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }


        public void MergeSort2(int[] arr)
        {
            MergeSort2(arr, 0, arr.Length - 1);
        }
        private void MergeSort2(int[] arr, int left, int right)
        {
            if(left >= right)
            {
                return;
            }
            int mid = (left + right) / 2;
            MergeSort2(arr, left, mid);
            MergeSort2(arr, mid+1, right);
            Merge2(arr,left, mid, right);
        }
        // basicall it merges the two hypotytical array [left...mid] and in [mid+1....right] into 3rd array 
        private void Merge2(int[] arr, int low, int mid , int high) // (n Longn)  , space O(n) becase of temp 
        {
            List<int> temp = new List<int>();
            int left = low; // starting index for left sub array 
            int right = mid+1; // starting index for the right sub arrau
            // all the elements of arr are present in [left...mid] and in [mid+1....right]

            // filling the arr
            while (left <= mid && right <= high) // till we have elements in the left sub array and the right sub array 
            {
                if (arr[left] <= arr[right])
                {
                    temp.Add(arr[left]);
                    left++;
                }
                else
                {
                    temp.Add(arr[right]);
                    right++;
                }
            }
            //here non or either of these while loops will be true not both 
            // if any thing remaining in the left 
            while(left <= mid)
            {
                temp.Add(arr[left]);
                left++;
            }
            // if any thing remaing in the right 
            while(right <= high)
            {
                temp.Add(arr[right]);
                right++;
            }
            // here the temp list contains the sorted elements from the left half and the right half
            // now it is time to put these sorted eleements to the main arr
            // we need to put from low to high 
            for(int i = low; i <= high; i++)
            {
                arr[i] = temp[i - low];
            }
        }

        public void MergeSort3(int[] arr)
        {
            MergeSort3(arr, 0, arr.Length - 1);
        }
        private void MergeSort3(int[] arr, int low, int high)
        {
            if(low >= high)
            {
                return;
            }
            int mid = (low + high) / 2;
            MergeSort3(arr, low, mid);
            MergeSort3(arr, mid + 1, high);
            Merge3(arr, low, mid, high);
        }
        private void Merge3(int[] arr, int low, int mid, int high)
        {
            List<int> temp = new List<int>();
            int left = low;
            int right = mid+1;
            while(left <= mid && right <= high)
            {
                if (arr[left] < arr[right])
                {
                    temp.Add(arr[left]);
                    left++;
                }
                else
                {
                    temp.Add(arr[right]);
                    right++;
                }
            }

            while(left <= mid)
            {
                temp.Add(arr[left]);
                left++;
            }
            while(right <= high)
            {
                temp.Add(arr[right] );
                right++;
            }
            for(int i = low; i <= high; i++)
            {
                arr[i] = temp[i - low];
            }
        }


        public void MergeSort4(int[] arr)
        {
            MergeSort4(arr, arr.Length);
        }

        // Recursive function to sort an array of integers.
        private void MergeSort4(int[] arr, int n)
        {
            int mid, i;
            if (n < 2) return; // base condition. If the array has less than two element, do nothing.

            mid = n / 2;  // find the mid index.

            // create left and right subarrays
            int[] leftSubArr = new int[mid];
            int[] rightSubArr = new int[n - mid];

            for (i = 0; i < mid; i++) 
                leftSubArr[i] = arr[i]; // creating left subarray
            for (i = mid; i < n; i++) 
                rightSubArr[i - mid] = arr[i]; // creating right subarray

            MergeSort4(leftSubArr, mid);  // sorting the left subarray
            MergeSort4(rightSubArr, n - mid);  // sorting the right subarray
            Merge4(arr, leftSubArr, mid, rightSubArr, n - mid);  // Merging L and R into A as sorted list.
        }

        // Function to Merge Arrays L and R into A.
        // leftCount = number of elements in L
        // rightCount = number of elements in R. 
        private void Merge4(int[] arr, int[] leftSubArr, int leftCount, int[] rightSubArr, int rightCount)
        {
            int i, j, k;

            // i - to mark the index of left subarray (leftSubArr)
            // j - to mark the index of right sub-array (rightSubArr)
            // k - to mark the index of merged subarray (arr)
            i = 0; j = 0; k = 0; // k indicates the main array index

            while (i < leftCount && j < rightCount)
            {
                if (leftSubArr[i] < rightSubArr[j]) arr[k++] = leftSubArr[i++];
                else arr[k++] = rightSubArr[j++];
            }
            while (i < leftCount) 
                arr[k++] = leftSubArr[i++];
            while (j < rightCount) 
                arr[k++] = rightSubArr[j++];
        }
    }
}
