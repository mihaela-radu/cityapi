using System;
using System.Net.Http;
using System.Threading.Tasks;
using CityApi.Core;
using CityApi.Core.Models;
using Newtonsoft.Json;

namespace CityApi.Infrastructure.External
{
    public class WeatherServiceClient : IWeatherServiceClient
    {
        private const string _apiKey = "f6099c2583f08cffe6d3b44bf32fd50c";
        private readonly HttpClient _client;

        public WeatherServiceClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Weather> GetWeather(string cityName, string countryCode)
        {
            var httpResponse = await GetResponseAsync(ComposeUri(cityName, countryCode)).ConfigureAwait(false);
            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<WeatherResponse>(content).Weather;
            }
            return null;

        }

        private async Task<HttpResponseMessage> GetResponseAsync(Uri uri) => await _client.GetAsync(uri).ConfigureAwait(false);

        private Uri ComposeUri(string cityName, string countryCode)
        {
            var queryString = $"?q={cityName},{countryCode}&appid={_apiKey}";

            var builder = new UriBuilder(_client.BaseAddress)
            {
                Query = queryString
            };

            return builder.Uri;
        }
    }
}
