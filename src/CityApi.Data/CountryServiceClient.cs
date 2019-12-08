using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CityApi.Core;
using CityApi.Core.Models;
using Newtonsoft.Json;

namespace CityApi.Infrastructure.External
{
    public class CountryServiceClient : ICountryServiceClient
    {
        private readonly HttpClient _client;

        public CountryServiceClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Country> GetCountry(string countryName)
        {
            
            var httpResponse = await GetResponseAsync(ComposeUri(countryName)).ConfigureAwait(false);
            if (httpResponse.IsSuccessStatusCode) 
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<Country>>(content).FirstOrDefault();
            }
            return null;
        }
        private async Task<HttpResponseMessage> GetResponseAsync(Uri uri) => await _client.GetAsync(uri).ConfigureAwait(false);

        private Uri ComposeUri(string countryName)
        {          
            var builder = new UriBuilder(_client.BaseAddress + "/" + countryName)
            {
                Query = "?fullText=true"
            };

            return builder.Uri;
        }
    }
}
