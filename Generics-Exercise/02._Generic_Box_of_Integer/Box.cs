using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Box_of_Integer
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{item.GetType()}: {item}";

        }
    }
}
