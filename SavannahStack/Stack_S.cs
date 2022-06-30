namespace SavannahStack
{
    public class Stack_S<T>
    {
        static readonly int MAX_STACK_SIZE = 1000;
        private int top;
        private T[] stack = new T[MAX_STACK_SIZE];

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
            return top + 1;
        }

        public void Clear()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is already empty");

            top = -1;
            stack = new T[MAX_STACK_SIZE];
        }

        public bool Contains(T element)
        {
            return stack.Contains(element);
        }

        /////////////////

        // Add item to stack
        public void Push(T element)
        {
            if (top >= MAX_STACK_SIZE)
                throw new InvalidOperationException($"Failed to add element. The stack is full.");

            stack[++top] = element;
        }

        // For multiple items
        public void Push(T[] elements)
        {
            int availableStackSpace = MAX_STACK_SIZE - top;
            if (availableStackSpace < elements.Length)
                throw new InvalidOperationException("Failed to add elements. The stack does not have enough space.");

            foreach (var element in elements)
            {
                Push(element);
            }

        }

        // Remove and return most recent element
        public T Pop()
        {
            if (top < 0)
                throw new InvalidOperationException("Cannot remove element from an empty stack.");

            return stack[top--];
        }

        // Check the top without removing it
        public T Peek()
        {
            if (top < 0)
                throw new InvalidOperationException("Cannot peek an empty stack.");

            return stack[top];
        }
    }
}