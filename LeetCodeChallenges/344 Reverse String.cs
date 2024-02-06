using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _344_Reverse_String
    {
        public void ReverseString(char[] s)
        {
            //Array.Reverse(s);
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = s[right];
                s[right] = s[left];
                s[left] = temp;
                left++;
                right--;
            }
        }
    }
}
