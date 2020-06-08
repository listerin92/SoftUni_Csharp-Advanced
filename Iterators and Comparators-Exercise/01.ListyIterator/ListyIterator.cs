using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }

}
