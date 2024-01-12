using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric
    characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

    Given a string s, return true if it is a palindrome, or false otherwise.
 */
namespace LeetCodeChallenges
{
    internal class _125Valid_Palindrome
    {
        //O(n) O(n)
        public bool IsPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s))//|| s == String.Empty)
            {
                return true;
            }
            //removing the non-alphnumeric characters 
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                }
            }
            s = sb.ToString();
            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        public bool IsPalindrome2(string s)
        {
            //1.remove non-alphanumeric characters
            List<char> list = new List<char>();

            s = s.ToLower();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    list.Add(c);
                }
            }

            //2.check if Palindrome or not
            for (int i = 0; i < list.Count / 2; i++)
            {
                if (list[i] != list[list.Count - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        // O(n)
        public bool IsPalindrome3(string s)
        {
            for (int i = 0, j = s.Length - 1; j > i;)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (char.ToLower(s[i++]) != char.ToLower(s[j--]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPalindrome4(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else if (char.ToLower(s[left]) == char.ToLower(s[right]))
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
