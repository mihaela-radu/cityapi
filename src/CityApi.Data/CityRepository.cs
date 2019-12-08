using AutoMapper;
using CityApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CityApi.Data;

namespace CityApi.Core
{
    public class CityRepository : ICityRepository
    {
        private readonly CityDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityRepository(CityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddCity(City city)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));

            var cityDto = _mapper.Map<CityDto>(city);
            _dbContext.Cities.Add(cityDto);
            _dbContext.SaveChanges();

        }

        public void DeleteCity(int cityId)
        {
            var cityDto = _dbContext.Cities.Find(cityId);

            if (cityDto != null)
            {
                _dbContext.Remove(cityDto);
                _dbContext.SaveChanges();
            }
        }

        public City FindCity(int cityId)
        {
            var cityDto = _dbContext.Cities.Find(cityId);
            return _mapper.Map<City>(cityDto);
        }

        public IEnumerable<City> GetCities(string cityName)
        {
            var cityDtos = _dbContext.Cities;
            var cities = new List<City>();
            foreach(var cityDto in cityDtos)
            {
                if (cityDto.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                {
                    var city = _mapper.Map<City>(cityDto);
                    cities.Add(city);
                }
            }
            return cities;
        }

        public void UpdateCity(City city)
        {
            if (city == null ) throw new ArgumentNullException(nameof(city));

            var cityDto = _mapper.Map<CityDto>(city);
            if (cityDto != null)
            {
                var cityToUpdate = _dbContext.Cities.First(g => g.Id == cityDto.Id);
                _dbContext.Entry(cityToUpdate).CurrentValues.SetValues(cityDto);
                _dbContext.SaveChanges();
            }
        }
    }
}
