using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialization
{
    class Program
    {
        private static void Main(string[] args)
        {
            Save("Authors.xml");

            Author a2 = Load("Authors.xml");

            Console.WriteLine($"Author {a2.Name}");

            Console.ReadKey();
        }

        public static void Save(string FileName)
        {
            Author a = fillDataForExport();
            using (var writer = new System.IO.StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(a.GetType());
                serializer.Serialize(writer, a);
                writer.Flush();
            }
        }

        public static Author Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(Author));
                return serializer.Deserialize(stream) as Author;
            }
        }

        public static Author fillDataForExport()
        {
            Book b1 = new Book();
            b1.Id = 1;
            b1.Name = "Poezii";
            b1.Year = 1832;

            Book b2 = new Book();
            b2.Id = 2;
            b2.Name = "Proza";

            Author a1 = new Author();
            a1.Name = "Mihai Eminescu";
            a1.Email = "eminescu@yahoo.com";
            a1.Age = 48;

            a1.ListBooks = new List<Book>();
            a1.ListBooks.Add(b1);
            a1.ListBooks.Add(b2);
            return a1;
        }
    }
}

