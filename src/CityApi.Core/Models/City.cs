using System;
using System.ComponentModel.DataAnnotations;

namespace CityApi.Core.Models
{
    public class City
    {
        public City()
        {
            Country = new Country();
            Weather = new Weather();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string State { get; set; }

        [Range(1, 5)]
        public byte TouristRating { get; set; }
        public DateTime DateEstablished { get; set; }
        public long Population { get; set; }
        public Country Country { get; set; }
        public Weather Weather { get; set; }
    }
}
