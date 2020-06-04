using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Generic_Count_Method_String
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public T Value { get; set; }

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public int GetCountGreater<T>(T item) where  T : IComparable
        {
            int count = 0;
            foreach (var value in this.data)
            {
                if (item.CompareTo(value).Equals(-1))
                {
                    count++;
                }
            }
            return count;
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
