using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class Sliding_Window_Maximum
    {
        // https://www.interviewbit.com/problems/sliding-window-maximum/
        public List<int> slidingMaximum(List<int> A, int B)
        {
            if(B > A.Count)
            {
                return new List<int>() { 1};
            }
            List<int> result = new List<int>();
            int i = 0;
            int j = 0;
            int n = A.Count;
            int k = B;
            List<int> l = new List<int>();
            while(j < n)
            {
                if(j-i+1 < k)
                {
                    l.Add(A[j]);
                    j++;
                }
                if(j-i+1 == k)
                {
                    l.Add((A[j]));
                    result.Add(getMax(l));
                    l.RemoveAt(0);
                    i++;
                    j++;
                }
            }
            return result;
        }
        private int getMax(List<int> l)
        {
            int max = int.MinValue;
            foreach(int i in l)
            {
                if(i > max)
                    max = i;
            }
            return max;
        }


        // Brute Force O(n*B)
        public List<int> slidingMaximum2(List<int> A, int B)
        {
            List<int> result = new List<int>();
            for(int i = 0; i <= A.Count - B; i++ )
            {
                int max = int.MinValue;
                for(int j = i; j < i + B; j++ )
                {
                    if(A[j] > max )
                        max = A[j];
                }
                result.Add(max);
            }
            return result;
        }

        // if we are at j any sammler element that is to the left of j will not be included in the result so we remove it from our list or queue 
        // a smaller element to the right of j may be a candidate for bigger element for its window 
        // any samller element to the left of the current element cannot be a candidate for biggest element in the current window 
        // before we add the jth element to the list we will check and remove all smaller element than jth element from list 
        // the max element for the curent window will alway be at the beginning of the list
        // because before adding the jth/current element to the list we check of the element are smaller that the jth if so we remove them 
        // when slidng the window and i++, we check if the front of front of the list equal to the ith element if so we remove it from the 
        // beginning of the list too 
        public List<int> slidingMaximum3(List<int> A, int B)
        {
            List<int> max = new List<int>();
            List<int> result = new List<int>();
            int k = B;
            int n = A.Count;
            int i = 0;
            int j = 0; 

            while(j < n )
            {
                if(j-i+1 <= k)
                {
                    while(max.Count > 0 && max.Last() < A[j])
                    {
                        max.RemoveAt(max.Count - 1);
                    }
                    max.Add(A[j]);
                    j++;
                }
                if(j-i+1 > k)
                {
                    result.Add(max[0]);
                    while (max.Count > 0 && max.Last() < A[j])
                    {
                        max.RemoveAt(max.Count - 1);
                    }
                    max.Add(A[j]);
                    j++;
                    if (max[0] == A[i])
                    {
                        max.Remove(max[0]);
                    }
                    i++;
                }
                
            }
            result.Add(max[0]);
            return result;
        }

        public List<int> slidingMaximum4(List<int> A, int B)
        {
            List<int> result = new List<int>();

            if (A.Count == 0 || B <= 0)
            {
                return result;
            }

            LinkedList<int> deque = new LinkedList<int>(); // Using a double-ended queue

            for (int i = 0; i < A.Count; i++)
            {
                // Remove elements out of the current window
                if (deque.Count > 0 && deque.First.Value <= i - B)
                {
                    deque.RemoveFirst();
                }

                // Remove elements smaller than the current element from the back of the deque
                while (deque.Count > 0 && A[deque.Last.Value] < A[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i); // Add current element index to the deque

                // Add the maximum element of the current window to the result list
                if (i >= B - 1)
                {
                    result.Add(A[deque.First.Value]);
                }
            }

            return result;
        }
    }
}
