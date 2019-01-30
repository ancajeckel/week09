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
    }
}
