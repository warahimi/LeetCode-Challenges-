using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class Get_Char_Indexes_in_a_String
    {
        public void printcharIndexes(string s)
        {
            Dictionary<char, List<int>> charIndices = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!charIndices.ContainsKey(s[i]))
                {
                    charIndices.Add(s[i], new List<int>());
                }
                charIndices[s[i]].Add(i);
            }
            foreach (var kvp in charIndices)
            {
                Console.Write(kvp.Key + ": ");
                printList(kvp.Value);
            }
        }
        private static void printList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
