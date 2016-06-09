using System;
using System.Collections.Generic;
using CollectedCompany.Models.Api;

namespace CollectedCompany.ServiceLayer.Integrations.CityState.Bindings
{
    public interface ICityStateApiService
    {
        List<State> GetStates();

        List<City> GetCitiesByState(String stateAbbreviation);
    }
}