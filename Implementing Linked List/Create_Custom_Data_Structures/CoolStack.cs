using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public class CoolStack<T>
    {
        private T[] values;
        private int count;
        public CoolStack(int initialCapacity)
        {
            this.count = 0;
            this.values = new T[initialCapacity];
        }
        public CoolStack() : this(4)
        {
        }
        public int Count { get => this.count; }

        public void Push(T value)
        {
            if (this.count == this.values.Length)
            {
                var nextValues = new T[this.values.Length * 2];
                for (int i = 0; i < this.values.Length; i++)
                {
                    nextValues[i] = this.values[i];
                }
                this.values = nextValues;
            }

            this.values[this.count] = value;
            this.count++;
        }

        public object Pop(T value)
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("CoolStack is empty.");
            }
            var lastIndex = this.count - 1;
            var last = this.values[lastIndex];
            this.values[lastIndex] = default;
            this.count--;
            return last;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.values[i]);
            }
        }
    }
}
