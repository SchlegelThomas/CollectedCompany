using System.Collections.Generic;
using System.IO;
using AutoMapper;
using CollectedCompany.Models;
using CollectedCompany.Services;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            MtgJsonCardConverter.ConvertCards();

            var stuff = "things";

        }
    }
}
