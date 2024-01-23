using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    // Backtracking algorithm paradigm
    internal class Back_Tracking
    {
        // "Subsets", requires generating all possible subsets of a given set of integers
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            backTracking(result, new List<int>(), nums, 0);
            return result;
        }
        private void backTracking(IList<IList<int>> result, IList<int> tempList, int[] nums, int index)
        {
            result.Add(new List<int>(tempList));
            for (int start = index; start < nums.Length; start++)
            {
                // choice 1 add the number
                tempList.Add(nums[start]);
                //back tracking
                backTracking(result, tempList, nums, start + 1);

                // choice 2 do not add the number 
                tempList.RemoveAt(tempList.Count - 1);
            }
        }


        public IList<IList<int>> Subsets2(int[] nums)
        {
            IList<IList<int>> subsets = new List<IList<int>>();
            GenerateSubsets(0, nums, new List<int>(), subsets);
            return subsets;
        }

        private void GenerateSubsets(int index, int[] nums, List<int> current, IList<IList<int>> subsets)
        {
            // Add the current subset to the list of subsets
            subsets.Add(new List<int>(current));

            for (int i = index; i < nums.Length; i++)
            {
                // Include the current element
                current.Add(nums[i]);

                // Recurse with the next element
                GenerateSubsets(i + 1, nums, current, subsets);

                // Backtrack: remove the current element before going to the next
                current.RemoveAt(current.Count - 1);
            }
        }

        /*
         * To modify your existing code for generating all subsets of an integer array to only include unique subsets,
         * especially when the input array contains duplicates, we need to make a couple of changes:

         Sort the Input Array: Sort the array to ensure that duplicates are adjacent. This makes it easier to skip 
        duplicates during the subset generation.

        Skip Duplicates in the Recursion: While iterating through the elements, if an element 
        is the same as the previous one, we skip it to avoid generating duplicate subsets.
         */
        public IList<IList<int>> Subsets2UniqueSubSet(int[] nums)
        {
            IList<IList<int>> subsets = new List<IList<int>>();
            Array.Sort(nums); // Sort the array to handle duplicates
            GenerateUniqueSubsets(0, nums, new List<int>(), subsets);
            return subsets;
        }

        private void GenerateUniqueSubsets(int index, int[] nums, List<int> current, IList<IList<int>> subsets)
        {
            subsets.Add(new List<int>(current));

            for (int i = index; i < nums.Length; i++)
            {
                // Skip duplicate elements
                if (i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }

                current.Add(nums[i]);
                GenerateUniqueSubsets(i + 1, nums, current, subsets);
                current.RemoveAt(current.Count - 1);
            }
        }

        /*
         * 
        To generate all unique subsets from an array containing duplicates without sorting the array, we can utilize 
        a hash set at each level of recursion to track and avoid processing duplicate elements. This method ensures that
        at each step, if we've already processed a particular number, we skip the subsequent duplicates of that number. 
        This approach avoids the time complexity incurred by sorting, but it introduces an additional space complexity 
        due to the usage of hash sets.
         */
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> subsets = new List<IList<int>>();
            SubsetsWithDupHelper(0, nums, new List<int>(), subsets);
            return subsets;
        }

        private void SubsetsWithDupHelper(int index, int[] nums, List<int> current, IList<IList<int>> subsets)
        {
            subsets.Add(new List<int>(current));
            HashSet<int> seen = new HashSet<int>(); // Track duplicates at this level

            for (int i = index; i < nums.Length; i++)
            {
                // If we've seen this element at the current level, skip it to avoid duplicates
                if (!seen.Add(nums[i]))
                {
                    continue;
                }

                // Include the current element and recurse
                current.Add(nums[i]);
                SubsetsWithDupHelper(i + 1, nums, current, subsets);

                // Backtrack and remove the current element
                current.RemoveAt(current.Count - 1);
            }
        }





        /*
         Subsets of a Specific Length: Instead of returning all subsets, return only those subsets that have a specific 
        length. This adds a constraint on the size of the subsets to be included in the result.
         */

        public IList<IList<int>> SubsetsOfSpecificLength(int[] nums, int length)
        {
            IList<IList<int>> subsets = new List<IList<int>>();
            GenerateSubsetsOfSpecificLength(0, nums, length, new List<int>(), subsets);
            return subsets;
        }

        private void GenerateSubsetsOfSpecificLength(int index, int[] nums, int length, List<int> current, IList<IList<int>> subsets)
        {
            // Add the subset only if it meets the desired length
            if (current.Count == length)
            {
                subsets.Add(new List<int>(current));
                return; // Stop further recursion as we've reached the desired length
            }

            for (int i = index; i < nums.Length; i++)
            {
                current.Add(nums[i]);
                GenerateSubsetsOfSpecificLength(i + 1, nums, length, current, subsets);
                current.RemoveAt(current.Count - 1); // Backtrack
            }
        }




        // given a string return all the sub sets of that string 
        public IList<IList<string>> stringSubSet(string input)
        {
            IList<IList<string>> result = new List<IList<string>>();
            stringSubSetHelper(input, result, new List<string>(), 0);
            return result;
        }
        private void stringSubSetHelper(string input, IList<IList<string>> result, IList<string> curStr, int index)
        {
            result.Add(new List<string>(curStr));
            for(int i = index; i < input.Length; i++)
            {
                curStr.Add(input[i].ToString());
                stringSubSetHelper(input, result, curStr, i + 1);
                curStr.RemoveAt(curStr.Count - 1);
            }
        }

        /*
         Unique Subsets: Modify the problem to return only unique subsets, especially when the input string contains
        duplicate characters. This variation often requires using a set or some other mechanism to ensure duplicates 
        are not included in the result.

        To generate unique subsets of a string, especially when the input string contains duplicate characters, 
        we need to ensure that duplicate subsets are not included in the result. One common approach to achieve this 
        is to use a set to store subsets, as sets inherently avoid duplicates. However, since sets in C# don't support 
        lists directly (because lists do not have value-based hash code implementations), we will convert each subset 
        list to a string before adding it to the set. This way, we can leverage the uniqueness property of the set.
         */
        public IList<IList<string>> UniqueStringSubSets(string input)
        {
            IList<IList<string>> allSubsets = new List<IList<string>>();
            HashSet<string> uniqueSubsets = new HashSet<string>(); // To ensure uniqueness
            GenerateUniqueSubsets(input, 0, new List<string>(), allSubsets, uniqueSubsets);
            return allSubsets;
        }

        // GenerateUniqueSubsets uses backtracking to generate subsets and a HashSet<string> to ensure uniqueness.
        /*
         Each time a new subset is formed, it's converted to a string (currentSubset) and checked against the set uniqueSubsets for uniqueness.
If the subset is unique, it is added to both allSubsets and uniqueSubsets.
The function iteratively adds characters from the input string to the current subset and recurses, then backtracks by removing the last character added.
         */
        private void GenerateUniqueSubsets(string input, int index, List<string> current, IList<IList<string>> allSubsets, HashSet<string> uniqueSubsets)
        {
            string currentSubset = string.Join("", current);
            if (!uniqueSubsets.Contains(currentSubset))
            {
                allSubsets.Add(new List<string>(current));
                uniqueSubsets.Add(currentSubset);
            }
            //else
            //{
            //    Console.WriteLine(currentSubset);
            //}

            for (int i = index; i < input.Length; i++)
            {
                current.Add(input[i].ToString());
                GenerateUniqueSubsets(input, i + 1, current, allSubsets, uniqueSubsets);
                current.RemoveAt(current.Count - 1);
            }
        }

        /*
         * Subsets with Certain Conditions: Generate subsets that meet certain criteria, like subsets that form valid words 
         * (useful in problems like word break or crossword puzzles), or subsets that match a particular pattern or property 
         * (e.g., subsets with an equal number of vowels and consonants).
         * 
         * Creating a function to generate subsets that meet certain conditions requires a way to evaluate each subset against 
         * the specified criteria. For this example, let's create a function that generates subsets of characters from a string 
         * and only includes those subsets where the number of vowels is equal to the number of consonants. This is a clear and 
         * specific condition that we can check for each subset.
         */

        public IList<string> SubsetsWithEqualVowelsAndConsonants(string input)
        {
            IList<string> subsets = new List<string>();
            GenerateSubsetsWithCondition(input, 0, "", subsets);
            return subsets;
        }

        /*
         * This recursive function is designed to generate all possible subsets of a given string. 
         * It does this by choosing to either include or exclude each character of the input string in the current subset.
         */
        private void GenerateSubsetsWithCondition(string input, int index, string current, IList<string> subsets)
        {
            /*
             * Base Case of Recursion: This line checks if the recursion has considered all characters of the input string. 
             * The index variable tracks the current position in the input string. When index equals input.Length, 
             * it means we've reached the end of the string, and thus, a subset (represented by current) is fully formed.
             */
            if (index == input.Length)
            {
                /*
                 Checking Validity: Once a subset is formed (i.e., we have considered each character of the input), 
                the IsValidSubset function is called to check if this subset meets the specified condition. 
                If it does, the subset is added to subsets.

                Terminating the Current Path: After checking and possibly adding the subset to subsets, the function returns. 
                This return statement terminates the current recursive path, as there are no more characters left to consider 
                for this particular subset.
                 */
                if (IsValidSubset(current))
                {
                    subsets.Add(current);
                }
                return;
            }

            /*
             * Including vs. Excluding a Character
Including a Character: The recursive call GenerateSubsetsWithCondition(input, index + 1, current + input[index], subsets) 
            handles the scenario where the current character (at position index) is included in the subset. This is achieved
            by appending input[index] to the current string.

Excluding a Character: The other recursive call GenerateSubsetsWithCondition(input, index + 1, current, subsets) handles 
            the scenario where the current character is excluded. Notice that here, input[index] is not added to current. 
            This way, the function explores the subset where the current character is not part of it.
             */

            // Include the current character
            GenerateSubsetsWithCondition(input, index + 1, current + input[index], subsets);

            // Exclude the current character
            GenerateSubsetsWithCondition(input, index + 1, current, subsets);
        }
        /*
         * How Exclusion Works
The key to understanding the exclusion is recognizing that the function is called with the current string unchanged. 
        Since each recursive call represents a decision point (to include or exclude the current character), 
        not appending the current character (input[index]) effectively means it's excluded from that subset.

When the function is called with index + 1 but without changing current, it moves to the next character in the input string, 
        leaving current as it is. This represents the choice of not including the current character in the subset.

In summary, this function systematically explores all combinations of including and excluding each character in the input
        string to form subsets. At each character position, it branches into two paths: one where the character is included 
        and one where it is excluded. This process continues until all characters have been considered, forming a complete 
        subset, after which it checks if this subset meets the given condition.
         */

        private bool IsValidSubset(string subset)
        {
            int vowelCount = 0, consonantCount = 0;
            foreach (char c in subset)
            {
                if ("aeiouAEIOU".Contains(c))
                {
                    vowelCount++;
                }
                else if (char.IsLetter(c))
                {
                    consonantCount++;
                }
            }
            return vowelCount == consonantCount;
        }




        /*
         Subsets with Non-Consecutive Characters: Instead of subsets formed from consecutive characters, 
        generate subsets where the characters are not necessarily consecutive in the original string.

        Generating subsets with non-consecutive characters involves creating all possible combinations of characters 
        from the input string, regardless of their original order or consecutiveness. This can be achieved using a 
        similar backtracking approach as before, but with a slight modification: we no longer need to maintain the 
        original order of characters in the subsets.
         */

        public IList<string> SubsetsWithNonConsecutiveChars(string input)
        {
            IList<string> subsets = new List<string>();
            GenerateSubsets(input, 0, "", subsets);
            return subsets;
        }

        private void GenerateSubsets(string input, int index, string current, IList<string> subsets)
        {
            if (index == input.Length)
            {
                subsets.Add(current);
                return;
            }

            // Include the current character and recurse
            GenerateSubsets(input, index + 1, current + input[index], subsets);

            // Exclude the current character and recurse
            GenerateSubsets(input, index + 1, current, subsets);
        }




        /*
         * Character Counts in Subsets: Return subsets along with the count of each character in the subset, 
         * which can be a twist to the basic problem and useful in certain applications.
         * 
         * To create a function that returns subsets along with the count of each character in the subset, 
         * we can modify the subset generation approach to include a data structure that keeps track of character counts. 
         * In C#, this can be efficiently handled using a Dictionary<char, int> to maintain the count of each character in 
         * the current subset.
         */

        public IList<string> SubsetsWithCharCount(string input)
        {
            IList<string> subsets = new List<string>();
            GenerateSubsets(input, 0, new StringBuilder(), new Dictionary<char, int>(), subsets);
            return subsets;
        }

        private void GenerateSubsets(string input, int index, StringBuilder current, Dictionary<char, int> charCount, IList<string> subsets)
        {
            if (index == input.Length)
            {
                subsets.Add(FormatSubset(current, charCount));
                return;
            }

            // Include the current character
            char currentChar = input[index];
            current.Append(currentChar);
            if (!charCount.ContainsKey(currentChar))
                charCount[currentChar] = 0;
            charCount[currentChar]++;

            GenerateSubsets(input, index + 1, current, charCount, subsets);

            // Backtrack and exclude the current character
            current.Length--; // Remove last character
            charCount[currentChar]--;
            if (charCount[currentChar] == 0)
                charCount.Remove(currentChar);

            GenerateSubsets(input, index + 1, current, charCount, subsets);
        }

        private string FormatSubset(StringBuilder subset, Dictionary<char, int> charCount)
        {
            StringBuilder result = new StringBuilder();
            result.Append(subset.ToString());
            result.Append(" (");
            foreach (var pair in charCount)
            {
                result.Append($"{pair.Key}:{pair.Value}, ");
            }
            if (charCount.Count > 0)
                result.Length -= 2; // Remove trailing comma and space
            result.Append(")");
            return result.ToString();
        }
    }
}
