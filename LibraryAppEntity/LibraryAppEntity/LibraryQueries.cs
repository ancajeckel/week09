using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppEntity
{
    public static class LibraryQueries
    {
        public static void GetAllBooks(LibraryEntities library)
        {
            Console.WriteLine("----- All books ------");
            var books = library.Books.AsEnumerable();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookId} {book.Title} {book.Year}");
            }
        }

        public static void GetBooksByCategory(LibraryEntities library)
        {
            Console.WriteLine("----- Books by category ------");
            var books = from b in library.Books
                        join bc in library.BookCategories on b.BookId equals bc.BookId
                        join c in library.Categories on bc.CategoryId equals c.CategoryId
                        orderby c.Name
                        select new { b.Title, c.Name };

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name} {book.Title}");
            }
        }

        public static void DisplayOneBook(LibraryEntities library, int bookId)
        {
            var book = library.Books.SingleOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                Console.WriteLine($"Book {book.BookId} {book.Title} ({book.Year}) - ${book.Price}");
            }
        }

        public static void UpdateBook(LibraryEntities library, int bookId, int newYear)
        {
            Console.WriteLine($"Update book with id={bookId} set year={newYear}");
            var book = library.Books.SingleOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                DisplayOneBook(library, bookId); //get old record
                book.Year = newYear;
                library.SaveChanges();

                DisplayOneBook(library, bookId); //get new record
            }
        }
    }
}
