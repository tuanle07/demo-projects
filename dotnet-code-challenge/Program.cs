using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            GetHorsePrice();
        }

        private static void GetHorsePrice()
        {
            XDocument doc = XDocument.Load(Directory.GetCurrentDirectory() + @".\FeedData\Caulfield_Race1.xml");
            var testtemp = doc.Descendants("horse");
            var test = from horse in doc.Descendants("horse")
                       select new
                       {
                           HorseName = (string)horse.Attribute("name"),
                           HorseNumber = (string)horse.Element("number")
                       };
            Console.WriteLine(test);
        }
    }
}
