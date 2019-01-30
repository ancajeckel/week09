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
            }
            Console.ReadKey();
        }


    }
}
