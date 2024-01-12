using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class Pick_Toys_An_Interesting_Sliding_Window_Problem
    {
        public int maxNumberOfToys(string s)
        {
            int max = 0;
            int i = 0;
            int curCount = 0; 
            if(s == null || s.Length == 0)
            {
                return max;
            }
            int j = 0;
            HashSet<char> set =new HashSet<char>();

            while(j < s.Length)
            {
                if (!set.Contains(s[j]) && set.Count < 2)
                {
                    set.Add(s[j]);
                    curCount++;
                }
                else if (set.Contains(s[j]) && set.Count <= 2)
                {
                    curCount++;
                }
                else // encountered a new character 
                {
                    set.Remove(s[i]);
                    char c = s[i];
                    max = Math.Max(max, curCount);
                    while (s[i] == c)
                    {
                        i++;
                        curCount--;
                    }
                    set.Add(s[j]);
                    curCount++ ;
                }
                j++;
            }
            return Math.Max(curCount, max);
        }

        /*
         For a more efficient solution to find the length of the longest substring containing at most two distinct characters, 
        we can use a sliding window approach. This approach involves maintaining a window that satisfies the condition 
        (at most two distinct characters) and adjusting its size as we iterate through the string.
         */
        public int maxNumberOfCharOfTwoTypes(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            int maxLen = 0;
            int left = 0;
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int right = 0; right < s.Length; right++)
            {
                // Add the current character to the dictionary or increment its count
                if (!charCount.ContainsKey(s[right]))
                {
                    charCount[s[right]] = 0;
                }
                charCount[s[right]]++;

                // Shrink the window until there are at most two distinct characters
                while (charCount.Count > 2)
                {
                    charCount[s[left]]--;
                    if (charCount[s[left]] == 0)
                    {
                        charCount.Remove(s[left]);
                    }
                    left++;
                }

                // Update the maximum length found so far
                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }

        /*
         You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.

        You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:

        You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
        Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.
        Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
        Given the integer array fruits, return the maximum number of fruits you can pick.

 

        Example 1:

        Input: fruits = [1,2,1]
        Output: 3
        Explanation: We can pick from all 3 trees.
        Example 2:

        Input: fruits = [0,1,2,2]
        Output: 3
        Explanation: We can pick from trees [1,2,2].
        If we had started at the first tree, we would only pick from trees [0,1].
        Example 3:

        Input: fruits = [1,2,3,2,2]
        Output: 4
        Explanation: We can pick from trees [2,3,2,2].
        If we had started at the first tree, we would only pick from trees [1,2].
         */

        public int TotalFruit(int[] fruits)
        {
            int left = 0;
            int max = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int right = 0; right < fruits.Length; right++)
            {
                if (!map.ContainsKey(fruits[right]))
                {
                    map[fruits[right]] = 0;
                }
                map[fruits[right]]++;
                while (map.Count > 2)
                {
                    map[fruits[left]]--;
                    if (map[fruits[left]] == 0)
                    {
                        map.Remove(fruits[left]);
                    }
                    left++;
                }
                max = Math.Max(max, right - left + 1);

            }
            return max;
        }

    }
}
