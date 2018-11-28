using dotnet_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using dotnet_code_challenge.Services;

namespace dotnet_code_challenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHorsePriceService, HorsePriceService>()
                .BuildServiceProvider();

            List<HorsePriceModel> horsePriceList = new List<HorsePriceModel>();
            var horsePriceService = serviceProvider.GetService<IHorsePriceService>();

            horsePriceList.AddRange(horsePriceService.GetHorsePriceFromXml(Directory.GetCurrentDirectory() + @".\FeedData\Caulfield_Race1.xml"));
            horsePriceList.AddRange(horsePriceService.GetHorsePriceFromJson(Directory.GetCurrentDirectory() + @".\FeedData\Wolferhampton_Race1.json"));
            PrintHorsePriceList(horsePriceList);
        }

        private static void PrintHorsePriceList(List<HorsePriceModel> horsePrices)
        {
            foreach (var horse in horsePrices.OrderBy(x => x.Price))
            {
                Console.WriteLine("Horse Name: " + horse.HorseName + ". Price: " + horse.Price);
            }
        }
    }
}
