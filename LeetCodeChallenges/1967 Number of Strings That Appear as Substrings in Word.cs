using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _1967_Number_of_Strings_That_Appear_as_Substrings_in_Word
    {
        public int NumOfStrings(string[] patterns, string word)
        {
            int count = 0;
            foreach (string s in patterns)
            {
                if (word.Contains(s))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
