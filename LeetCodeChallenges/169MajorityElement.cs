using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _169MajorityElement
    {
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
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
            d.OrderByDescending(pair => pair.Value);
            return d.First().Key;
        }
        public int MajorityElement2(int[] nums)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
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
            //return d.OrderByDescending(pair => pair.Value).First().Key;
            foreach (var kvp in d)
            {
                if (kvp.Value > nums.Length / 2)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }

        public class Solution
        {
            public int MajorityElement3(int[] nums)
            {
                Array.Sort(nums); // O(nlogn)
                return nums[nums.Length / 2];
            }
        }

        public int MajorityElement4(int[] nums)
        {
            int majority = nums[0]; // asume the first element is the majority element 
            int vote = 1; // 1 vote for the first element
            for (int i = 1; i < nums.Length; i++)
            {
                if (vote == 0)
                {
                    majority = nums[i]; // update the majority element 
                    vote++; // and vote for it
                }
                else if (nums[i] == majority)
                {
                    vote++;
                }
                else
                {
                    vote--;
                }
            }
            return majority;
        }
    }
}
