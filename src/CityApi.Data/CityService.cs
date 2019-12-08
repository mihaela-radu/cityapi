using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityApi.Core;
using CityApi.Core.Models;

namespace CityApi.Data
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IWeatherServiceClient _weatherServiceClient;
        private readonly ICountryServiceClient _countryServiceClient;

        public CityService(ICityRepository cityRepository, IWeatherServiceClient weatherServiceClient, ICountryServiceClient countryServiceClient)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _weatherServiceClient = weatherServiceClient ?? throw new ArgumentNullException(nameof(weatherServiceClient));
            _countryServiceClient = countryServiceClient ?? throw new ArgumentNullException(nameof(countryServiceClient));
        }
        public void AddCity(City city)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));
            _cityRepository.AddCity(city);
        }

        public void DeleteCity(int cityId)
        {
            _cityRepository.DeleteCity(cityId);
        }

        public City FindCity(int cityId)
        {
            return _cityRepository.FindCity(cityId);
        }

        public async Task<IEnumerable<City>> GetCities(string cityName)
        {
            var cities = _cityRepository.GetCities(cityName);

            foreach(var city in cities)
            {
                city.Country = await _countryServiceClient.GetCountry(city.Country?.Name).ConfigureAwait(false);
                city.Weather = await _weatherServiceClient.GetWeather(city.Name, city.Country?.TwoLetterCode);
            }

            return cities;
        }

        public void UpdateCity(City city)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));
            _cityRepository.UpdateCity(city);
        }
    }
}
