using dotnet_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Services
{
    public interface IHorsePriceService
    {
        List<HorsePriceModel> GetHorsePriceFromXml(string filePath);
        List<HorsePriceModel> GetHorsePriceFromJson(string filePath);
    }
}
