using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp
{
    class LibraryBook
    {
        public int bookId;
        public string title;
        public string author;
        public bool isBorrowed;

        public LibraryBook(string Title, string Author, bool IsBorrowed, int BookId)
        {
            title = Title;
            author = Author;
            isBorrowed = IsBorrowed;
            bookId = BookId;
        }
    }
}
