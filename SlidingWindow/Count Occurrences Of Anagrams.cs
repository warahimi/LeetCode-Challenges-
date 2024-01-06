using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class Count_Occurrences_Of_Anagrams
    {

        /*
          The approach involves using a sliding window technique to check each substring of the text that is of the same 
        length as the pattern. We can use a fixed-size array (as the alphabet size is constant, 26 for lowercase English letters)
        to keep track of the frequency of characters.
         */
        // This function returns the count of occurrences of anagrams of the word pat in the text txt.
        public int search(string pat, string txt)
        {
            // Frequency arrays for pattern and current window in text
            int[] countPat = new int[26];
            int[] countTxt = new int[26];

            int patLen = pat.Length;
            int txtLen = txt.Length;
            int result = 0;

            // Initial frequency count for pattern and first window in text
            for (int i = 0; i < patLen; i++)
            {
                countPat[pat[i] - 'a']++;
                countTxt[txt[i] - 'a']++;
            }

            // Traverse through the remaining characters of txt
            for (int i = patLen; i < txtLen; i++)
            {
                // Compare counts of current window with counts of pattern
                if (AreSame(countPat, countTxt))
                    result++;

                // Add next character to current window
                countTxt[txt[i] - 'a']++;

                // Remove first character of current window
                countTxt[txt[i - patLen] - 'a']--;
            }

            // Check for the last window in text
            if (AreSame(countPat, countTxt))
                result++;

            return result;
        }

        // Utility function to compare two frequency arrays
        private bool AreSame(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < 26; i++)
                if (arr1[i] != arr2[i])
                    return false;
            return true;
        }


        /*
         Using a Dictionary in C# to solve this problem can provide a more flexible way to track character frequencies, 
        especially when dealing with a more extensive range of characters or if the input is not limited to lowercase English 
        letters. Here's how you can implement the solution using a Dictionary
         */
        // This function returns the count of occurrences of anagrams of the word pat in the text txt.
        public int search2(string pat, string txt)
        {
            // Dictionaries for pattern and current window in text
            var countPat = new Dictionary<char, int>();
            var countWindow = new Dictionary<char, int>();

            int patLen = pat.Length;
            int txtLen = txt.Length;
            int result = 0;

            // Initial frequency count for pattern
            foreach (char ch in pat)
            {
                if (countPat.ContainsKey(ch))
                    countPat[ch]++;
                else
                    countPat[ch] = 1;
            }

            // Initial frequency count for first window in text
            for (int i = 0; i < patLen; i++)
            {
                char ch = txt[i];
                if (countWindow.ContainsKey(ch))
                    countWindow[ch]++;
                else
                    countWindow[ch] = 1;
            }

            // Traverse through the remaining characters of txt
            for (int i = patLen; i < txtLen; i++)
            {
                // Compare counts of current window with counts of pattern
                if (AreSame2(countPat, countWindow))
                    result++;

                // Add next character to current window
                char chToAdd = txt[i];
                if (countWindow.ContainsKey(chToAdd))
                    countWindow[chToAdd]++;
                else
                    countWindow[chToAdd] = 1;

                // Remove first character of current window
                char chToRemove = txt[i - patLen];
                if (countWindow[chToRemove] == 1)
                    countWindow.Remove(chToRemove);
                else
                    countWindow[chToRemove]--;
            }

            // Check for the last window in text
            if (AreSame2(countPat, countWindow))
                result++;

            return result;
        }

        // Utility function to compare two frequency dictionaries
        private bool AreSame2(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
        {
            if (dict1.Count != dict2.Count) return false;

            foreach (var pair1 in dict1)
            {
                int value;
                if (!dict2.TryGetValue(pair1.Key, out value) || value != pair1.Value)
                    return false;
            }

            return true;
        }

        // function to check if two dictionaries are the same
        public static bool AreDictionariesEqual(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
        {
            if (dict1 == null || dict2 == null)
            {
                return dict1 == dict2;
            }

            if (dict1.Count != dict2.Count)
            {
                return false;
            }

            foreach (var pair1 in dict1)
            {
                int value;
                /*
                 * TryGetValue is a method available on C# dictionaries (Dictionary<TKey, TValue>).
                    It tries to get the value that is associated with a specific key from the dictionary.
                What It Does:

                The TryGetValue method checks if pair.Key exists in dict2.
                If it exists, it sets the value variable to the corresponding value from dict2 and returns true.
                If it does not exist, value remains unchanged (typically its default value, which would be 0 for int), 
                and the method returns false
                 */
                if (!dict2.TryGetValue(pair1.Key, out value))
                {
                    return false;
                }

                if (value != pair1.Value)
                {
                    return false;
                }
            }

            return true;
        }

        // Function to find if two strings are equal
        private bool areAnagram(string first, string second)
        {
            if (first.Length != second.Length)
                return false;

            if (first == second)
                return true; // or false: Don't know whether a
                             // string counts as an anagram of
                             // itself

            Dictionary<char, int> pool = new Dictionary<char, int>();
            foreach (char element in first.ToCharArray()) // fill the dictionary with
                                                          // that available chars and count them up
            {
                if (pool.ContainsKey(element))
                    pool[element]++;
                else
                    pool.Add(element, 1);
            }
            foreach (char element in second.ToCharArray()) // take them out again
            {
                if (!pool.ContainsKey(element)) // if a char isn't there at all; we're out
                    return false;
                pool[element]--;
                if (pool[element] == 0) // if a count is less than zero after
                          // decrement; we're out
                    pool.Remove(element);
            }
            return pool.Count == 0;
        }

        public int countAnagrams(string word, string text)
        {
            int N = text.Length;
            int n = word.Length;

            // Initialize result
            int res = 0;

            for (int i = 0; i <= N - n; i++)
            {

                string s = text.Substring(i, n);

                // Check if the word and substring are
                // anagram of each other.
                if (areAnagram(word, s) == true)
                {
                    res++;
                }
            }

            return res;
        }


        public int search3(string pat, string txt)
        {
            // code here
            int answer = 0;
            if (pat.Length == 0 || txt.Length == 0 || pat == null || txt == null || pat.Length > txt.Length)
            {
                return answer;
            }
            int k = pat.Length;
            int n = txt.Length;
            Dictionary<char, int> pD = new Dictionary<char, int>();
            Dictionary<char, int> wD = new Dictionary<char, int>();

            for (int i = 0; i < k; i++)
            {
                if (pD.ContainsKey(pat[i]))
                {
                    pD[pat[i]]++;
                }
                else
                {
                    pD[pat[i]] = 1;
                }

                if (wD.ContainsKey(txt[i]))
                {
                    wD[txt[i]]++;
                }
                else
                {
                    wD[txt[i]] = 1;
                }
            }

            for (int i = k; i < n; i++)
            {
                if (areSame3(pD, wD))
                {
                    answer++;
                }
                if (wD[txt[i - k]] == 1)
                {
                    wD.Remove(txt[i - k]);
                }
                else
                {
                    wD[txt[i - k]]--;
                }

                if (wD.ContainsKey(txt[i]))
                {
                    wD[txt[i]]++;
                }
                else
                {
                    wD[txt[i]] = 1;
                }
            }
            if (areSame3(pD, wD))
            {
                answer++;
            }
            return answer;
        }
        public bool areSame3(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            if (d1.Count != d2.Count)
            {
                return false;
            }
            if (d1 == null && d2 == null)
            {
                return d1 == d2;
            }
            foreach (var pair1 in d1)
            {
                int val;
                if (!d2.TryGetValue(pair1.Key, out val) || val != pair1.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
