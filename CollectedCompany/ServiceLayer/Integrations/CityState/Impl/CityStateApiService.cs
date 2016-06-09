using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CollectedCompany.Models.Api;
using CollectedCompany.ServiceLayer.Integrations.CityState.Bindings;
using StatesHelper;
using WebGrease.Css.Extensions;

namespace CollectedCompany.ServiceLayer.Integrations.CityState.Impl
{
    public class CityStateApiService : ICityStateApiService
    {
        private readonly HttpClient _httpClient;


        public CityStateApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://api.sba.gov/geodata/")
            };
        }


        public List<State> GetStates()
        {
            
            var xmlStates = States.GetStatesFromXML();
            List<State> states = new List<State>();
            xmlStates.ForEach(x =>
            {
                if (x.Country == "US")
                {
                    states.Add(new State
                    {
                        Abbreviation = x.Abbreviation,
                        Name = x.Name
                    });
                }

            });
            

            return states;
        }



        public List<City> GetCitiesByState(String stateAbbreviation)
        {
            HttpResponseMessage response = _httpClient.GetAsync("city_links_for_state_of/" + stateAbbreviation + ".json").Result;
            if (response.IsSuccessStatusCode)
            {
                var yourcustomobjects = response.Content.ReadAsAsync<IEnumerable<City>>().Result;

                return yourcustomobjects.OrderBy(x => x.Name).Distinct().ToList();
            }
            
            return new List<City>();
        }
    }
}