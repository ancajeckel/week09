using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            // init and use Entities (based on library db)
            using (LibraryEntities myLibrary = new LibraryEntities())
            {
                // get all books
                LibraryQueries.GetAllBooks(myLibrary);

                // get books grouped by category (join)
                LibraryQueries.GetBooksByCategory(myLibrary);

                // update a book
                LibraryQueries.UpdateBook(myLibrary, 3, 1948);

                // insert new book and get inserted record
                Book b = new Book
                {
                    BookId = 30,
                    Title = "New book",
                    PublisherId = 3,
                    Year = 1980,
                    Price = 25
                };
                myLibrary.Books.Add(b);

                myLibrary.SaveChanges();
                LibraryQueries.DisplayOneBook(myLibrary, 30);
            }
            Console.ReadKey();
        }
    }
}
