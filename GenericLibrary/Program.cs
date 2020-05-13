using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GenericLibrary
{
    class GenericLibrary
    {

        public static void Main()
        {
            Console.WriteLine("Welcome to Marie and Francesco's really cool Library!");
            UserMenu();
            LibraryBooks();
            ViewLibrary();

        }

        public static GenericLibrary<Book> FrancescoAndMarieLibrary = new GenericLibrary<Book>();
        // USER MENU
        public static void UserMenu()
        {
            string[] userLibrarySelection =
            {
                "1. View Library ",
                "2. Add a book",
                "3. Borrow a book",
                "4. Return a book",
                "5. View book bag",
                "6. Leave library"
            };
            Console.WriteLine("Please choose a number to proceed");
            foreach(string action in userLibrarySelection)
            {
                Console.WriteLine(action);
            }
            try
            {
                UserChoice();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry something went wrong, please return at a later date {0}", ex.Message);
            }

        }
        public static void UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
             	        
		        case "1": 
                    ViewLibrary();
                break;
               /* case "2":
                    AddBook();
                break;
                case "3":
                    BorrowBook();
                break;
                case "4":
                    ReturnBook();
                break;
                case "5":
                    ViewBookBag();
                break;
                case "6":
                    LeaveLibrary();
                break;*/
                default:
                    Console.WriteLine("Wrong choice, try again");
                Console.ReadLine();
                break;
            
           
            }

           
        }

        //add set books
        public static void LibraryBooks()
        {
            Author author1 = new Author("Brandon", " Sanderson");
            Book book1 = new Book("The Way of Kings", author1, Book.Genre.Fantasy);

            Author author2 = new Author("Yotam", " Ottolenghi");
            Book book2 = new Book("Nopi", author2, Book.Genre.Cooking);

            Author author3 = new Author("Tom", " Rachman");
            Book book3 = new Book("The Italian Teacher", author3, Book.Genre.Other);

            Book[] LibraryBooks = new Book[] { book1, book2, book3 };
            foreach(Book book in LibraryBooks)
            {
                FrancescoAndMarieLibrary.Add(book);
            }




        }

        public static void ViewLibrary()
        {
            foreach(Book book in FrancescoAndMarieLibrary)
            {
                Console.WriteLine($"{book.title} | Author: {book.author.FirstName}{book.author.LastName} | Genre: {book.genre}");
               
            }
        }
    }
}
