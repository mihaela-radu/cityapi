using CityApi.Core.Models;
using Xunit;
using FluentAssertions;

namespace CityApi.Core.Tests.Models
{
    public class CityFixture
    {
        [Fact]
        public void Constructor_InitializesCountryProperty()
        {
            // Act
            var city = new City();

            // Assert
            city.Country.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_InitializesWeatherProperty()
        {
            // Act
            var city = new City();

            // Assert
            city.Weather.Should().NotBeNull();
        }
    }
}
