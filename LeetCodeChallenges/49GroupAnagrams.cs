using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    /*
    Given an array of strings strs, group the anagrams together. You can return the answer in any order.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
    typically using all the original letters exactly once.



    Example 1:

    Input: strs = ["eat","tea","tan","ate","nat","bat"]
    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
    */
    internal class _49GroupAnagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<List<string>> result = new List<List<string>>();
            foreach (string str in strs)
            {
                string frequency = getCharFrequency(str);
                if (dict.ContainsKey(frequency))
                {
                    dict[frequency].Add(str);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(str);
                    dict[frequency] = list;
                }
            }
            return new List<IList<string>>(dict.Values);
        }
        public string getCharFrequency(string str)
        {
            int[] frequency = new int[26]; // Assuming lowercase English letters only
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                frequency[ch - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (frequency[i] > 0)
                {
                    sb.Append((char)('a' + i));
                    sb.Append(frequency[i]);
                }
            }

            return sb.ToString();
        }
        public string sortString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

    }
}
/*
             _49GroupAnagrams ob = new _49GroupAnagrams();

            IList<IList<string>> anwser = ob.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat","a"]);

            Console.Write("[");
            foreach (var list  in anwser) 
            {
                Console.Write("[");
                foreach (var str in list)
                {
                    Console.Write('"' + str + '"' + ",");
                }
                Console.Write("]");
            }
            Console.Write("]");
 */