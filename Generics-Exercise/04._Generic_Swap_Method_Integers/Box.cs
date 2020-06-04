using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Generic_Swap_Method_Integers
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public void Swap(int indexOne, int indexTwo)
        {
            var temp = data[indexOne];
            this.data[indexOne] = this.data[indexTwo];
            this.data[indexTwo] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            data.ForEach(x => sb.AppendLine($"{x.GetType()}: {x}"));
            return sb.ToString().TrimEnd();
        }
    }
}
