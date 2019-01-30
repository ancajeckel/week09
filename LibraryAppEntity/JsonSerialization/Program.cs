using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace JsonSerialization
{
    [DataContract]
    public class Dog
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember(Name = "Tags")]
        public List<String> DistinctiveFeatures { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Save("Dog.js");
            Console.ReadKey();
        }

        public static void Save(string FileName)
        {
            var doggg = new Dog
            {
                Name = "Fluffy",
                BirthDate = DateTime.Now,
                DistinctiveFeatures = new List<string>
                {
                    "black tail",
                    "green eyes"
                }
            };

            var ser = new DataContractJsonSerializer(typeof(Dog));
            var output = string.Empty;

            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, doggg);
                output = Encoding.UTF8.GetString(ms.ToArray());

                // Position stream to 0.
                ms.Position = 0;

                using (FileStream file = new FileStream(FileName, FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);
                    file.Write(bytes, 0, bytes.Length);
                    ms.Close();
                }
            }

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(output)))
            {
                var processedDog = (Dog)ser.ReadObject(ms);
                // The two dogs will be the same

                if (doggg.Name == processedDog.Name)
                {
                    Console.WriteLine("Pre- and post dog are the same");
                }
            }
        }
    }
}