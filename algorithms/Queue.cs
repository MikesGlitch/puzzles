namespace algorithms;

public class Queue
{
    class QueueNode<T> {
        public T? Value { get; set; }

        public QueueNode<T>? Next { get; set; }
    }

    class MemoryQueue<T> {
        public int Length { get; private set; }

        protected QueueNode<T>? Head {get; set; }

        protected QueueNode<T>? Tail {get; set; }

        public MemoryQueue()
        {
            this.Head = null;
            this.Tail = null;
            this.Length = 0;
        }

        public void Enqueue(T item) {
            var node = new QueueNode<T> { Value = item, Next = null };
            this.Length++;
            if (this.Tail == null) {
                this.Head = node;
                this.Tail = node;
                return;
            }

            this.Tail.Next = node;
            this.Tail = node;
        }

        public T? Dequeue()
        {
            if (this.Head == null) {
                return default;
            }

            var head = this.Head;
            this.Head = this.Head.Next;
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
    public void QueueOperations()
    {
        var queue = new MemoryQueue<string>();

        Assert.Equal(0, queue.Length);
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");
        queue.Enqueue("4");
        Assert.Equal(4, queue.Length);
        
        var peekResult = queue.Peek();
        Assert.Equal("1", peekResult);

        var dequeue1Result = queue.Dequeue();
        Assert.Equal("1", dequeue1Result);
        Assert.Equal(3, queue.Length);

        var dequeue2Result = queue.Dequeue();
        Assert.Equal("2", dequeue2Result);
        Assert.Equal(2, queue.Length);

        var dequeue3Result = queue.Dequeue();
        Assert.Equal("3", dequeue3Result);
        Assert.Equal(1, queue.Length);

        var dequeue4Result = queue.Dequeue();
        Assert.Equal("4", dequeue4Result);
        Assert.Equal(0, queue.Length);
    }
}