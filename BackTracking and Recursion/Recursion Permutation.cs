using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion_Permutation
    {
        // permutation means rearranging the elements 
        /*
         
        A permutation refers to an arrangement of elements in a specific order. In the context of mathematics and computer 
        science, it typically involves the arrangement of all or part of a set of objects, with regard to the order of the 
        arrangement.

        Key aspects of permutations include:

        Order Matters: Unlike combinations, where the order of elements does not matter, in permutations,
        the order is crucial. For example, the sequences "ABC" and "CBA" are considered different permutations of the set 
        {A, B, C}.

        Types of Permutations:

        Full Permutation: Involves arranging all members of a set into some sequence. For instance, the full permutations of the
        set {1, 2, 3} are {123, 132, 213, 231, 312, 321}.
        Partial Permutation: Involves arranging a subset of members of a set into a sequence. For example, the permutations of 
        two elements chosen from the set {1, 2, 3} are {12, 13, 21, 23, 31, 32}.
        Number of Permutations:

        The number of different permutations of a set of n elements is n! (n factorial), which is the product of all positive
        integers up to n.
        For partial permutations, where r elements are chosen from a set of n elements, the number of permutations is denoted 
        as P(n, r) and is calculated as n! / (n-r)!.



        Permutation of a string refers to the arrangement of its characters in all possible orders. Given a string, 
        its permutations are all the possible ways in which you can rearrange the characters of that string. The number of 
        permutations depends on the number of characters in the string and whether these characters are distinct or not.


        
        The subset problems we discussed earlier are examples of combinations, not permutations. Here's why:

        Combinations: In combinations, the order of elements does not matter. When generating subsets of a set (or elements of an array), the focus is on which elements to include, regardless of their order. For example, if you have a set {1, 2, 3}, then {2, 1} and {1, 2} are considered the same subset in terms of combinations.

        Permutations: In permutations, the order of elements is important. If we were generating permutations of a set, then {2, 1} and {1, 2} would be considered different
         */

        /*
         * given a string return all the permutations of 
         * 1- we use all the character to form permutations (all characters should be present in each permutation)
         * str = "abc"
            abc
            acb
            bac
            bca
            cab
            cba

        we can apply the subset method 
        permutation means the element can be in different positions 
        and remember recursion breaks down the problem into smaller problems 

        height/ depth of the tree is equal to the length of the string 
        as we move down the tree towards the leave and fixing the position of each char at each level the nuber of branches also decrease 
        at each level the number of branches/children decreases by one 
         */

        // Function to swap values at two positions in an array
        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        // Recursive function to generate permutations
        // Parameters:
        // 1. Array of characters (string)
        // 2. Starting index of the substring for permutation
        // 3. Ending index of the substring for permutation
        public void Permute(char[] array, int start, int end)
        {
            if (start == end)
            {
                Console.WriteLine(new String(array));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref array[start], ref array[i]);
                    Permute(array, start + 1, end);
                    Swap(ref array[start], ref array[i]); // backtrack
                }
            }
        }


      

        public IList<string> PermuteString(string str)
        {
            IList<string> permutations = new List<string>();
            char[] chars = str.ToCharArray();
            Permute(chars, 0, permutations);
            return permutations;
        }

        private void Permute(char[] chars, int startIndex, IList<string> permutations) // O(n * n!)
        {
            if (startIndex == chars.Length - 1)
            {
                permutations.Add(new string(chars));
                return;
            }

            for (int i = startIndex; i < chars.Length; i++)
            {
                // Swap the current element with the element at the start index
                Swap(chars, startIndex, i);

                // Recurse for the rest of the string
                Permute(chars, startIndex + 1, permutations);

                // Backtrack - swap the elements back to their original position
                Swap(chars, startIndex, i);
            }
        }

        private void Swap(char[] chars, int i, int j)
        {
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }


        // given an integer array print all its permutations 
        public void permuteArray(int[] array)
        {
            PermuteArrayHelper(array, 0);
        }
        private static void PermuteArrayHelper(int[] array, int startIndex)
        {
            if (startIndex == array.Length - 1)
            {
                PrintArray(array);
                return;
            }

            for (int i = startIndex; i < array.Length; i++)
            {
                Swap(array, startIndex, i);
                PermuteArrayHelper(array, startIndex + 1);
                Swap(array, startIndex, i); // backtrack
            }
        }
        // Helper method to swap elements in the array

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }


        // to return list of permutations
        // Function to initiate permutation process
        public IList<int[]> permuteArray2(int[] array)
        {
            IList<int[]> permutations = new List<int[]>();
            Permute2(array, 0, permutations);
            return permutations;
        }

        // Recursive function to generate permutations
        private static void Permute2(int[] array, int startIndex, IList<int[]> permutations)
        {
            if (startIndex == array.Length - 1)
            {
                permutations.Add((int[])array.Clone()); // Add a copy of the permutation to the list
                return;
            }

            for (int i = startIndex; i < array.Length; i++)
            {
                Swap(array, startIndex, i); // Swap for the next permutation
                Permute2(array, startIndex + 1, permutations); // Recurse for the next element
                Swap(array, startIndex, i); // Backtrack to the previous state
            }
        }
        /*
         * array.Clone(): This method call is the key part. The Clone() method is a member of the System.Array class in C#. When invoked on an array, it creates a shallow copy of the array. A shallow copy means that a new array object is created, but in the case of an array of primitives (like int), the individual elements (the integers themselves) are copied by value. This is because primitives in C# are value types.

Type Casting to (int[]): The Clone() method returns a reference of type object because it's defined in the base System.Object class and is meant to be usable with any type. However, in this specific context, you know that the original array is of type int[]. Therefore, you explicitly cast the result back to int[]. This cast tells the compiler that you are sure the object returned by Clone() is actually an int[]
         */


        // with out using clone()
        public IList<int[]> permuteArray3(int[] array)
        {
            IList<int[]> permutations = new List<int[]>();
            Permute3(array, 0, permutations);
            return permutations;
        }

        private static void Permute3(int[] array, int startIndex, IList<int[]> permutations)
        {
            if (startIndex == array.Length - 1)
            {
                permutations.Add(CopyArray(array)); // Add a copy of the permutation to the list
                return;
            }

            for (int i = startIndex; i < array.Length; i++)
            {
                Swap(array, startIndex, i);
                Permute3(array, startIndex + 1, permutations);
                Swap(array, startIndex, i); // backtrack
            }
        }
        // Method to manually copy the array
        private static int[] CopyArray(int[] source)
        {
            int[] copy = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = source[i];
            }
            return copy;
        }
    }
}
