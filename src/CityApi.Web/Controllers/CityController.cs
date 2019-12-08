using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Core;
using CityApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/City/london
        [HttpGet("{cityName}", Name ="Get")]
        public async Task<ActionResult<IEnumerable<City>>> Get(string cityName)
        {
            try
            {
                var cities = await _cityService.GetCities(cityName).ConfigureAwait(false);
                return new JsonResult(cities);
            }
            catch (Exception ex)
            {
                return HandleServerError(ex);
            }
        }

        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<City>> Post([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cities = await _cityService.GetCities(city.Name).ConfigureAwait(false);
                var existingCity = cities.FirstOrDefault(c => c.Name.Equals(city.Name) && c.State.Equals(city.State) && c.Population == city.Population);

                if (existingCity != null)
                    return BadRequest("Provided city already exists.");

                _cityService.AddCity(city);                
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return HandleServerError(ex);
            }
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public ActionResult<City> Put(int id, [FromBody] City postedCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var city = _cityService.FindCity(id);

                if (city == null)
                    return NotFound(id);

                city.TouristRating = postedCity.TouristRating;
                city.DateEstablished = postedCity.DateEstablished;
                city.Population = postedCity.Population;

                _cityService.UpdateCity(city);

                return Ok();
            }
            catch (Exception ex)
            {
                return HandleServerError(ex);
            }
        }


        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public ActionResult<City> Delete(int id)
        {
            try
            {
                _cityService.DeleteCity(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return HandleServerError(ex);
            }
        }

        private ObjectResult HandleServerError(Exception ex)
        {
            var errorMessage = $"Something went wrong: {ex.Message}";
            _logger.LogError(errorMessage);
            return StatusCode(500, errorMessage);
        }
    }
}
