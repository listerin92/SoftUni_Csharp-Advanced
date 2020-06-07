using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> data;

        public ListyIterator(params T[] item)
        {
            this.data = new List<T>() { item.ToList() };
        }
        public bool Move(int index)
        {
            return true;
        }
        public bool HasNext()
        {
            return true;
        }
        public void Print(int index)
        {

        }

    }
}
