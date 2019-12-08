using Newtonsoft.Json;

namespace CityApi.Core.Models
{
    public class WeatherResponse
    {
        public WeatherResponse()
        {
            Weather = new Weather();
        }

        [JsonProperty("main")]
        public Weather Weather { get; set; }
    }
}
