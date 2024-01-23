using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class _78_Subsets_BackTracking
    {
        // "Subsets", requires generating all possible subsets of a given set of integers
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            backTracking(result, new List<int>(), nums, 0);
            return result;
        }
        private void backTracking(IList<IList<int>> result, IList<int> tempList, int[] nums, int index)
        {
            result.Add(new List<int>(tempList));
            for(int start = index; start < nums.Length; start++)
            {
                // choice 1 add the number
                tempList.Add(nums[start]);
                //back tracking
                backTracking(result, tempList, nums, start+1);

                // choice 2 do not add the number 
                tempList.RemoveAt(tempList.Count-1);
            }
        }


        public IList<IList<int>> Subsets2(int[] nums)
        {
            IList<IList<int>> subsets = new List<IList<int>>();
            GenerateSubsets(0, nums, new List<int>(), subsets);
            return subsets;
        }

        private void GenerateSubsets(int index, int[] nums, List<int> current, IList<IList<int>> subsets)
        {
            // Add the current subset to the list of subsets
            subsets.Add(new List<int>(current));

            for (int i = index; i < nums.Length; i++)
            {
                // Include the current element
                current.Add(nums[i]);

                // Recurse with the next element
                GenerateSubsets(i + 1, nums, current, subsets);

                // Backtrack: remove the current element before going to the next
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
