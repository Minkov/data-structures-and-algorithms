namespace LinearDataStructures
{
    public class Stack<T>
    {
        private readonly LinkedList<T> list;

        public Stack()
        {
            this.list = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Push(T value)
        {
            this.list.AddLast(value);
        }

        public T Pop()
        {
            var value = this.list.Last;
            this.list.RemoveLast();
            return value;
        }

        public T Peek()
        {
            return this.list.Last;
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}
