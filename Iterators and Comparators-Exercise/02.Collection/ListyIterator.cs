using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;
        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }
        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;

        }
        public bool HasNext()
        {
            if (this.index < this.data.Count - 1)
            {
                return true;
            }

            return false;
        }
        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[this.index]);

        }

        public void PrintAll()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            foreach (var dt in this.data)
            {
             Console.Write(dt + " ");
            }

            Console.WriteLine();

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var dt in data)
            {
                yield return dt;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
