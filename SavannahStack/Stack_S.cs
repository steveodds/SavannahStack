namespace SavannahStack
{
    public class Stack_S
    {
        static readonly int MAX_STACK_SIZE = 1000;
        private int top;
        private int[] stack = new int[MAX_STACK_SIZE];

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

        }

        // For multiple items
        public void Push(string[] elements)
        {

        }

        public string Pop()
        {
            throw new NotImplementedException();
        }

        public string Peek()
        {
            throw new NotImplementedException();
        }
    }
}