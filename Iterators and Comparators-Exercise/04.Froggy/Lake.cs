using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> _data;

        public Lake(List<int> data)
        {
            this._data = data;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this._data.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return _data[i];
                }
            }
            for (int i = this._data.Count-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return _data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
