using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialization
{
    [Serializable]
    [XmlRoot("Books")]
    public class Book
    {
        [XmlElement(ElementName = "BookId")]
        public int Id { get; set; }

        [XmlElement(ElementName = "BookName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "BookYear")]
        public int Year { get; set; }
    }
}
