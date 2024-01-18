using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _20_Valid_Parentheses
    {
        public static bool isValid(string s)
        {
            if (s[0] == '}' || s[0] == ']' || s[0] == ')')
                return false;
            Stack<char> stk = new Stack<char>();
            Dictionary<char, char> map = new Dictionary<char, char>();
            map['{'] = '}';
            map['('] = ')';
            map['['] = ']';
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stk.Push(c);
                }
                else
                {
                    if (map[stk.Pop()] != c)
                    {
                        return false;
                    }
                }
            }
            if (stk.Count() > 0)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(string s)
        {
            // Initialize a dictionary to keep track of the mappings.
            Dictionary<char, char> brackets = new Dictionary<char, char>() {
        {')', '('},
        {'}', '{'},
        {']', '['}
    };

            // Use a stack to keep track of the opening brackets.
            Stack<char> stack = new Stack<char>();

            // Iterate through each character in the input string.
            foreach (char c in s)
            {
                // If the current character is a closing bracket.
                if (brackets.ContainsKey(c))
                {
                    // Get the top element of the stack. If the stack is empty, set a dummy value.
                    char topElement = stack.Count > 0 ? stack.Pop() : '#';

                    // If the mapping for the closing bracket doesn't match the top element, return false.
                    if (brackets[c] != topElement)
                    {
                        return false;
                    }
                }
                else
                {
                    // If it's an opening bracket, push to the stack.
                    stack.Push(c);
                }
            }

            // If the stack is empty, all the brackets are balanced.
            return stack.Count == 0;
        }
        // Method to determine if the input string has valid parentheses
        public bool IsValid2(string s)
        {

            // Initialize a stack to keep track of the expected closing parentheses
            Stack<char> stack = new Stack<char>();

            // Iterate over each character in the string
            foreach (char c in s)
            {

                // If the character is an opening parenthesis, push the corresponding
                // closing parenthesis onto the stack
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');

                // If the stack is empty (no opening parenthesis was encountered),
                // or the top of the stack doesn't match the current closing parenthesis,
                // then the string is not valid
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }

            // If the stack is empty, all the parentheses were matched correctly
            return stack.Count == 0;
        }
    }
}
