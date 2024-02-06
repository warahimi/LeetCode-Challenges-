using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    /*
     The problem "205. Isomorphic Strings" asks to determine if two given strings are isomorphic. Two strings are considered isomorphic if the characters in the first string can be replaced to get the second string, ensuring that no two characters map to the same character unless they are the same character themselves. This means each character in one string maps to one and only one character in the other string, and vice versa. For instance, "egg" and "add" are isomorphic because we can map 'e' to 'a' and 'g' to 'd'. However, "foo" and "bar" are not isomorphic because 'o' would have to map to both 'a' and 'r'.

To solve this problem efficiently, we can use two dictionaries in C# to keep track of the mappings from characters in the first string to characters in the second string and vice versa. This allows us to quickly look up and ensure that each character in one string consistently maps to the same character in the other string throughout.
     */
    internal class _205_Isomorphic_Strings
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // Create a dictionary to store character mappings
            Dictionary<char, char> charMappingMap = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char original = s[i];
                char replacement = t[i];

                if (!charMappingMap.ContainsKey(original))
                {
                    // Check if the replacement character is already a value for another key
                    if (!charMappingMap.ContainsValue(replacement))
                        charMappingMap.Add(original, replacement);
                    else
                        return false;
                }
                else
                {
                    char mappedCharacter = charMappingMap[original];
                    if (mappedCharacter != replacement)
                        return false;
                }
            }

            return true;
        }
        public bool IsIsomorphic2(string s, string t)
        {
            if (s.Length != t.Length) return false; // Strings of different lengths cannot be isomorphic

            // Dictionaries to track the character mappings from s to t and from t to s
            Dictionary<char, char> sTot = new Dictionary<char, char>();
            Dictionary<char, char> tTos = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char sChar = s[i];
                char tChar = t[i];

                // If the mapping for sChar already exists, check if it matches tChar
                if (sTot.ContainsKey(sChar) && sTot[sChar] != tChar)
                {
                    return false;
                }

                // If the mapping for tChar already exists, check if it matches sChar
                if (tTos.ContainsKey(tChar) && tTos[tChar] != sChar)
                {
                    return false;
                }

                // Add or update the mappings
                sTot[sChar] = tChar;
                tTos[tChar] = sChar;
            }

            return true; // If we've made it through without returning false, the strings are isomorphic
        }

        public bool IsIsomorphic3(string s, string t)
        {
            if (s.Length != t.Length) 
                return false;
            Dictionary<char, char> dictionary = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (dictionary.TryGetValue(s[i], out var currentPair))
                {
                    if (currentPair != t[i])
                    {
                        return false;
                    }
                    continue;
                }
                if (dictionary.ContainsValue(t[i]))
                {
                    return false;
                }
                dictionary.Add(s[i], t[i]);
            }
            return true;
        }
    }
}
