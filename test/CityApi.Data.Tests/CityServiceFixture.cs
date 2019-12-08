using System;
using Xunit;

namespace CityApi.Data.Tests
{
    public class CityServiceFixture
    {
        [Fact]
        public void Constructor_IsGuarded()
        {
            Assert.Throws<ArgumentNullException>(() => new CityService(null, null, null));
        }

        [Theory]
        [AutoMoqData]
        public void AddCity_IsGuarded(CityService sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.AddCity(null));
        }

        [Theory]
        [AutoMoqData]
        public void UpdateCity_IsGuarded(CityService sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.UpdateCity(null));
        }
    }
}
