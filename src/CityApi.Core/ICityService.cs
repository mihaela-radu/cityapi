using CityApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityApi.Core
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCities(string cityName);

        City FindCity(int cityId);

        void AddCity(City city);

        void UpdateCity(City city);

        void DeleteCity(int cityId);
    }
}
