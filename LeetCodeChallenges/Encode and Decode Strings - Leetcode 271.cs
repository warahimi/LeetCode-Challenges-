using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
/*
 * Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and 
 * is decoded back to the original list of strings.
 */
namespace LeetCodeChallenges
{
    internal class Encode_and_Decode_Strings___Leetcode_271
    {
        public string[] EncodeDecode(string[] input)
        {
            return decode(endoce(input), input.Length);
        }
        private string endoce(string[] input)
        {
            string str = "";
            foreach (string str2 in input)
            {
                str += str2+";"; // used ; as delimater 
            }
            Console.WriteLine(str);
            return str;
        }
        private string[] decode(string str, int n)
        {
            string[] result = new string[n];
            int i = 0;
            string s = "";
            foreach(char c in str)
            {
                if(c != ';')
                {
                    s += c;
                }
                else
                {
                    result[i] = s;
                    s = "";
                    i++;
                }
            }
            return result;
        }

        // What the delimater is part of one of the string in the given list of string 
        /*
         * while encoding we are going to put the size of each string in front of it plus some delimater, 
         * then when decoding we will try to reach that much character after our delimater, 
         * "Wahid", "rahimi"
         * 5#Wahid6#rahimi
         */
        public string[] EncodeDecode2(string[] input)
        {
            string[] res = new string[input.Length];
            int index = 0; 

            //Encoding
            string encode = "";
            foreach (string s in input)
            {
                encode += s.Length + "#" + s;
            }
            Console.WriteLine(encode);
            int i = 0;
            string temp = "";
            while(i < encode.Length)
            {
                int j = i;
                string degit = "";
                while (encode[j] != '#') // reading the length of each string
                {
                    degit += encode[j];
                    j++;
                }

                int length = int.Parse(degit);
                string s = encode.Substring(j + 1, length);
                res[index++] = s;
                i = j + 1 + length;
            }
            return res;
        }
    }
}
