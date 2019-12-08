using System.Collections.Generic;
using CityApi.Core.Models;

namespace CityApi.Core
{
    public interface ICityRepository
    {
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
        IEnumerable<City> GetCities(string cityName);
        City FindCity(int cityId);
    }
}
