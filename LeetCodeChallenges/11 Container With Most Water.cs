using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _11_Container_With_Most_Water
    {
        /*
         *  Brute Force
         *  we compute each single area and return the max among them 
         */
        public int MaxArea(int[] height)
        {
            int area = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int h = Math.Min(height[i], height[j]);
                    int w = j - i;
                    int curVol = h * w;
                    area = Math.Max(area, curVol);
                }
            }
            return area;
        }
        /*
         * we can do it in O(n) using the two pointer approach
         * we want to find the tallest hieght, so if the right pointer is smaller than the left pointer , shift the right pointer to 
         * left to look for a taller left value 
         * same with the left pointer 
         * 
         */
        public int MaxArea2(int[] height) // O(n)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int h = Math.Min(height[left], height[right]);
                int w = right - left;
                int curArea = h * w;
                maxArea = Math.Max(maxArea, curArea);
                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return maxArea;
        }
    }
}
