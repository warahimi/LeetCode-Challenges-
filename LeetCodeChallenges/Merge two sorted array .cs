using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class Merge_two_sorted_array
    {
        public int[] merge(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] <= arr2[j])
                {
                    result[k] = arr1[i];
                    i++;
                }
                else
                {
                    result[k] = arr2[j];
                    j++;
                }
                k++;
            }
            while (i < arr1.Length)
            {
                result[k] = arr1[i];
                i++;
                k++;
            }
            while (j<arr2.Length)
            {
                result[k] = arr2[j];
                k++;
                j++;
            }
            if(result.Length % 2 == 0)
            {
                int mid = result.Length / 2;
                //Console.WriteLine("Median: " + (double)(result[mid-1] + result[mid])/2);
            }
            else
            {
                int mid = result.Length / 2;
                //Console.WriteLine("Median: " +  result[mid]);
            }
            return result;
        }
        public int[] merge2(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
            {
                throw new ArgumentNullException("Input arrays cannot be null");
            }
            if(arr1.Length == 0)
            {
                return arr2;
            }
            if(arr2.Length == 0)
            {
                return arr1;
            }

            int[] result = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] <= arr2[j])
                {
                    result[k++] = arr1[i++];
                }
                else
                {
                    result[k++] = arr2[j++];
                }
            }

            // Copy remaining elements from arr1, if any
            if (i < arr1.Length)
            {
                Array.Copy(arr1, i, result, k, arr1.Length - i);
            }

            // Copy remaining elements from arr2, if any
            if (j < arr2.Length)
            {
                Array.Copy(arr2, j, result, k, arr2.Length - j);
            }

            return result;
        }

    }
}
