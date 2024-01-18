using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    internal class _76_Minimum_Window_Substring
    {
        public string MinWindow(string s, string t)
        {
            // Edge case: If either string is empty or t's length is greater than s's length
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            {
                return "";
            }

            // Dictionary to keep a count of all the unique characters in t.
            Dictionary<char, int> dictT = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (dictT.ContainsKey(c))
                {
                    dictT[c]++;
                }
                else
                {
                    dictT[c] = 1;
                }
            }

            // Number of unique characters in t, which need to be present in the desired window.
            int required = dictT.Count;

            // Left and Right pointer
            int l = 0, r = 0;

            // formed is used to keep track of how many unique characters in t
            // are present in the current window in its desired frequency.
            // e.g. if t is "AABC" then the window must have two 'A's, one 'B' and one 'C'.
            // Thus formed would be = 3 when all these conditions are met.
            int formed = 0;

            // Dictionary to keep a count of all the unique characters in the current window.
            Dictionary<char, int> windowCounts = new Dictionary<char, int>();

            // ans list of the form (window length, left, right)
            (int, int, int) ans = (-1, 0, 0);

            while (r < s.Length)
            {
                // Add one character from the right to the window
                char c = s[r];
                int count = windowCounts.ContainsKey(c) ? windowCounts[c] : 0;
                windowCounts[c] = count + 1;

                // If the frequency of the current character added equals to the
                // desired count in t then increment the formed count by 1.
                if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c])
                {
                    formed++;
                }

                // Try and contract the window till the point where it ceases to be 'desirable'.
                while (l <= r && formed == required)
                {
                    c = s[l];
                    // Save the smallest window until now.
                    if (ans.Item1 == -1 || r - l + 1 < ans.Item1)
                    {
                        ans = (r - l + 1, l, r);
                    }

                    // The character at the position pointed by the
                    // `Left` pointer is no longer a part of the window.
                    windowCounts[c] = windowCounts[c] - 1;
                    if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c])
                    {
                        formed--;
                    }

                    // Move the left pointer ahead, this would help to look for a new window.
                    l++;
                }

                // Keep expanding the window once we are done contracting.
                r++;
            }

            return ans.Item1 == -1 ? "" : s.Substring(ans.Item2, ans.Item1);
        }
    }
}
