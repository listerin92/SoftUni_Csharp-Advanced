using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections.Generic
{
    /// <summary>Represents a variable size last-in-first-out (LIFO) collection of instances of the same arbitrary type.</summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    /// <filterpriority>1</filterpriority>
     
    [ComVisible(false)]
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public class Stack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
    {
        private T[] _array;

        private int _size;

        private int _version;

        [NonSerialized]
        private object _syncRoot;

        private const int _defaultCapacity = 4;

        private static T[] _emptyArray;

        /// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
         
        public int Count
        {
             
            get
            {
                return this._size;
            }
        }

        /// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).</summary>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="T:System.Collections.Generic.Stack`1" />, this property always returns false.</returns>
         
        bool System.Collections.ICollection.IsSynchronized
        {
             
            get
            {
                return false;
            }
        }

        /// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</summary>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.  In the default implementation of <see cref="T:System.Collections.Generic.Stack`1" />, this property always returns the current instance.</returns>
         
        object System.Collections.ICollection.SyncRoot
        {
             
            get
            {
                if (this._syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
                }
                return this._syncRoot;
            }
        }

        static Stack()
        {
            Stack<T>._emptyArray = new T[0];
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.Stack`1" /> class that is empty and has the default initial capacity.</summary>
         
        public Stack()
        {
            this._array = Stack<T>._emptyArray;
            this._size = 0;
            this._version = 0;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.Stack`1" /> class that is empty and has the specified initial capacity or the default initial capacity, whichever is greater.</summary>
        /// <param name="capacity">The initial number of elements that the <see cref="T:System.Collections.Generic.Stack`1" /> can contain.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="capacity" /> is less than zero.</exception>
         
        public Stack(int capacity)
        {
            if (capacity < 0)
            {

                throw new ArgumentOutOfRangeException();
            }
            this._array = new T[capacity];
            this._size = 0;
            this._version = 0;
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.Stack`1" /> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</summary>
        /// <param name="collection">The collection to copy elements from.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="collection" /> is null.</exception>
         
        public Stack(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            ICollection<T> ts = collection as ICollection<T>;
            if (ts != null)
            {
                int count = ts.Count;
                this._array = new T[count];
                ts.CopyTo(this._array, 0);
                this._size = count;
                return;
            }
            this._size = 0;
            this._array = new T[4];
            foreach (T t in collection)
            {
                this.Push(t);
            }
        }

        /// <summary>Removes all objects from the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <filterpriority>1</filterpriority>
         
        public void Clear()
        {
            Array.Clear(this._array, 0, this._size);
            this._size = 0;
            this._version++;
        }

        /// <summary>Determines whether an element is in the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.Stack`1" />; otherwise, false.</returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.Stack`1" />. The value can be null for reference types.</param>
         
        public bool Contains(T item)
        {
            int num = this._size;
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            do
            {
            Label0:
                int num1 = num;
                num = num1 - 1;
                if (num1 <= 0)
                {
                    return false;
                }
                if (item != null)
                {
                    continue;
                }
                if (this._array[num] == null)
                {
                    return true;
                }
                else
                {
                    goto Label0;
                }
            }
            while (this._array[num] == null || !@default.Equals(this._array[num], item));
            return true;
        }

        /// <summary>Copies the <see cref="T:System.Collections.Generic.Stack`1" /> to an existing one-dimensional <see cref="T:System.Array" />, starting at the specified array index.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.Stack`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="arrayIndex" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.Stack`1" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.</exception>
         
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0 || arrayIndex > (int)array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((int)array.Length - arrayIndex < this._size)
            {
                throw new ArgumentException();
            }
            Array.Copy(this._array, 0, array, arrayIndex, this._size);
            Array.Reverse(array, arrayIndex, this._size);
        }

        /// <summary>Returns an enumerator for the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <returns>An <see cref="T:System.Collections.Generic.Stack`1.Enumerator" /> for the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
         
        public Stack<T>.Enumerator GetEnumerator()
        {
            return new Stack<T>.Enumerator(this);
        }

        /// <summary>Returns the object at the top of the <see cref="T:System.Collections.Generic.Stack`1" /> without removing it.</summary>
        /// <returns>The object at the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.Stack`1" /> is empty.</exception>
         
        public T Peek()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException();
            }
            return this._array[this._size - 1];
        }

        /// <summary>Removes and returns the object at the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <returns>The object removed from the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.Stack`1" /> is empty.</exception>
         
        public T Pop()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException();
            }
            this._version++;
            int num = this._size - 1;
            this._size = num;
            T t = this._array[num];
            this._array[this._size] = default(T);
            return t;
        }

        /// <summary>Inserts an object at the top of the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
        /// <param name="item">The object to push onto the <see cref="T:System.Collections.Generic.Stack`1" />. The value can be null for reference types.</param>
         
        public void Push(T item)
        {
            if (this._size == (int)this._array.Length)
            {
                T[] tArray = new T[(this._array.Length == 0 ? 4 : 2 * (int)this._array.Length)];
                Array.Copy(this._array, 0, tArray, 0, this._size);
                this._array = tArray;
            }
            T[] tArray1 = this._array;
            int num = this._size;
            this._size = num + 1;
            tArray1[num] = item;
            this._version++;
        }

         
        IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new Stack<T>.Enumerator(this);
        }

        /// <summary>Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="arrayIndex" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="array" /> is multidimensional.-or-<paramref name="array" /> does not have zero-based indexing.-or-The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.-or-The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
         
        void System.Collections.ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Rank != 1)
            {
                throw new ArgumentException();
            }
            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException();
            }
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (array.Length - arrayIndex < this._size)
            {
                throw new ArgumentException();
            }
            try
            {
                Array.Copy(this._array, 0, array, arrayIndex, this._size);
                Array.Reverse(array, arrayIndex, this._size);
            }
            catch (ArrayTypeMismatchException arrayTypeMismatchException)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
         
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Stack<T>.Enumerator(this);
        }

        /// <summary>Copies the <see cref="T:System.Collections.Generic.Stack`1" /> to a new array.</summary>
        /// <returns>A new array containing copies of the elements of the <see cref="T:System.Collections.Generic.Stack`1" />.</returns>
         
        public T[] ToArray()
        {
            T[] tArray = new T[this._size];
            for (int i = 0; i < this._size; i++)
            {
                tArray[i] = this._array[this._size - i - 1];
            }
            return tArray;
        }

        /// <summary>Sets the capacity to the actual number of elements in the <see cref="T:System.Collections.Generic.Stack`1" />, if that number is less than 90 percent of current capacity.</summary>
         
        public void TrimExcess()
        {
            int length = (int)((double)((int)this._array.Length) * 0.9);
            if (this._size < length)
            {
                T[] tArray = new T[this._size];
                Array.Copy(this._array, 0, tArray, 0, this._size);
                this._array = tArray;
                this._version++;
            }
        }

        /// <summary>Enumerates the elements of a <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
         
        [Serializable]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private Stack<T> _stack;

            private int _index;

            private int _version;

            private T currentElement;

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="T:System.Collections.Generic.Stack`1" /> at the current position of the enumerator.</returns>
            /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
             
            public T Current
            {
                 
                get
                {
                    if (this._index == -2)
                    {
                        throw new InvalidOperationException();
                    }
                    if (this._index == -1)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.currentElement;
                }
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator.</returns>
            /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
             
            object System.Collections.IEnumerator.Current
            {
                 
                get
                {
                    if (this._index == -2)
                    {
                        throw new InvalidOperationException();
                    }
                    if (this._index == -1)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.currentElement;
                }
            }

            internal Enumerator(Stack<T> stack)
            {
                this._stack = stack;
                this._version = this._stack._version;
                this._index = -2;
                this.currentElement = default(T);
            }

            /// <summary>Releases all resources used by the <see cref="T:System.Collections.Generic.Stack`1.Enumerator" />.</summary>
             
            public void Dispose()
            {
                this._index = -1;
            }

            /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.Stack`1" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
             
            public bool MoveNext()
            {
                bool flag;
                if (this._version != this._stack._version)
                {
                    throw new InvalidOperationException();
                }
                if (this._index == -2)
                {
                    this._index = this._stack._size - 1;
                    flag = this._index >= 0;
                    if (flag)
                    {
                        this.currentElement = this._stack._array[this._index];
                    }
                    return flag;
                }
                if (this._index == -1)
                {
                    return false;
                }
                int num = this._index - 1;
                this._index = num;
                flag = num >= 0;
                if (!flag)
                {
                    this.currentElement = default(T);
                }
                else
                {
                    this.currentElement = this._stack._array[this._index];
                }
                return flag;
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection. This class cannot be inherited.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
             
            void System.Collections.IEnumerator.Reset()
            {
                if (this._version != this._stack._version)
                {
                    throw new InvalidOperationException();
                }
                this._index = -2;
                this.currentElement = default(T);
            }
        }
    }
}