using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.BusinessEntities;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class RegionTest
    {
        [Fact]
        public void ShouldBeAbleCreateRegion()
        {
            var region = new Region();

            region.RegionCode = "IL";
            region.CountryCode = "US";
            region.RegionName = "Illinois";

            Assert.Equal("IL", region.RegionCode);
            Assert.Equal("US", region.CountryCode);
            Assert.Equal("Illinois", region.RegionName);
        }
    }
}
