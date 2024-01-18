using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Given two strings s and t, return true if t is an anagram of s, and false otherwise.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
    typically using all the original letters exactly once.
 */

namespace LeetCodeChallenges
{
    internal class _242alidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> d = new Dictionary<char, int>(); // to store frequency of each letter in strings
            foreach (char c in s)
            {
                if (d.ContainsKey(c))
                {
                    d[c]++;
                }
                else
                {
                    d.Add(c, 1);
                }
            }
            foreach (char c in t)
            {
                if (d.ContainsKey(c))
                {
                    d[c]--;
                }
                else
                {
                    return false;
                }
            }
            // foreach(char c in d.Keys)
            // {
            //     if(d[c] != 0)
            //     {
            //         return false;
            //     }
            // }
            // return true;

            if (d.Values.All(v => v == 0)) // all values should be 0 after cancelation
                return true;
            else
                return false;
        }

        public bool IsAnagramBruteForce(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            s = sort(s);
            t = sort(t);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    return false;
                }
            }
            return true;
        }
        public string sort(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }
    }
}
