using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityApi.Core.Models
{
    public class Country
    {
        public string Name { get; set; }

        [JsonProperty("alpha2Code")]
        public string TwoLetterCode { get; set; }

        [JsonProperty("alpha3Code")]
        public string ThreeLetterCode { get; set; }

        public IEnumerable<Currency> Currencies { get; set; }

        public Country()
        {
            Currencies = new List<Currency>();
        }
    }
}
