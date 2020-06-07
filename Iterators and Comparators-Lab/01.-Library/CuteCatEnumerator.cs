using System;
using System.Collections;
using System.Collections.Generic;

namespace _01._Library
{
    public class CuteCatEnumerator : IEnumerator<CuteCat>
    {
        private int index = -1;
        private List<CuteCat> cuteCats;
        public CuteCatEnumerator(List<CuteCat> cuteCats)
        {
            this.cuteCats = cuteCats;
        }
        public bool MoveNext()
        {
            this.index++;
            if (this.index < this.cuteCats.Count)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.index = -1;
        }

        public CuteCat Current => this.cuteCats[this.index];

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
