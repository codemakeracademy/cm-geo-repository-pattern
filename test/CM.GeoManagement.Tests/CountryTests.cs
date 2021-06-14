using System;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Common;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class CountryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "Unite States";
            
            Assert.Equal("US",    country.CountryCode);
            Assert.Equal("Unite States",    country.CountryName);
        }

        [Fact]
        public void ShouldBeAbleToAddRegionToCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "Unite States";

            var region = new Region();
            region.RegionCode = "IL";
            region.RegionName = "Illinois";
            region.CountryCode = "US";

            country.AddRegion(region);

            Assert.Equal(region, country.Regions[0]);
        }

        [Fact]
        public void ShouldNotBeAbleToAddRegionFromAnotherCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "Unite States";

            var region = new Region();
            region.CountryCode = "CA";

            Assert.Throws<GeoException>(() =>
            {
                country.AddRegion(region);
            });
            
        }
    }
}
