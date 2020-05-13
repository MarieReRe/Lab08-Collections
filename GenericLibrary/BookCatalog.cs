using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GenericLibrary
{
    class Book
    {

        public string title { get; set; }

        public Author author { get; set; }
        public Genre genre { get; set; }

        public Book(string BookTitle, Author BookAuthor, Genre BookGenre)
        {
            title = BookTitle;
            author = BookAuthor;
            genre = BookGenre;
              
        }

        public enum Genre 
        { Fantasy, Cooking, Selfhelp, Religion, Other}

       

    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(string AuthorFirstName, string AuthorLastName)
        {
            FirstName = AuthorFirstName;
            LastName = AuthorLastName;
        }
    }
}
