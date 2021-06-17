using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class CountryRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCountryRepository()
        {
            var countryRepository = new CountryRepository();
            Assert.NotNull(countryRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCountry()
        {
            var countryRepository = new CountryRepository();
            var fixture = new CountryRepositoryFixture();

            countryRepository.DeleteAll();

            var country = fixture.MockCountry();

            countryRepository.Create(country);
        }
        
        [Fact]
        public void ShouldBeAbleToReadCountry()
        {
            var countryRepository = new CountryRepository();
            var fixture = new CountryRepositoryFixture();
            var country = fixture.CreateMockCountry();

            var createdCountry = countryRepository.Read("US");
            Assert.NotNull(createdCountry);

            Assert.Equal( country.CountryCode, createdCountry.CountryCode);
            Assert.Equal( country.CountryName, createdCountry.CountryName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCountry()
        {
            var countryRepository = new CountryRepository();
            var fixture = new CountryRepositoryFixture();
            var country = fixture.CreateMockCountry();

            country.CountryName = "Test";

            countryRepository.Update(country);

            var createdCountry = countryRepository.Read("US");
            Assert.NotNull(createdCountry);

            Assert.Equal( country.CountryCode, createdCountry.CountryCode);
            Assert.Equal( "Test", createdCountry.CountryName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCountry()
        {
            var countryRepository = new CountryRepository();
            var fixture = new CountryRepositoryFixture();
            var country = fixture.CreateMockCountry();
            
            var createdCountry = countryRepository.Read("US");
            Assert.NotNull(createdCountry);

            countryRepository.Delete("US");

            var deletedCountry = countryRepository.Read("US");
            Assert.Null(deletedCountry);
        }
    }

    public class CountryRepositoryFixture
    {
        public Country CreateMockCountry()
        {
            var countryRepository = new CountryRepository();
            countryRepository.DeleteAll();

            var country = MockCountry();
            countryRepository.Create(country);

            return country;
        }

        public Country MockCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "Unite States";

            return country;
        }

        public Region MockRegion()
        {
            var country = new Region();
            country.CountryCode = "US";

            return country;
        }
    }
}
