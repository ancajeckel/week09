using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //file with path
            //CreateEditFile(@"D:\Temp\FileExample.txt");
            //EditWithAppend(@"D:\Temp\FileExample.txt");

            //file with no path -> it will be saved in bin/Debug
            CreateEditFile(@"FileExample.txt");
            EditWithAppend(@"FileExample.txt");
            Console.ReadKey();
        }

        static void CreateEditFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
                using (TextWriter tw = new StreamWriter(fileName))
                {
                    tw.WriteLine("The very first line!");
                    tw.Close();
                }
            }
            else if (File.Exists(fileName))
            {
                using (var tw = new StreamWriter(fileName, true))
                {
                    tw.WriteLine("The next line!");
                    tw.Close();
                }
            }
        }

        static void EditWithAppend(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.AppendAllText(fileName, "hello world\n");
            }
        }
    }
}
