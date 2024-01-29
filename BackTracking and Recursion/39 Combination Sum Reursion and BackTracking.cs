using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    the problem is to print all the combinations or subsequences , 
    anyy problem asks about subsequences or combination can be solved using recursion 
    it asks us to pick elements from given array to form a combination 

    we can use the pick and not pick thought process , we can pick an elemnt more than one time 

    [2, 3, 6, 7] target 7
    0   1  2  3
    pp  p  x  x 
    
    0 index : pick pick 
    1 index : pick 
    2 index : not pick 
    3 index : not pick 
 */
namespace BackTracking_and_Recursion
{
    internal class _39_Combination_Sum_Reursion_and_BackTracking
    {
        public List<List<int>> CombinationSum(int[] arr, int target)
        {
            // Initialize a list to hold all possible combinations.
            List<List<int>> result = new List<List<int>>();

            // Optional: Sort the array to potentially optimize the process.
            // Sorting is not necessary for the logic but can help in certain cases.
            Array.Sort(arr);

            // Start the recursive function to find combinations.
            CombinationSum(arr, target, 0, new List<int>(), result);

            // Return the list of combinations found.
            return result;
        }

        private void CombinationSum(int[] arr, int target, int index, List<int> current, List<List<int>> result)
        {
            // If the sum of the current combination exceeds the target, stop further processing.
            if (current.Sum() > target) // If the sum of elements in 'current' exceeds the target, the function backtracks.
            {
                return;
            }

            // If the sum of the current combination equals the target, add it to the result.
            if (current.Sum() == target)
            {
                result.Add(new List<int>(current));
                return;
            }

            // Iterate through the array starting from the current index.
            for (int i = index; i < arr.Length; i++) // The function iterates over the array elements, starting from the current index, allowing for the repetition of elements in the combination.
            {
                // Add the current element to the combination.
                current.Add(arr[i]);

                // Recursively call the function to try adding more elements to the current combination.
                // 'i' is passed instead of 'index + 1' to allow the same element to be reused.
                CombinationSum(arr, target, i, current, result);

                // Remove the last element added to backtrack and try other combinations.
                current.RemoveAt(current.Count - 1);
            }
        }

        // without for loop
        public List<List<int>> CombinationSum2(int[] arr, int target)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationSum2(arr, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum2(int[] arr, int target, int index, List<int> current, List<List<int>> result)
        {
            // Base case: if the sum exceeds target, no need to proceed.
            if (current.Sum() > target)
            {
                return;
            }

            // If the sum equals the target, add the current combination to the result.
            if (current.Sum() == target)
            {
                result.Add(new List<int>(current));
                return;
            }

            // Check if we have reached the end of the array.
            if (index >= arr.Length)
            {
                return;
            }

            // Include the current element and explore further.
            current.Add(arr[index]);
            CombinationSum2(arr, target, index, current, result);// calling again with the same index since an element can be selected repeatedly 

            // Exclude the current element and explore further.
            current.RemoveAt(current.Count - 1);
            CombinationSum2(arr, target, index + 1, current, result);
        }

        public List<List<int>> CombinationSum3(int[] arr, int target)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationSum3(arr, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum3(int[] arr, int target, int index, List<int> current, List<List<int>> result)
        {
            if(index == arr.Length)
            {
                if(target == 0)
                {
                    result.Add(new List<int>(current)); // O(n) 
                }
                return;
            }

            if (arr[index] <= target)
            {
                current.Add(arr[index]);
                CombinationSum3(arr,target - arr[index], index, current, result); // each time we subtract the pick element from targe
                current.RemoveAt(current.Count-1);
            }
            CombinationSum3(arr, target, index + 1, current, result); // did not pick so move to the next element 
        }
    }
}
