using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAppEntity;

namespace LibraryAppEntity_refered
{
    class Program
    {
        static void Main(string[] args)
        {
            // init and use Entities (based on library db)
            LibraryEntities myLibrary = new LibraryEntities();

            // insert new book and get inserted record
            Book b = new Book
            {
                BookId = 50,
                Title = "New book",
                PublisherId = 3,
                Year = 0,
                Price = 25
            };

            //myLibrary.Books.Add(b);

            //myLibrary.SaveChanges();

            Console.ReadKey();
        }
    }
}
