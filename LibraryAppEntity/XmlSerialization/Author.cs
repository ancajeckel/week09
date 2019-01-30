using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    [XmlRoot("Authors")]
    public class Author
    {
        [XmlElement(ElementName = "AuthorName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "AuthorEmail")]
        public string Email { get; set; }

        [XmlElement(ElementName = "AuthorAge")]
        public int Age { get; set; }

        public List<Book> ListBooks { get; set; }
    }
}
