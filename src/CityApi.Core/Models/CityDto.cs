using System;
using System.ComponentModel.DataAnnotations;

namespace CityApi.Core.Models
{
    public class CityDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string CountryName { get; set; }       
        public int TouristRating { get; set; }
        public DateTime DateEstablished { get; set; }
        public long Population { get; set; }
    }
}
