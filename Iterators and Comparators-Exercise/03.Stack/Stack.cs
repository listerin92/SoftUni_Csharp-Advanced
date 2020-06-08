using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] collection;
        private int count;

        public Stack(int initialCapacity)
        {
            this.collection = new T[initialCapacity];
            this.count = 0;
        }

        public Stack() : this(4)
        {

        }
        public void Push(T value)
        {
            if (this.count == this.collection.Length)
            {
                IncreaseStack();
            }

            this.collection[this.count] = value;
            this.count++;
        }

        private void IncreaseStack()
        {
            var increasedCollection = new T[this.collection.Length * 2];
            for (int i = 0; i < this.collection.Length; i++)
            {
                increasedCollection[i] = this.collection[i];
            }

            this.collection = increasedCollection;
        }

        public object Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var lastIndex = this.count - 1;
            var last = this.collection[lastIndex];
            this.collection[lastIndex] = default;
            this.count--;
            return last;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
