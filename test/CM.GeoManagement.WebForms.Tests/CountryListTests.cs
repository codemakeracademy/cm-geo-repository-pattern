using System;
using System.Collections.Generic;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;
using Moq;
using Xunit;

namespace CM.GeoManagement.WebForms.Tests
{
    public class CountryListTests
    {
        [Fact]
        public void Test1()
        {
            var countryRepositoryMock = new Mock<ICountryRepository>();
            countryRepositoryMock.Setup(x => x.GetAll())
                .Returns(() => new List<Country>()
                {
                    new Country(),
                    new Country()
                });

            var countryList = new CountryList(countryRepositoryMock.Object);

            countryList.LoadCountiesFromDatabase();

            Assert.Equal(2, countryList.Countries.Count);
        }
    }
}
