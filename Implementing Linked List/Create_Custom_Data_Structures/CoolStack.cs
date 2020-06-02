using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public class CoolStack<T>
    {
        private T[] _values;
        private int _count;
        public CoolStack(int initialCapacity)
        {
            this._count = 0;
            this._values = new T[initialCapacity];
        }
        public CoolStack() : this(4)
        {
        }
        public int Count { get => this._count; }

        public void Push(T value)
        {
            if (this._count == this._values.Length)
            {
                var nextValues = new T[this._values.Length * 2];
                for (int i = 0; i < this._values.Length; i++)
                {
                    nextValues[i] = this._values[i];
                }
                this._values = nextValues;
            }

            this._values[this._count] = value;
            this._count++;
        }

        public object Pop(T value)
        {
            if (this._count == 0)
            {
                throw new InvalidOperationException("CoolStack is empty.");
            }
            var lastIndex = this._count - 1;
            var last = this._values[lastIndex];
            this._values[lastIndex] = default;
            this._count--;
            return last;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this._count; i++)
            {
                action(this._values[i]);
            }
        }
    }
}
