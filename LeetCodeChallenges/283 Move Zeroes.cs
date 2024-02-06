using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _283_Move_Zeroes
    {
        public void MoveZeroes(int[] nums)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0 && queue.Count != 0)
                {
                    nums[queue.Dequeue()] = nums[i];
                    nums[i] = 0;
                    queue.Enqueue(i);
                }
                else if (nums[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
        }

        public void MoveZeroes2(int[] nums)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    queue.Enqueue(i); // Enqueue index of zero
                }
                else if (queue.Count > 0)
                {
                    // If current element is non-zero and there's at least one zero before it
                    int zeroIndex = queue.Dequeue(); // Get the index of the earliest zero
                    nums[zeroIndex] = nums[i]; // Move current non-zero element to the position of the first zero
                    nums[i] = 0; // Set the current position to zero
                    queue.Enqueue(i); // Enqueue current index as it's now a zero
                }
            }
        }
        public void MoveZeroes3(int[] nums)
        {
            // Pointer to keep track of the index of the last non-zero element found.
            int lastNonZeroFoundAt = 0;

            // Iterate through the array.
            for (int i = 0; i < nums.Length; i++)
            {
                // If the current element is not zero,
                if (nums[i] != 0)
                {
                    // Swap the current element with the element at lastNonZeroFoundAt.
                    // This step moves non-zero elements to the front of the array
                    // while preserving their original order.
                    int temp = nums[i];
                    nums[i] = nums[lastNonZeroFoundAt];
                    nums[lastNonZeroFoundAt] = temp;

                    // Increment lastNonZeroFoundAt to point to the next position.
                    lastNonZeroFoundAt++;
                }
            }
        }

        public void MoveZeroes4(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    j++;
                }
            }
        }
    }
}
