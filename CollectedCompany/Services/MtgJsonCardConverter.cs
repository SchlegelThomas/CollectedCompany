using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CollectedCompany.Models;
using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace CollectedCompany.Services
{
    public static class MtgJsonCardConverter
    {
        public static void ConvertCards()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            List<SetJsonModel> jsonSets = new List<SetJsonModel>();
            using (StreamReader streamReader = new StreamReader(@"C:\Users\Thomas\Documents\visual studio 2013\Projects\CollectedCompany\CollectedCompany\AllSetsArray-x.json"))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        SetJsonModel c = serializer.Deserialize<SetJsonModel>(reader);
                        jsonSets.Add(c);
                    }
                }
            }

            List<Set> sets = new List<Set>();

            foreach (var jsonSet in jsonSets)
            {
                Set newSet = Mapper.Map<SetJsonModel, Set>(jsonSet);
                sets.Add(newSet);
            }
            foreach (var set in sets)
            {
                set.Cards.ForEach(x =>
                {
                    if (x.Id.IsNullOrWhiteSpace())
                    {
                        x.Id = Guid.NewGuid().ToString();
                    }
                });
            }
            
            
            dbContext.Sets.AddRange(sets);
            dbContext.SaveChanges();

            var stuff = "this";
        }
    }
}