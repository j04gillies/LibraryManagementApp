using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LibraryBook> libraryBooks = new List<LibraryBook>();
            List<LibraryBook> booksBorrowed = new List<LibraryBook>();
            //Adding the current inventory
            libraryBooks.Add(new LibraryBook("book1", "author 1", false,1009));

            int userChoice;
            bool mainMenu = true;
            while (mainMenu == true)
            {
                Console.WriteLine("MENU\n1)Add a book" +
                    "\n2)View available books\n3)Borrow a book\n4)Return a book\n5)View borrowed books\n6)Exit");
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    switch (userChoice)
                    {
                        //Add a book
                        case 1:
                            Console.WriteLine("Enter the title of the book:");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter the author:");
                            string author = Console.ReadLine();
                            Console.WriteLine("Enter the book ID:");
                            int bookId = 0;
                            while (bookId == 0)
                            {
                                try
                                {
                                    bookId = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Enter a valid book ID:");
                                }
                            }                            
                            var book = new LibraryBook(title, author, false, bookId);
                            libraryBooks.Add(book);
                            continue;
                        //View available books
                        case 2:                            
                            foreach(LibraryBook i in libraryBooks)
                            {
                                Console.WriteLine($"Book {i.bookId}\nTitle: {i.title}\n{i.author}\n");
                            }                            
                            continue;
                        //Borrow a book
                        case 3:
                            int bookToBeBorrowed = 0;
                            while(bookToBeBorrowed == 0)
                            {
                                try
                                {                                    
                                    Console.WriteLine("Enter the ID of the book you want to borrow:");
                                    bookToBeBorrowed = Convert.ToInt32(Console.ReadLine());
                                    //Loops through list of books to find book id
                                    foreach(LibraryBook i in libraryBooks)
                                    {
                                        if(i.bookId == bookToBeBorrowed)
                                        {
                                            //Adds the book to the borrowed list and removes it from available books
                                            booksBorrowed.Add(i);
                                            libraryBooks.Remove(i);
                                        }
                                    }                                    
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid book id");
                                }
                            }
                            continue;
                        //Return a book
                        case 4:
                            int bookToBeReturned = 0;
                            while (bookToBeReturned == 0)
                            {
                                try
                                {
                                    Console.WriteLine("Enter the ID of the book you want to return:");
                                    bookToBeReturned = Convert.ToInt32(Console.ReadLine());
                                    foreach (LibraryBook i in booksBorrowed)
                                    {
                                        if (i.bookId == bookToBeReturned)
                                        {
                                            libraryBooks.Add(i);
                                            booksBorrowed.Remove(i);                                            
                                        }
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid book id");
                                }
                            }
                            continue;
                        //View borrowed books
                        case 5:
                            foreach (LibraryBook i in booksBorrowed)
                            {
                                Console.WriteLine($"Book {i.bookId}\nTitle: {i.title}\n{i.author}\n");
                            }
                            continue;
                        //Exit the program
                        case 6:
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }
    }
}
