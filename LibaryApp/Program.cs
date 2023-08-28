using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp
{
    class Program
    {
        //Method to check if the bookId is in a list, if it is it will remove it from currentList and add it to destinationList
        static void ManageAvailability(List<LibraryBook> currentList,List<LibraryBook> destinationList,int bookId)
        {
            //checks each object in a list to see if "BookId" is in a list other wise will give the user an error message
            foreach (LibraryBook i in currentList)
            {
                if (i.bookId == bookId)
                {
                    destinationList.Add(i);
                    currentList.Remove(i);
                }
                else
                {
                    Console.WriteLine("This is not a valid book");
                }
            }
        }
        //Method to loop through all objects in a list and print them to the console
        static void PrintList(List<LibraryBook> inputList)
        {            
            foreach (LibraryBook i in inputList)
            {
                Console.WriteLine($"Book {i.bookId}\nTitle: {i.title}\n{i.author}\n");
            }
        }
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
                            if (libraryBooks.Count() >= 1)
                                PrintList(libraryBooks);
                            else
                            {
                                Console.WriteLine("There are available books");
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
                                    ManageAvailability(libraryBooks, booksBorrowed, bookToBeBorrowed);                                  
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
                                    ManageAvailability(booksBorrowed, libraryBooks, bookToBeReturned);
                                }
                                catch
                                {
                                    Console.WriteLine("Please enter a valid book id");
                                }
                            }
                            continue;
                        //View borrowed books
                        case 5:
                            if (booksBorrowed.Count() >= 1)
                                PrintList(booksBorrowed);
                            else
                            {
                                Console.WriteLine("There are no borrowed books");
                            }
                            continue;
                        //Exit the program
                        case 6:
                            mainMenu = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }
    }
}
