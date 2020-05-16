using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace GenericLibrary
{
    public class UserInterface
    {

        public static void Main()
        {
           
            LibraryBooks();
            UserMenu();
            ViewLibrary();
           

        }

        public static GenericLibrary<Book> FrancescoAndMarieLibrary = new GenericLibrary<Book>();
        public static List<Book> BookBag = new List<Book>();

        public static Book.Genre BookGenre = new Book.Genre();
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
                    UserChoiceNextRound();
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
                    Console.WriteLine("Successfully added your book to the library");
                    UserChoiceNextRound();
                    return true;
                case "3":
                    Console.WriteLine("Please enter the name of the book you would like to borrow ");
                    ViewLibrary();
                    string bookToBeBorrowed = Console.ReadLine();
                    BorrowBOok(bookToBeBorrowed);
                    //next choice
                    UserChoiceNextRound();
                    return true;
                case "4":
                    ReturnBook();
                    return true;
                
                case "5":
                    int totalBooksInBag = ViewBookBag();
                    Console.WriteLine($"There are total {totalBooksInBag} in your books in your bag");
                    Console.ReadLine();
                    UserChoiceNextRound();
                    return true;

                case "6":
                    Console.WriteLine("Please visit the library again");
                    return false;
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

            try
            {
                foreach (Book book in FrancescoAndMarieLibrary)
                {
                    Console.WriteLine($"{book.title} | Author: {book.author.FirstName}{book.author.LastName} | Genre: {book.genre}");

                }
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine($"Sorry no books left in your book bag {0}", ex.Message);
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
                    FrancescoAndMarieLibrary.Add(book);
               
                    genre = false;
                    break;
                case "2":
                    Author author2 = new Author(firstName, lastName);
                    Book book2 = new Book(title, author2, Book.Genre.Cooking);
                    FrancescoAndMarieLibrary.Add(book2);

                    genre = false;
                    break;
                case "3":
                    Author author3 = new Author(firstName, lastName);
                    Book book3 = new Book(title, author3, Book.Genre.Selfhelp);
                    FrancescoAndMarieLibrary.Add(book3);
                    genre = false;
                    break;
                case "4":
                    Author author4 = new Author(firstName, lastName);
                    Book book4 = new Book(title, author4, Book.Genre.Religion);
                    FrancescoAndMarieLibrary.Add(book4);
                    genre = false;
                    break;
                case "5":
                    Author author5 = new Author(firstName, lastName);
                    Book book5 = new Book(title, author5, Book.Genre.Other);
                    FrancescoAndMarieLibrary.Add(book5);
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
        static void BorrowBOok(string title)
        {
            foreach (Book book in FrancescoAndMarieLibrary)
            {
                if (book.title == title)
                {
                    BookBag.Add(book);
                    FrancescoAndMarieLibrary.Remove(book);
                }
            }
        }
      
        // Return Book
        static string ReturnBook()
        {
            if (BookBag.Count == 0)
            {
                Console.WriteLine("Your book bag is empty");
                Console.ReadLine();
                return "";
            }

            Console.WriteLine("Please select the number of books you'd like to return");
            Dictionary<int, Book> booksInBookBag = new Dictionary<int, Book>();
            int bookCount = 1;
            foreach (Book book in BookBag)
            {
                Console.WriteLine($"{bookCount}: {book.title} | {book.author.FirstName} | {book.author.LastName} |{book.genre}");
                bookCount++;
            }
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier

            string bookNumber = Console.ReadLine();
            int.TryParse(bookNumber, out int selectionResult);
            booksInBookBag.TryGetValue(selectionResult, out Book bookReturned);
            BookBag.Remove(bookReturned);
            FrancescoAndMarieLibrary.Add(bookReturned);
            return "Removed book and added it back to library";

        }
        //View Book Bag
        static int ViewBookBag()
        {
            int totalBooksInBag = 0;
            foreach (var book in BookBag)
            {
                totalBooksInBag++;
            }

            if (totalBooksInBag == 0)
            {
                Console.WriteLine("Your book bag is empty");
            }

            foreach (var book in BookBag)
            {
                Console.WriteLine($"{book.title} | {book.author.FirstName} | {book.author.LastName} | {book.genre}");
            }

            return totalBooksInBag;
        }
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
                Console.WriteLine("Thanks for coming to the Library. GoodBye");
            }
        }
    }
}
