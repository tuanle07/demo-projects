using dotnet_code_challenge.Models;
using dotnet_code_challenge.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class HorsePriceServiceTest
    {
        private readonly IHorsePriceService _horsePriceService;

        public HorsePriceServiceTest()
        {
            _horsePriceService = new HorsePriceService();
        }

        [Fact]
        public void GetHorsePriceFromXml_FileNotExist_ShouldFail()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + @".\FeedData\Caulfield_Race.xml";

            //Act

            //Assert
            Assert.Throws<FileNotFoundException>(() => _horsePriceService.GetHorsePriceFromXml(filePath));
        }

        [Fact]
        public void GetHorsePriceFromXml_FileExist_ShouldWork()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + @".\FeedData\Caulfield_Race1.xml";

            //Act
            var actual = _horsePriceService.GetHorsePriceFromXml(filePath);

            //Assert
            Assert.IsType<List<HorsePriceModel>>(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(4.2, actual.Where(x => x.HorseName == "Advancing").First().Price);
            Assert.Equal(12, actual.Where(x => x.HorseName == "Coronel").First().Price);
        }

        [Fact]
        public void GetHorsePriceFromJson_FileNotExist_ShouldFail()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + @".\FeedData\Wolferhampton_Race.json";

            //Act

            //Assert
            Assert.Throws<FileNotFoundException>(() => _horsePriceService.GetHorsePriceFromJson(filePath));
        }

        [Fact]
        public void GetHorsePriceFromJson_FileExist_ShouldWork()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + @".\FeedData\Wolferhampton_Race1.json";

            //Act
            var actual = _horsePriceService.GetHorsePriceFromJson(filePath);

            //Assert
            Assert.IsType<List<HorsePriceModel>>(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(10, actual.Where(x => x.HorseName == "Toolatetodelegate").First().Price);
            Assert.Equal(4.4, actual.Where(x => x.HorseName == "Fikhaar").First().Price);
        }
    }
}
