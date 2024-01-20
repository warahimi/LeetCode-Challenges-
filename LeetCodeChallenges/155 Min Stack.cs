using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges
{
    internal class _155_Min_Stack
    {
    }
    public class MinStack
    {
        private Stack<int> stack; // This stack stores all the elements.
        private Stack<int> minStack; // This stack stores the minimum elements.

        /** Initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            stack.Push(x);
            // If the minStack is empty or the new element is smaller or equal to the top of minStack,
            // push it onto minStack.
            if (minStack.Count == 0 || x <= GetMin())
            {
                minStack.Push(x);
            }
        }

        /** Removes the element on top of the stack. */
        public void Pop()
        {
            // If the top element is the same as the top of minStack, pop it from minStack.
            if (stack.Peek() == GetMin())
            {
                minStack.Pop();
            }
            stack.Pop();
        }

        /** Get the top element. */
        public int Top()
        {
            return stack.Peek();
        }

        /** Retrieve the minimum element in the stack. */
        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    // using linked list
    public class MinStack2
    {
        // This is a list of tuples, where each tuple contains two integers: value and min.
        private List<(int value, int min)> stack; // List to store the stack elements along with the current minimum

        /** Initialize your data structure here. */
        public MinStack2()
        {
            stack = new List<(int value, int min)>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            int currentMin = stack.Count == 0 ? x : Math.Min(x, GetMin());
            // Each element in the stack stores the value and the minimum value at the time of insertion
            stack.Add((x, currentMin));
        }

        /** Removes the element on top of the stack. */
        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1);
            }
        }

        /** Get the top element. */
        public int Top()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[stack.Count - 1].value;
        }

        /** Retrieve the minimum element in the stack. */
        public int GetMin()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[stack.Count - 1].min;
        }
    }

    // using array 
    public class MinStack3
    {

        private Node top;

        private class Node
        {
            public int Value { get; set; }
            public int Min { get; set; }
            public Node Next { get; set; }

            public Node(int value, int min, Node next)
            {
                this.Value = value;
                this.Min = min;
                this.Next = next;
            }
        }

        /** Initialize your data structure here. */
        public MinStack3()
        {
            top = null;
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            if (top == null)
            {
                top = new Node(x, x, null);
            }
            else
            {
                int currentMin = Math.Min(x, top.Min);
                Node newNode = new Node(x, currentMin, top);
                top = newNode;
            }
        }

        /** Removes the element on top of the stack. */
        public void Pop()
        {
            if (top != null)
            {
                top = top.Next;
            }
        }

        /** Get the top element. */
        public int Top()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return top.Value;
        }

        /** Retrieve the minimum element in the stack. */
        public int GetMin()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return top.Min;
        }
    }

    public class MinStack4
    {
        Stack<int> stack = null;
        Stack<int> minimumStack = null;
        public MinStack4()
        {
            stack = new Stack<int>();
            minimumStack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (minimumStack.Count > 0)
            {
                int minimumValue = minimumStack.Peek();
                if (minimumValue >= val)
                {
                    minimumStack.Push(val);
                }
            }
            else
            {
                minimumStack.Push(val);
            }
            stack.Push(val);
        }

        public void Pop()
        {
            int val = 0;
            val = stack.Pop();
            if (minimumStack.Count > 0 && val == minimumStack.Peek())
            {
                minimumStack.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minimumStack.Peek();
        }
    }

    // using 2 arrays
    public class MinStack5
    {
        private int[] stack;      // Array to store the stack elements
        private int[] minStack;   // Array to store the minimum elements
        private int size;         // Current number of elements in the stack
        private int capacity;     // Current capacity of the arrays

        /** Initialize your data structure here. */
        public MinStack5()
        {
            capacity = 10; // Initial capacity
            stack = new int[capacity];
            minStack = new int[capacity];
            size = 0;
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            if (size == capacity)
            {
                // Resize the arrays if the current capacity is reached
                Resize();
            }
            stack[size] = x;
            // Update the minimum element
            if (size == 0 || x < minStack[size - 1])
            {
                minStack[size] = x;
            }
            else
            {
                minStack[size] = minStack[size - 1];
            }
            size++;
        }

        /** Removes the element on top of the stack. */
        public void Pop()
        {
            if (size > 0)
            {
                size--;
            }
        }

        /** Get the top element. */
        public int Top()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[size - 1];
        }

        /** Retrieve the minimum element in the stack. */
        public int GetMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return minStack[size - 1];
        }

        /** Resize the stack and minStack arrays. */
        private void Resize()
        {
            capacity *= 2; // Double the capacity
            Array.Resize(ref stack, capacity);
            Array.Resize(ref minStack, capacity);
        }
    }


    //  basic implementation of a stack Abstract Data Type (ADT) using an array
    public class ArrayStack
    {
        private int[] stack;
        private int top;
        private int capacity;

        // Constructor to initialize the stack
        public ArrayStack(int size)
        {
            capacity = size;
            stack = new int[capacity];
            top = -1;
        }

        // Method to add an item to the stack
        public void Push(int item)
        {
            if (IsFull())
            {
                // Resize the stack if it is full
                Resize();
            }
            stack[++top] = item;
        }

        // Method to remove the top item from the stack
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[top--];
        }

        // Method to get the top item of the stack
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[top];
        }

        // Method to check if the stack is empty
        public bool IsEmpty()
        {
            return top == -1;
        }

        // Method to check if the stack is full
        private bool IsFull()
        {
            return top == capacity - 1;
        }

        // Method to resize the stack
        private void Resize()
        {
            capacity *= 2;
            var newStack = new int[capacity];
            Array.Copy(stack, newStack, stack.Length);
            stack = newStack;
        }
    }

    public class ListStack<T>
    {
        private List<T> stack;

        // Constructor to initialize the stack
        public ListStack()
        {
            stack = new List<T>();
        }

        // Method to add an item to the stack
        public void Push(T item)
        {
            stack.Add(item);
        }

        // Method to remove and return the top item from the stack
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T item = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return item;
        }

        // Method to return the top item of the stack without removing it
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stack[stack.Count - 1];
        }

        // Method to check if the stack is empty
        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        // Method to get the size of the stack
        public int Size()
        {
            return stack.Count;
        }
    }
}
