using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _13_Roman_to_Integer
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int sum = 0;
            int prevValue = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int currValue = d[s[i]];

                // If the current value is greater than the previous value, subtract the previous value twice
                if (prevValue < currValue)
                {
                    sum += currValue - 2 * prevValue;
                }
                else
                {
                    sum += currValue;
                }

                prevValue = currValue;
            }
            return sum;
        }

        /*
         * in your code is designed to handle specific cases in Roman numeral notation where a smaller numeral precedes a larger one, indicating subtraction. This occurs in Roman numerals like "IV" (4), "IX" (9), "XL" (40), "XC" (90), "CD" (400), and "CM" (900).

In these cases, the smaller numeral subtracts from the larger one. However, in the standard left-to-right evaluation, you would have already added the value of the smaller numeral (the previous value) to your total (sum) before encountering the larger numeral (the current value). Therefore, you need to correct this by subtracting twice the value of the smaller numeral:
         */


        /*
         Converting an integer to its corresponding Roman numeral in C# involves mapping integer values to their Roman 
        numeral counterparts. The approach usually involves breaking down the number into its constituent parts 
        (thousands, hundreds, tens, units) and then converting each part into the corresponding Roman numeral.
         */
        public string IntToRoman(int num)
        {
            // Arrays of Roman numerals and their corresponding integer values
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            // Building the Roman numeral by extracting each digit and translating it
            return thousands[num / 1000] +
                   hundreds[(num % 1000) / 100] +
                   tens[(num % 100) / 10] +
                   ones[num % 10];
        }

        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException(nameof(number), "insert value between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new UnreachableException("Impossible state reached");

        }

        public string IntToRoman2(int num)
        {
            string romanResult = "";
            Dictionary<string, int> romanNumbersDictionary = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000}
            };
            foreach (var item in romanNumbersDictionary.Reverse())
            {
                if (num <= 0) 
                    break;
                while (num >= item.Value)
                {
                    romanResult += item.Key;
                    num -= item.Value;
                }
            }
            return romanResult;
        }
        public int RomanToInt2(string s)
        {
            Dictionary<string, int> romanNumbersDictionary = new() 
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
            };

            int result = 0;
            for (int i = 0; i < s.Length;)
            {
                if (i + 1 < s.Length && romanNumbersDictionary.ContainsKey(s.Substring(i, 2)))
                {
                    result += romanNumbersDictionary[s.Substring(i, 2)];
                    i += 2;
                }
                else
                {
                    result += romanNumbersDictionary[s.Substring(i, 1)];
                    i++;
                }
            }

            return result;
        }
    }
}
