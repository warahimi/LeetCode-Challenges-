using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
 
    Example 1:
    Input: nums = [1,1,1,2,2,3], k = 2
    Output: [1,2]
    Example 2:
    Input: nums = [1], k = 1
    Output: [1]
 */

namespace LeetCodeChallenges
{
    internal class _347TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int[] result = new int[k];
            foreach (int num in nums)
            {
                if (d.ContainsKey(num))
                {
                    d[num]++;
                }
                else
                {
                    d[num] = 1;
                }
            }

            var des = d.OrderByDescending(pair => pair.Value);
            var topK = des.Take(k);
            int i = 0;
            foreach (var kvp in topK)
            {
                result[i] = kvp.Key;
                i++;
            }
            return result;

            //return d.OrderByDescending(x => x.Value)
            //        .Take(k)
            //        .Select(x => x.Key)
            //        .ToArray();
        }

        public int[] TopKFrequent2(int[] nums, int k) // O(n)+O(n)
        {
            // Dictionary to store the frequency of each number
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (count.ContainsKey(num))
                    count[num]++;
                else
                    count[num] = 1;
            }

            // List of lists to store numbers with the same frequency
            List<List<int>> freq = new List<List<int>>(nums.Length + 1);
            for (int i = 0; i <= nums.Length; i++)
            {
                freq.Add(new List<int>());
            }

            // Group numbers by their frequency
            foreach (var pair in count)
            {
                int number = pair.Key;
                int frequency = pair.Value;
                freq[frequency].Add(number);
            }

            // Result list to store the most frequent numbers
            List<int> res = new List<int>();

            // Iterate from the highest frequency to the lowest
            for (int i = freq.Count - 1; i >= 0; i--)
            {
                foreach (var n in freq[i])
                {
                    res.Add(n);
                    if (res.Count == k)
                        return res.ToArray();
                }
            }

            return res.ToArray();
        }
    }
}

/*
    static void Main(string[] args)
        {

            // Sorting Dictionary Elements 
            Dictionary<int, int> d = new Dictionary<int, int>
            {
                {1, 5},
                {2, 3},
                {3, 1},
                {4, 4},
                {5, 2}
            };

            // Sort by values in ascending order
            var sortedAscending = d.OrderBy(pair => pair.Value);

            // Sort by values in descending order
            var sortedDescending = d.OrderByDescending(pair => pair.Value);

            Console.WriteLine("Ascending order:");
            foreach (var kvp in sortedAscending)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine("\nDescending order:");
            foreach (var kvp in sortedDescending)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Take the top 3 elements
            var top3Elements = sortedDescending.Take(3);

            Console.WriteLine("Top 3 elements in descending order:");
            foreach (var kvp in top3Elements)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
 */