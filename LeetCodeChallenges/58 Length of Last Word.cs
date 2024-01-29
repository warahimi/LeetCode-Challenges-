using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _58_Length_of_Last_Word
    {
        public int LengthOfLastWord(string s)
        {
            int j = s.Length - 1;
            while (j >= 0 && s[j] == ' ')
            {
                j--;
            }
            int count = 0;
            while (j >= 0 && s[j] != ' ')
            {
                count++;
                j--;
            }
            return count;
        }
    }
}
