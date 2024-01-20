using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _150_Evaluate_Reverse_Polish_Notation
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            int val1 = 0;
            int val2 = 0;
            int result = 0;
            foreach (string s in tokens)
            {
                // Every operatory is applied to its previous 2 operands in give tockens 
                if (s == "+")
                {
                    // remove the previous 2 values and replace them with the result 
                    val2 = stack.Pop();
                    val1 = stack.Pop();
                    result = val1 + val2;
                    stack.Push(result);
                }
                else if (s == "-")
                {
                    val2 = stack.Pop();
                    val1 = stack.Pop();
                    result = val1 - val2;
                    stack.Push(result);
                }
                else if (s == "/")
                {
                    val2 = stack.Pop();
                    val1 = stack.Pop();
                    result = val1 / val2;
                    stack.Push(result);
                }
                else if (s == "*")
                {
                    val2 = stack.Pop();
                    val1 = stack.Pop();
                    result = val1 * val2;
                    stack.Push(result);
                }
                else
                {
                    stack.Push(Convert.ToInt32(s));
                }
            }
            return stack.Peek();
        }

        public int EvalRPN2(string[] tokens)
        {
            var stack = new Stack<int>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    int a = stack.Pop();
                    int b = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(b + a);
                            break;
                        case "-":
                            stack.Push(b - a);
                            break;
                        case "*":
                            stack.Push(b * a);
                            break;
                        case "/":
                            stack.Push(b / a);
                            break;
                    }
                }
            }

            return stack.Pop();
        }
    }
}
