﻿namespace SavannahStack
{
    public class Stack_S
    {
        static readonly int MAX_STACK_SIZE = 1000;
        private int top;
        private string[] stack = new string[MAX_STACK_SIZE];

        public Stack_S()
        {
            top = -1;
        }

        public bool IsEmpty()
        {
            return top < 0;
        }

        public void Push(string element)
        {
            if (top >= MAX_STACK_SIZE)
                throw new InvalidOperationException($"Failed to add element {element}. The stack is full.");

            stack[++top] = element;
        }

        // For multiple items
        public void Push(string[] elements)
        {

        }

        public string Pop()
        {
            if (top < 0)
                throw new InvalidOperationException("Cannot remove element from an empty stack.");

            return stack[top--];
        }

        public string Peek()
        {
            throw new NotImplementedException();
        }
    }
}