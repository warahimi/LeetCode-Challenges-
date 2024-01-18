using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    public class StringPermutations
    {
        // Main function to be called with the input string
        public static List<string> GetAllPermutations(string str)
        {
            HashSet<string> result = new HashSet<string>(); // Using HashSet to avoid duplicates
            Permute(str, "", result);
            return new List<string>(result);
        }

        // Recursive function to generate permutations
        private static void Permute(string str, string chosen, HashSet<string> result)
        {
            if (str.Length == 0)
            {
                result.Add(chosen);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    // Choose a character
                    char c = str[i];
                    chosen += c;

                    // Explore with this character
                    Permute(str.Remove(i, 1), chosen, result);

                    // Unchoose the character for the next iteration
                    chosen = chosen.Remove(chosen.Length - 1);
                }
            }
        }
    }
}
