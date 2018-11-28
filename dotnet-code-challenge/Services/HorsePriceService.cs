using dotnet_code_challenge.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge.Services
{
    public class HorsePriceService : IHorsePriceService
    {
        public List<HorsePriceModel> GetHorsePriceFromXml(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            XDocument doc = XDocument.Load(filePath);
            var horsePrices = (from horse in doc.Descendants("horse").Where(x => x.Attribute("name") != null)
                               join horsePrice in doc.Descendants("horse").Where(x => x.Attribute("Price") != null)
                               on (int)horse.Element("number") equals (int)horsePrice.Attribute("number")
                               select new HorsePriceModel
                               {
                                   HorseName = (string)horse.Attribute("name"),
                                   Price = (double)horsePrice.Attribute("Price")
                               }).ToList();
            return horsePrices;
        }

        public List<HorsePriceModel> GetHorsePriceFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            JObject doc = JObject.Parse(File.ReadAllText(filePath));
            var horsePrices = (from horse in doc["RawData"]["Markets"].SelectMany(i => i["Selections"])
                               select new HorsePriceModel
                               {
                                   HorseName = (string)horse["Tags"]["name"],
                                   Price = (double)horse["Price"]
                               }).ToList();
            return horsePrices;
        }

    }
}
