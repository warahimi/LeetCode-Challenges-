using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class First_negative_integer_in_every_window_of_size_k
    {
        public long[] printFirstNegativeInteger(long[] arr, int K)
        {
            List<long> list = new List<long>();
            int n = arr.Length;
            int i = 0;
            int j = 0;
            while (j<n)
            {
                if( (j -  i + 1) < K )
                {
                    j++;
                }
                else if( (j - i + 1) == K) 
                {
                    bool flag = false;
                    for (int l = i; l <i+ K; l++)
                    {
                        if (arr[l] < 0)
                        {
                            list.Add(arr[l]);
                            flag = true;
                            break;
                        }
                    }
                    if(!flag)
                    {
                        list.Add(0);
                    }
                    i++;
                    j++;
                }
            }
            return list.ToArray();
        }

        /*
            To optimize and comment your code for printing the first negative integer in every window of 
        size K in an array, I will focus on reducing the time complexity. The current implementation has a time complexity 
        of O(n*K), where n is the length of the array, due to the nested loop. We can optimize it by using a Deque 
        (double-ended queue) to keep track of the negative numbers in the current window. This approach will bring down the
        time complexity to O(n).
         */

        public long[] printFirstNegativeInteger2(long[] arr, int K)
        {
            List<long> result = new List<long>(); // Stores the final results
            LinkedList<int> deque = new LinkedList<int>(); // Deque to store indices of negative numbers

            int i;
            for (i = 0; i < K; ++i)
            {
                if (arr[i] < 0)
                    deque.AddLast(i); // Add index of the negative number to the deque
            }

            for (; i < arr.Length; ++i)
            {
                // Add the first negative number of the previous window
                if (deque.Count != 0)
                    result.Add(arr[deque.First.Value]);
                else
                    result.Add(0); // If there is no negative number in the previous window

                // Remove the elements which are out of this window
                while (deque.Count != 0 && deque.First.Value <= i - K)
                    deque.RemoveFirst();

                // Add current element at the rear of deque if it is a negative number
                if (arr[i] < 0)
                    deque.AddLast(i);
            }

            // Add the first negative number of the last window
            if (deque.Count != 0)
                result.Add(arr[deque.First.Value]);
            else
                result.Add(0);

            return result.ToArray(); // Convert the result list to an array and return
        }

        public void printFirstNeg(long[] arr, int k)
        {
            for(int i = 0; i < arr.Length - k + 1; i++)
            {
                bool flag = false;
                for(int j = i; j < i+k; j++)
                {
                    if (arr[j] < 0) // repetitive work
                    {
                        Console.Write(arr[j] + " ");
                        flag = true;
                        break;
                    }
                }
                if(!flag)
                {
                    Console.Write(0 + " ");
                }
            }
        }
        public void printFirstNeg2(long[] arr, int k)
        {
            int i = 0; 
            int j = 0;
            while(j < arr.Length)
            {
                if(j-i+1 < k)
                {
                    j++;
                }
                if(j-i + 1 == k)
                {
                    bool flag = false;
                    for(int l =  i; l < i+k; l++)
                    {
                        if (arr[l] < 0)
                        {
                            Console.Write(arr[l] + " ");
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        Console.Write(0 + " ");
                    i++;
                    j++;
                }
            }
        }
        public long[] firstNegativeOptimized(long[] arr, int k)
        {
            int j = 0; 
            int i = 0;
            int n = arr.Length;

            List<long> negatives = new List<long>();
            List<long> result = new List<long>();
            while(j < n)
            {
                // calculation 
                if (arr[j] < 0) // we need negative number to extract the answer
                {
                    negatives.Add(arr[j]);
                }

                if(j-i+1 <k) // if window size is less than k , just j++
                {
                    j++; // increase the window size
                }
                else if(j-i+1 == k) // if we hit the windwo size
                {
                    // 1- calculate the answer 
                    // as we move the window and if a negative number is excluded from the begining of 
                    // the window we remove that negative number from list as well 
                    // the first negative number in a window will always be in the front of the list of queueu 
                    // if there is not negative number in the window then list or queue will be empty, then we return 0 
                    if(negatives.Count == 0)
                    {
                        result.Add(0);
                    }
                    else
                    {
                        result.Add(negatives[0]);
                    }

                    // 2 slid the window 
                    if (negatives.Count() != 0 && arr[i] == negatives[0]) // if the beginning of the window is -ve remove from window and from negative list
                    {
                        negatives.RemoveAt(0);
                    }
                    i++;
                    j++;

                }
            }
            return result.ToArray();
        }
    }
}
