using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericLibrary
{
    public class GenericLibrary<T> : IEnumerable<T>
    {
        T[] items;
        int count;

        public GenericLibrary(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException();

            items = new T[capacity];
        }

        public GenericLibrary() : this(3)
        {

        }

        public int Count => count;

        public T this[int index] => items[index];

        public void AddBook(T value)
        {
            if (items.Length == count)
            {
                Array.Resize(ref items, count * 2);
            }

            items[count] = value;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}
