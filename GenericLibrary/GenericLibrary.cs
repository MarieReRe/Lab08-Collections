using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericLibrary
{
    public class GenericLibrary<T> : IEnumerable<T>
    {
        T[] books;
        private int totalOfBooks = 0;

        public GenericLibrary(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException();

            books = new T[capacity];
        }

        public GenericLibrary() : this(10)
        {

        }

        public int Count => totalOfBooks;

        public T this[int index] => books[index];

        public void Add(T book)
        {
            if (totalOfBooks == books.Length)
            {
                Array.Resize(ref books, totalOfBooks * 2);
            }
            books[totalOfBooks++] = book;
            
            
            
        }

        public bool Remove(T book)
        {
            int indexToRemove = -1;
       
            for (int i = 0; i < totalOfBooks; i++)
            {
                if (EqualityComparer<T>.Default.Equals(books[i], book))
                {
                    indexToRemove = i;
                    break;
                }
            }
            return RemoveAt(indexToRemove);
        }
        public bool RemoveAt(int indexToRemove)
        {
            if (indexToRemove < 0)
            {
                return false;
            }

            for (int i = indexToRemove; i < totalOfBooks; i++)
            {
                books[i] = books[i + 1];
            }

            books[totalOfBooks--] = default;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < totalOfBooks; i++)
            {
                yield return books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}
