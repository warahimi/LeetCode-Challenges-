using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

    0 <= a, b, c, d < n
    a, b, c, and d are distinct.
    nums[a] + nums[b] + nums[c] + nums[d] == target
    You may return the answer in any order.
 */
namespace LeetCodeChallenges
{
    internal class _18_4Sum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> temp;
            HashSet<string> set = new HashSet<string>();
            int n = nums.Length;
            for(int i = 0; i < n; i ++)
            {
                for(int j = i+1; j < n; j ++)
                {
                    for(int k = j+1; k < n; k ++)
                    {
                        for(int l = k+1; l < n; l ++)
                        {
                            if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                            {
                                temp = new List<int> { nums[i] , nums[j] , nums[k] , nums[l] };
                                temp.Sort();
                                string s = String.Join(",", temp);
                                if(!set.Contains(s))
                                {
                                    result.Add(temp);
                                    set.Add(s);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }


        public IList<IList<int>> FourSum2(int[] nums, int target)
        {
            IList<IList<int>> parentList = new List<IList<int>>();

            SumHelper(nums, target, parentList);
            return parentList;
        }

        private void SumHelper(int[] number, int target, IList<IList<int>> parentList)
        {
            Array.Sort(number);

            for (int i = 0; i < number.Length - 3; i++)
            {

                if (i > 0 && number[i] == number[i - 1])
                {
                    continue;
                }

                for (int j = i + 1; j < number.Length - 2; j++)
                {

                    if (j > (i + 1) && number[j] == number[j - 1])
                    {
                        continue;
                    }
                    int left = j + 1;
                    int right = number.Length - 1;

                    while (left < right)
                    {
                        long numberSum = (long)number[i] + (long)number[j] + (long)number[left] + (long)number[right];

                        if (numberSum == target)
                        {
                            parentList.Add(new List<int>() { number[i], number[j], number[left], number[right] });

                            while (left < right && number[left] == number[left + 1])
                            {
                                left++;
                            }
                            while (left < right && number[right] == number[right - 1])
                            {
                                right--;
                            }
                            left++;
                            right--;
                        }
                        else if (numberSum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }
        }

        public IList<IList<int>> FourSum4(int[] nums, int target)
        {

            Array.Sort(nums);
            int len = nums.Length;
            long sum;
            int left;
            int right;
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < len - 3; i++)
            {
                for (int j = i + 1; j < len - 2; j++)
                {
                    left = j + 1;
                    right = len - 1;

                    while (left < right)
                    {
                        sum = (long)nums[i] + (long)nums[j] + (long)nums[left] + (long)nums[right];
                        if (sum == target)
                        {
                            CheckAndAdd(result, nums[i], nums[j], nums[left], nums[right]);
                            left++;
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                    while (j < len - 2 && nums[j + 1] == nums[j])
                    {
                        j++;
                    }
                }

                while (i < len - 3 && nums[i + 1] == nums[i])
                {
                    i++;
                }
            }
            return result;
        }

        static void CheckAndAdd(IList<IList<int>> result, int a, int b, int c, int d)
        {
            if (result.Count == 0)
            {
                result.Add(new List<int> { a, b, c, d });
            }
            else if (result[result.Count - 1][0] != a || result[result.Count - 1][1] != b || result[result.Count - 1][2] != c)
            {
                result.Add(new List<int> { a, b, c, d });
            }
            return;
        }
    }
}
