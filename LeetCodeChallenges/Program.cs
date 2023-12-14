using System;

namespace LeetCodeChallenges
{

    internal class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine();
            Console.WriteLine(ob.sortString("zxwqravbctyuiosdfghj"));
        }
    }
}