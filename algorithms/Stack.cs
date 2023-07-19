namespace algorithms;

public class Stack
{
    record StackNode<T>(T Value, StackNode<T>? Previous);

    class MemoryStack<T> {
        public int Length { get; private set; }

        protected StackNode<T>? Head {get; set; }

        public MemoryStack()
        {
            this.Head = null;
            this.Length = 0;
        }

        public void Push(T item) {
            var node = new StackNode<T>(item, this.Head);
            this.Length++;
            this.Head = node;
        }

        public T? Pop()
        {
            if (this.Head == null) {
                return default;
            }

            var head = this.Head;
            this.Head = this.Head.Previous;
            this.Length--;
            return head.Value;
        }

        public T? Peek()
        {
            if (this.Head == null) {
                return default;
            }

            return this.Head.Value;
        }
    }

    [Fact]
    public void StackOperations()
    {
        var stack = new MemoryStack<string>();

        Assert.Equal(0, stack.Length);
        stack.Push("1");
        stack.Push("2");
        stack.Push("3");
        stack.Push("4");
        Assert.Equal(4, stack.Length);
        
        var peekResult = stack.Peek();
        Assert.Equal("4", peekResult);

        var pop1Result = stack.Pop();
        Assert.Equal("4", pop1Result);
        Assert.Equal(3, stack.Length);

        var pop2Result = stack.Pop();
        Assert.Equal("3", pop2Result);
        Assert.Equal(2, stack.Length);

        var pop3Result = stack.Pop();
        Assert.Equal("2", pop3Result);
        Assert.Equal(1, stack.Length);

        var pop4Result = stack.Pop();
        Assert.Equal("1", pop4Result);
        Assert.Equal(0, stack.Length);
    }
}