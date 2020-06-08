using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private class CoolNode
        {
            public CoolNode(T value)
            {
                this.Value = value;
            }
            public T Value { get; }
            public CoolNode Next { get; set; }
            public CoolNode Previous { get; set; }
        }

        private CoolNode _head;
        private CoolNode _tail;

        public int Count { get; private set; }
        public T Head
        {
            get
            {
                this.ValidateIfListIsEmpty();
                return this._head.Value;
            }
        }
        public T Tail
        {
            get
            {
                this.ValidateIfListIsEmpty();
                return this._tail.Value;
            }
        }
        public void AddHead(T value)
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
        public void AddTail(T value)
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
        public T RemoveHead()
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
        public T RemoveTail()
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
        public void Remove(T value)
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
        public bool Contains(T value)
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
        public void ForEach(Action<T> action, bool reverse = false)
        {
            var currentNode = reverse ? this._tail : this._head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = reverse ? currentNode.Previous : currentNode.Next;
            }
        }
        public T[] ToArray()
        {
            var arr = new T[this.Count];
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

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
