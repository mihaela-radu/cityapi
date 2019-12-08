using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApi.Core.Models
{
    public class Weather
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }
    }
}
