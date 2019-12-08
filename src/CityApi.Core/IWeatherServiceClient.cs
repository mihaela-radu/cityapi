using CityApi.Core.Models;
using System.Threading.Tasks;

namespace CityApi.Core
{
    public interface IWeatherServiceClient
    {
        Task<Weather> GetWeather(string cityName, string countryCode);
    }
}
