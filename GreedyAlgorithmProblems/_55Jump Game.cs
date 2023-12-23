using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _55Jump_Game
    {
        // greedy solution no extra space with O(n)
        // we start our work from end the array and work our way to the beginning to check of we can get to the beginning from last
        public bool CanJump(int[] nums)
        {
            int goal = nums.Length - 1;
            for (int i = goal; i >= 0; i--)
            {
                if (i + nums[i] >= goal) // at position to check of nums[i] which is jump check if we can reach the goal 
                {
                    goal = i; // shift the goal post closer to the beginning, i is the position from where we jump right now
                }
            }
            return goal == 0; // check if we reached the beginning 
        }

        public bool CanJump2(int[] nums)
        {
            int goal = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                {
                    goal = i;
                }
            }
            return goal == 0;
        }
    }
}
