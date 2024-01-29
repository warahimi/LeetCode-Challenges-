using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class _40_Combination_Sum_II
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates); // Sort the array first, because we need sorted combination and sorting help prevent duplicates (in lexigraphical order)
            CombinationSum2(candidates, target, 0, new List<int>(), result);
            return result;
        }
        private void CombinationSum2(int[] arr, int target, int index, List<int> current, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (i > index && arr[i] == arr[i - 1]) // if it is a repeatitive element not pick it 
                    continue; // Skip duplicates
                if (arr[i] > target)
                    break;
                if (arr[i] <= target)
                {
                    current.Add(arr[i]);
                    CombinationSum2(arr, target - arr[i], i + 1, current, result); // pass next index as i+1 not index+1
                    current.RemoveAt(current.Count - 1); // remove the elemen added in the previous step 
                }
            }
        }


        public IList<IList<int>> CombinationSum2B(int[] candidates, int target)
        {
            Array.Sort(candidates); // Sort the candidates to handle duplicates easily
            IList<IList<int>> result = new List<IList<int>>();
            CombinationSum2B(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum2B(int[] candidates, int target, int start, IList<int> current, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current)); // Found a valid combination
                return;
            }

            if (start >= candidates.Length || candidates[start] > target)
            {
                return; // No valid combination can be found further
            }

            // Include the current candidate
            current.Add(candidates[start]);
            CombinationSum2B(candidates, target - candidates[start], start + 1, current, result);
            current.RemoveAt(current.Count - 1); // Backtrack

            // Skip duplicates and move to the next distinct candidate
            while (start + 1 < candidates.Length && candidates[start] == candidates[start + 1])
            {
                start++;
            }

            // Exclude the current candidate and move to the next distinct candidate
            CombinationSum2B(candidates, target, start + 1, current, result);
        }

        // without sorting the candidates array and using HashSet to prevent duplicates 

        public IList<IList<int>> CombinationSum2C(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> set = new HashSet<string>(); // To track unique combinations
            Array.Sort(candidates); // Sort the array for efficient duplicate handling
            CombinationSum2C(candidates, target, 0, new List<int>(), result, set);
            return result;
        }

        private void CombinationSum2C(int[] arr, int target, int index, List<int> current, IList<IList<int>> result, HashSet<string> set)
        {
            if (target == 0)
            {
                string combinationKey = String.Join(",", current);
                if (!set.Contains(combinationKey))
                {
                    set.Add(combinationKey);
                    result.Add(new List<int>(current));
                }
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (i > index && arr[i] == arr[i - 1]) continue; // Skip duplicates

                if (arr[i] <= target)
                {
                    current.Add(arr[i]);
                    CombinationSum2C(arr, target - arr[i], i + 1, current, result, set);
                    current.RemoveAt(current.Count - 1); // Backtrack
                }
            }
        }
    }
}
