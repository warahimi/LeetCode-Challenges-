using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _4_Median_of_Two_Sorted_Arrays
    {
        /*
         Brute force O(m+n) time and O(m+n) space 
         */
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    result[k] = nums1[i];
                    i++;
                }
                else
                {
                    result[k] = nums2[j];
                    j++;
                }
                k++;
            }
            while (i < nums1.Length)
            {
                result[k] = nums1[i];
                i++;
                k++;
            }
            while (j < nums2.Length)
            {
                result[k] = nums2[j];
                k++;
                j++;
            }
            double median;
            if (result.Length % 2 == 0)
            {
                int mid = result.Length / 2;
                median = (double)(result[mid - 1] + result[mid]) / 2;
            }
            else
            {
                int mid = result.Length / 2;
                median =  (double) result[mid];
            }
            return median;
        }

        /*
            Brute force O(m+n) time and O(1) space
            we do not have to store the merged array , 
            we just need the indexes of the median values

        */
        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int n = nums1.Length + nums2.Length;
            // imaginary mergin the arrays and we need elements at these indices
            int index1 = n/2 - 1;
            int index2 = n / 2;
            int element1  = int.MinValue;
            int element2 = int.MinValue;
            int i = 0;
            int j = 0;
            int indexCount = 0;
            
            while(i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    if(indexCount == index1)
                    {
                        element1 = nums1[i];
                    }
                    if(indexCount == index2)
                    {
                        element2 = nums1[i];
                    }
                    indexCount++;
                    i++;
                }
                else
                {
                    if (indexCount == index1)
                    {
                        element1 = nums2[j];
                    }
                    if (indexCount == index2)
                    {
                        element2 = nums2[j];
                    }
                    indexCount++;
                    j++;
                }

                //Optimization 
                if(element1 != int.MinValue && element2 != int.MinValue)
                {
                    break;
                }
            }

            if (element1 == int.MinValue || element2 == int.MinValue) // optimization 
            {
                // checking for the remaining elements
                while (i < nums1.Length)
                {
                    if (indexCount == index1)
                    {
                        element1 = nums1[i];
                    }
                    if (indexCount == index2)
                    {
                        element2 = nums2[i];
                    }
                    indexCount++;
                    i++;
                }
            }


            if (element1 == int.MinValue || element2 == int.MinValue) // optimization
            {
                while (j < nums2.Length)
                {
                    if (indexCount == index1)
                    {
                        element1 = nums2[j];
                    }
                    if (indexCount == index2)
                    {
                        element2 = nums2[j];
                    }
                    indexCount++;
                    j++;
                }
            }
            
            if(n % 2 == 1)
            {
                return element2;
            }
            return (double) (element1 + element2) / 2;
        }

    }
}
