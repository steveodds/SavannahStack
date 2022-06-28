namespace SavannahStack
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

        /////////////////
        // Helper methods

        public bool IsEmpty()
        {
            return top < 0;
        }

        public int GetTotalCount()
        {
            return top;
        }

        public void Clear()
        {
            if (top != -1)
            {
                top = -1;
                stack = new string[MAX_STACK_SIZE];
            }
        }

        public bool Contains(string element)
        {
            return stack.Contains(element);
        }

        /////////////////

        public void Push(string element)
        {
            if (top >= MAX_STACK_SIZE)
                throw new InvalidOperationException($"Failed to add element {element}. The stack is full.");

            stack[++top] = element;
        }

        // For multiple items
        public void Push(string[] elements)
        {
            int availableStackSpace = MAX_STACK_SIZE - top;
            if (availableStackSpace < elements.Length)
                throw new InvalidOperationException("Failed to add elements. The stack does not have enough space.");

            foreach (var element in elements)
            {
                Push(element);
            }

        }

        public string Pop()
        {
            if (top < 0)
                throw new InvalidOperationException("Cannot remove element from an empty stack.");

            return stack[top--];
        }

        public string Peek()
        {
            if (top < 0)
                throw new InvalidOperationException("Cannot peek an empty stack.");

            return stack[top];
        }
    }
}