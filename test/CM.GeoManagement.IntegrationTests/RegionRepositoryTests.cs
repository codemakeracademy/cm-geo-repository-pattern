using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class RegionRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateRegionRepository()
        {
            var regionRepository = new RegionRepositoryTests();
            Assert.NotNull(regionRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateRegion()
        {
            var countryFixture = new CountryRepositoryFixture();
            var country = countryFixture.CreateMockCountry();

            var regionRepository = new RegionRepository();
            var region = new Region();

            region.RegionCode = "IL";
            region.CountryCode = country.CountryCode;
            region.RegionName = "Illinois";
            
            regionRepository.Create(region);

        }

        [Fact]
        public void ShouldBeAbleToReadRegionsByCountryId()
        {
            var countryFixture = new CountryRepositoryFixture();
            var country = countryFixture.CreateMockCountry();

            var regionRepository = new RegionRepository();
            var region = new Region();

            region.RegionCode = "IL";
            region.CountryCode = country.CountryCode;
            region.RegionName = "Illinois";
            
            regionRepository.Create(region);

            var regions = regionRepository.ReadByCountryCode(region.CountryCode);

            Assert.True(regions.Count > 0);

            Assert.Equal("IL", regions[0].RegionCode);
            Assert.Equal("Illinois", regions[0].RegionName);
        }
    }
}

