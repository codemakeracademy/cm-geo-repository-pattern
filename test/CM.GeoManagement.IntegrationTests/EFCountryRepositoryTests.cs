using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagement.EFData;
using CM.GeoManagement.Repositories;
using CM.GeoManagement.Tests;
using Xunit;

namespace CM.GeoManagement.IntegrationTests
{
    public class EFCountryRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEfCountryRepository()
        {
            var countryRepository = new EFCountryRepository();
            Assert.NotNull(countryRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCountry()
        {
            var countryRepository = new EFCountryRepository();
            var fixture = new CountryRepositoryFixture();

           // countryRepository.DeleteAll();

            var country = fixture.MockCountry();

            countryRepository.Create(country);
        }
    }
}
