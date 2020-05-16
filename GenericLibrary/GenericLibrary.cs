using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GenericLibrary
{
    public class GenericLibrary<T> : IEnumerable<T>
    {
        T[] books;
        int totalOfBooks = 0;

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

        public void Remove(T book)
        {

       
            for (int i = 0; i < totalOfBooks; i++)
            {
                if(BookExists(book))
                {
                    for (int j = 0; j < totalOfBooks - i; j++)
                    {
                        books[i] = books[i + 1];
                        i++;
                    }
                }
            }
            totalOfBooks--;
           
        }
        public bool BookExists(T book)
        {

            //what we had originally. missed a whle step
            for(int i = 0; i < totalOfBooks; i++)
            {
                if (books[i].Equals(book))
                {
                    return true;
                }
            }
            return false;
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
