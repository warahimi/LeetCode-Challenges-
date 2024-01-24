using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_and_Recursion
{
    internal class Recursion_Dice_Throw_and_Letter_combination_of_phone_number
    {
        // what all possible combinations we can make of the given digits 
        // can use the subset method 

        /*
         17. Letter Combinations of a Phone Number
        Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

        given "23" we can make 3*3 = 9 combinations

        this is bruteforce problem becasue we have to find all the combinations , we can apply backtracking technique on it 

        worst time complexity = O(n 4^n)  , is the length of the string and 4 in worst case becase 8 has 4 characters in it
         */

        /*
The Backtrack method is a recursive function that builds the combinations. It takes the current combination (current), the current index in the input digits, and builds up combinations by appending each possible letter.
If the current combination length equals the length of the input digits, it is added to the result list.
The function iterates over each letter that corresponds to the current digit, appending it to the current combination and calling itself recursively for the next digit.
         */

        public IList<string> LetterCombinations(string digits)
        {
            // If the input is empty, return an empty list
            if (string.IsNullOrEmpty(digits)) return new List<string>();

            // Map each digit to its corresponding letters
            var phoneMap = new Dictionary<char, string>()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

            var result = new List<string>();

            // Start the backtracking algorithm
            Backtrack(result, phoneMap, digits, "", 0);

            return result;
        }

        private void Backtrack(IList<string> result, Dictionary<char, string> phoneMap, string digits, string current, int index)
        {
            // Base case: if the current combination has the same length as the input digits, add it to the results
            if (index == digits.Length)
            {
                result.Add(current);
                return;
            }

            // Get the letters corresponding to the current digit
            string letters = phoneMap[digits[index]];

            // Iterate through these letters, adding each to the current combination and recursing further
            foreach (char letter in letters)
            {
                Backtrack(result, phoneMap, digits, current + letter, index + 1);
            }
        }



        private Dictionary<char, string> digitsToCharacters = new Dictionary<char, string>{

            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

        public IList<string> LetterCombinations2(string digits)
        {

            IList<string> result = new List<string>();
            if (!string.IsNullOrEmpty(digits))
            {
                StringBuilder currentCombination = new StringBuilder();
                GenerateCombinations(currentCombination, result, digits, 0);
            }

            return result;
        }
        private void GenerateCombinations(StringBuilder currentCombination, IList<string> result, string digits, int index)
        {
            if (index >= digits.Length)
            {
                result.Add(currentCombination.ToString());
                return;
            }
            var currentDigit = digits[index];
            if (digitsToCharacters.ContainsKey(currentDigit))
            {
                string letters = digitsToCharacters[currentDigit];
                foreach (var letter in letters)
                {
                    currentCombination.Append(letter);
                    GenerateCombinations(currentCombination, result, digits, index + 1);
                    currentCombination.Length--;
                }
            }
        }


        /*
         Given a die having numbers[1,2,3,4,5,6] find out how many ways are there to form a number (between 1 and 6) on a die 
        for example howmay ways are there to form number 4 
        what are all the combinations from [1,2,3,4,5,6] to form 4
        {4, 2 2, 1 1 1 1, 1 1 2, 1 3 ...] this combination 
        
        from given data we take some thing and ignoring some thing we can apply the proccessed and unprocessed approach 

         */

        public void dice(int target)
        {
            // Check if the target is within the valid range (1 to 6)
            if (target < 0 || target > 6)
                return;

            // Start the recursive process with an empty string for the current process and the target value
            diceHelper("", target);
        }

        private void diceHelper(string process, int target)
        {
            // Base case: If the target becomes 0, print the current process and return
            if (target == 0)
            {
                Console.WriteLine(process);
                return;
            }

            // Iterate through all possible dice values from 1 to 6, but do not exceed the target
            for (int i = 1; i <= 6 && i <= target; i++)
            {
                // Recursively call diceHelper, appending the current dice value to the process and reducing the target by the dice value
                diceHelper(process + i, target - i);
            }
        }

        // return a list 

        public List<string> diceList(int target)
        {
            return diceListHelper("", target);
        }
        private List<string> diceListHelper(string process, int target)
        {
            if(target == 0)
            {
                List<string> l = new List<string>();
                l.Add(process);
                return l;
            }
            List<string> list = new List<string>();
            for(int i = 1;i <= 6 && i <= target;i++)
            {
                list.AddRange(diceListHelper(process + i, target - i));
            }
            return list;
        }



        // lets say the die face is not fixed (6) . the face die can be given to use we may have a 7 face die or 8 face die .. 

        public void diceFace(int target, int face)
        {
            // Check if the target is within the valid range (1 to 6)
            if (target < 0 || target > 6)
                return;

            // Start the recursive process with an empty string for the current process and the target value
            diceHelperFace("", target, face);
        }

        private void diceHelperFace(string process, int target, int face)
        {
            // Base case: If the target becomes 0, print the current process and return
            if (target == 0)
            {
                Console.WriteLine(process);
                return;
            }

            // Iterate through all possible dice values from 1 to 6, but do not exceed the target
            for (int i = 1; i <= face && i <= target; i++)
            {
                // Recursively call diceHelper, appending the current dice value to the process and reducing the target by the dice value
                diceHelperFace(process + i, target - i, face);
            }
        }



        public List<string> diceListFace(int target, int face)
        {
            return diceListHelperFace("", target, face);
        }
        private List<string> diceListHelperFace(string process, int target, int face)
        {
            if (target == 0)
            {
                List<string> l = new List<string>();
                l.Add(process);
                return l;
            }
            List<string> list = new List<string>();
            for (int i = 1; i <= face && i <= target; i++)
            {
                list.AddRange(diceListHelperFace(process + i, target - i, face));
            }
            return list;
        }

        /*
         To solve this problem, we want to find all the combinations of numbers between 1 and 6 (inclusive) that can sum up to a given target number (in this case, 4). This is a classic problem in combinatorics, which can be approached through recursion or dynamic programming.
         The key here is that we are dealing with combinations, not permutations. In combinations, the order of the numbers does not matter (e.g., 1+3 and 3+1 are considered the same combination).

Since the combinations can include repeated numbers and the target number is within the range of the numbers on a die (1 to 6), the solution involves recursively finding all the ways to reach the target by subtracting each die face value from the target and then exploring further combinations.
         */
        public List<List<int>> dice2(int target)
        {
            List<List<int>> results = new List<List<int>>();
            FindCombinationsRecursive(target, new List<int>(), results, 1);
            return results;
        }

        private static void FindCombinationsRecursive(int remaining, List<int> currentCombination, List<List<int>> results, int start)
        {
            if (remaining == 0)
            {
                // Base case: if remaining is 0, add the current combination to results
                results.Add(new List<int>(currentCombination));
                return;
            }

            for (int i = start; i <= 6; i++)
            {
                if (i <= remaining)
                {
                    // Include this number in the current combination
                    currentCombination.Add(i);

                    // Continue finding combinations with the updated remaining value
                    FindCombinationsRecursive(remaining - i, currentCombination, results, i);

                    // Remove the last number added to try the next number in the next iteration
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }


        // Iterative approach 
        public  void dice3(int target)
        {
            if (target < 1 || target > 6)
                return;

            // A queue to store pairs of (current combination, remaining sum)
            Queue<(string combination, int remaining)> queue = new Queue<(string, int)>();
            queue.Enqueue(("", target));

            while (queue.Count > 0)
            {
                var (combination, remaining) = queue.Dequeue();

                if (remaining == 0)
                {
                    // If the remaining sum is zero, print the current combination
                    Console.WriteLine(combination);
                    continue;
                }

                for (int i = 1; i <= 6 && i <= remaining; i++)
                {
                    // Enqueue the new combination and the updated remaining sum
                    queue.Enqueue((combination + i + " ", remaining - i));
                }
            }
        }
    }
}
