using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _792_Number_Of_Matching_Subsequences
    {
        public int NumMatchingSubseq(string s, string[] words)
        {
            int count = 0;
            foreach (string str in words)
            {
                if (contains(str, s))
                {
                    count++;
                }
            }
            return count;
        }
        private bool contains(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1))
            {
                return true;
            }
            if (s1.Length > s2.Length)
            {
                return false;
            }
            int i = 0;
            int j = 0;

            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] == s2[j])
                {
                    i++;
                }
                j++;
            }
            return i == s1.Length;
        }


         public int NumMatchingSubseq2(string s, string[] words) {
        // Map each character in 's' to its indices
        var charPositionsMap = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++) {
            if (!charPositionsMap.ContainsKey(s[i])) {
                charPositionsMap[s[i]] = new List<int>();
            }
            charPositionsMap[s[i]].Add(i);
        }

        int count = 0;
        foreach (var word in words) {
            if (IsSubsequence(word, charPositionsMap)) {
                count++;
            }
        }

        return count;
    }

    private bool IsSubsequence(string word, Dictionary<char, List<int>> charPositionsMap) {
        // 'prev' represents the index in 's' where we found the last character of 'word'
        int prev = -1;
        foreach (var ch in word) {
            if (!charPositionsMap.ContainsKey(ch)) return false; // Character not in 's'
            
            var list = charPositionsMap[ch];
            int pos = list.BinarySearch(prev);
            if (pos < 0) {
                // BinarySearch returns the complement index of the first element larger than 'prev' if not found
                pos = ~pos;
            } else {
                // If 'prev' is found, we want the next character (hence increment)
                pos += 1;
            }
            
            if (pos == list.Count) return false; // No character found that is beyond 'prev'
            prev = list[pos]; // Update 'prev' to the found character's index
        }
        return true; // All characters of 'word' are found in correct order in 's'
    }
    }
}
