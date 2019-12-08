using CityApi.Core.Models;
using System.Threading.Tasks;

namespace CityApi.Core
{
    public  interface ICountryServiceClient
    {
        Task<Country> GetCountry(string countryName);
    }
}
