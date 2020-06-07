using System.Collections;
using System.Collections.Generic;

namespace _01._Library
{
    public class CatCollection : IEnumerable<CuteCat>
    {
        private List<CuteCat> cats;

        public CatCollection()
        {
            this.cats = new List<CuteCat>();
        }

        public void Add(CuteCat cat)
        {
            this.cats.Add(cat);
        }


        public IEnumerator<CuteCat> GetEnumerator()
        {
            for (int i = 0; i < this.cats.Count; i++)
            {
                yield return this.cats[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
