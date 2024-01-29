using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class _90_Subsets_II
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums);  // Sort to handle duplicates
            SubsetsWithDup(nums, 0, new List<int>(), results);

            return results;
        }

        private void SubsetsWithDup(int[] nums, int index, List<int> current, IList<IList<int>> results)
        {
            results.Add(new List<int>(current));

            for (int i = index; i < nums.Length; i++)
            {
                // Skip duplicates
                if (i > index && nums[i] == nums[i - 1]) 
                    continue;

                // Include the current element
                current.Add(nums[i]);
                SubsetsWithDup(nums, i + 1, current, results);

                // Backtrack to explore subsets without the current element
                current.RemoveAt(current.Count - 1);
            }
        }

        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums);  // Sort to handle duplicates
            SubsetsWithDup2(nums, 0, new List<int>(), results);

            return results;
        }

        private void SubsetsWithDup2(int[] nums, int index, List<int> current, IList<IList<int>> results)
        {
            if (index == nums.Length)
            {
                results.Add(new List<int>(current));
                return;
            }

            // Include the current element
            current.Add(nums[index]);
            SubsetsWithDup2(nums, index + 1, current, results);

            // Exclude the current element - backtrack and skip duplicates
            current.RemoveAt(current.Count - 1);
            while (index + 1 < nums.Length && nums[index] == nums[index + 1])
            {
                index++;
            }
            SubsetsWithDup2(nums, index + 1, current, results);
        }
    }
}
