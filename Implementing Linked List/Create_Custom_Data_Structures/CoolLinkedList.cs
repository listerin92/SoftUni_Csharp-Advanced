using System;

namespace Create_Custom_Data_Structures
{
    public class CoolLinkedList
    {
        private class CoolNode
        {
            public CoolNode(object value)
            {
                this.Value = value;
            }
            public object Value { get; }
            public CoolNode Next { get; set; }
            public CoolNode Previous { get; set; }
        }

        private CoolNode _head;
        private CoolNode _tail;

        public int Count { get; private set; }
        public object Head
        {
            get
            {
                this.ValidateIfListIsEmpty();
                return this._head.Value;
            }
        }
        public object Tail
        {
            get
            {
                this.ValidateIfListIsEmpty();
                return this._tail.Value;
            }
        }
        public void AddHead(object value)
        {
            var newNode = new CoolNode(value);
            if (this.Count == 0)
            {
                this._head = this._tail = newNode;
            }
            else
            {
                var oldHead = this._head;
                oldHead.Previous = newNode;
                newNode.Next = oldHead;
                this._head = newNode;
            }

            this.Count++;
        }
        public void AddTail(object value)
        {
            var newNode = new CoolNode(value);

            if (this.Count == 0)
            {
                this._head = this._tail = newNode;
            }
            else
            {
                var oldTail = this._tail;
                oldTail.Next = newNode;
                newNode.Previous = oldTail;
                this._tail = newNode;
            }

            this.Count++;
        }
        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();
            var value = this._head.Value;

            if (this._head == this._tail)
            {
                this._head = null;
                this._tail = null;
            }
            else
            {
                var newHead = this._head.Next;
                newHead.Previous = null;
                this._head.Next = null;
                this._head = newHead;
            }
            this.Count--;
            return value;
        }
        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();
            var value = this._tail.Value;
            if (this._head == this._tail)
            {
                this._head = null;
                this._tail = null;
            }
            else
            {
                var newTail = this._tail.Previous;
                newTail.Next = null;
                this._tail.Previous = null;
                this._tail = newTail;
            }
            this.Count--;
            return value;
        }
        public void Remove(object value)
        {
            var currentNode = this._head;

            while (currentNode != null)
            {
                var nodeValue = currentNode.Value;

                if (nodeValue.Equals(value))
                {
                    this.Count--;
                    var prevNode = currentNode.Previous;
                    var nextNode = currentNode.Next;
                    if (prevNode != null)
                    {
                        prevNode.Next = nextNode;
                    }

                    if (nextNode != null)
                    {
                        nextNode.Previous = prevNode;
                    }

                    if (this._head == currentNode)
                    {
                        this._head = nextNode;
                    }

                    if (this._tail == currentNode)
                    {
                        this._tail = prevNode;
                    }
                }
                currentNode = currentNode.Next;
            }
        }
        public bool Contains(object value)
        {
            var currentNode = this._head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;

                }
                currentNode = currentNode.Next;
            }
            return false;
        }
        public void Clear()
        {
            this._head = null;
            this._tail = null;
            this.Count = 0;
        }
        public void ForEach(Action<object> action, bool reverse = false)
        {
            var currentNode = reverse ? this._tail : this._head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = reverse ? currentNode.Previous : currentNode.Next;
            }
        }
        public object[] ToArray()
        {
            var arr = new object[this.Count];
            var currentNode = this._head;
            var index = 0;
            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }

            return arr;
        }
        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cool LinkedList is empty");
            }
        }
    }
}