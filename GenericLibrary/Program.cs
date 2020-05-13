using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GenericLibrary
{
    public class UserInterface
    {

        public static void Main()
        {
           
            LibraryBooks();
            bool choices = true;
            while (choices)
            {
                choices = UserChoice();
            }
           

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
        public static bool UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {

                case "1":
                    ViewLibrary();
                    return true;
                
                case "2":
                    Console.WriteLine("Enter the Book you would like to add");
                    while (true)
                    {
                        Console.WriteLine("Title of book");
                        string title = Console.ReadLine();
                        Console.WriteLine("\n Authors First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("\n Authors Last Name");
                        string lastName = Console.ReadLine();
                        if(title.Length <= 0 && firstName.Length <= 0 && lastName.Length <= 0)
                        {
                            if (title.Length <= 0) Console.WriteLine("Please enter a book title to add new book");
                            if (firstName.Length <= 0) Console.WriteLine("Authors need a first name");
                            if (lastName.Length <= 0) Console.WriteLine("Authors need a last name");

                        }

                        else
                        {

                            bool addBook = true;
                            while (addBook)
                            {
                                addBook = AddBook(title, firstName, lastName); 
                            }
                            break;
                           
                          
                        }

                    }
                    Console.WriteLine("Sucessfully added your book to the library");
                    return true;
                /*case "3":
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
                    return true;
            
           
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

           
                foreach (Book book in FrancescoAndMarieLibrary)
                {
                    Console.WriteLine($"{book.title} | Author: {book.author.FirstName}{book.author.LastName} | Genre: {book.genre}");

                }
        }

        //Add books
        static bool AddBook(string title, string firstName, string lastName)
        {
            Console.WriteLine("Please choose a number  Genre to proceed");
            Console.WriteLine("1. Fantasy");
            Console.WriteLine("2. Cooking");
            Console.WriteLine("3. Selfhelp");
            Console.WriteLine("4. Religion");
            Console.WriteLine("5. Other");
            string genreChoice = Console.ReadLine();
            bool genre = true;
            //Switch case for UI
            switch (genreChoice)
            {
                case "1":
                    Author author = new Author(firstName, lastName);
                    Book book = new Book(title, author, Book.Genre.Fantasy);
               
                    genre = false;
                    break;
                   

                default:
                    Console.WriteLine("Wrong choice, try again");
                    Console.ReadLine();
                    break;
                    
                    
                    
            }
            return genre;
        }
        //Borrow Book 

      
        // Return Book

        //View Book Bag

        //Exit
      











        //reprompt to have user select anything else they might need
        public static void UserChoiceNextRound()
        {
            Console.WriteLine("Is there anything else we can do for you today?");
            Console.WriteLine("Yes/No");

            string response = Console.ReadLine().ToLower();

            if (response == "yes" || response == "y")
            {
                UserChoice();
            }
            else
            {
                Console.WriteLine("Thanks for choosing DeltaV ATM. GoodBye");
            }
        }
    }
}
