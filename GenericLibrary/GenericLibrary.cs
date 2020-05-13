using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericLibrary
{
    public class GenericLibrary<T> : IEnumerable<T>
    {
        T[] books;
        int totalOfBooks;

        public GenericLibrary(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException();

            books = new T[capacity];
        }

        public GenericLibrary() : this(3)
        {

        }

        public int TotalOfBooks => totalOfBooks;

        public T this[int index] => books[index];

        public void AddBook(T value)
        {
            if (books.Length == totalOfBooks)
            {
                Array.Resize(ref books, totalOfBooks * 2);
            }

            books[totalOfBooks] = value;
            totalOfBooks++;
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
