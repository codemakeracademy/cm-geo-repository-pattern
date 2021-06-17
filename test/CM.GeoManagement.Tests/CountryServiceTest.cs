using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.Business;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;
using Moq;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class CountryServiceTest
    {
        [Fact]
        public void ShouldInitializeCountryService()
        {
            var service = new CountryService();

        }

        [Fact]
        public void ShouldGetCountryByCode()
        {
            var countryCountryMock = new Mock< IRepository<Country>>();

            var countryExpected = new Country();

            countryCountryMock
                .Setup(x => x.Read("US"))
                .Returns(() => countryExpected);

            var service = new CountryService(countryCountryMock.Object);

            var country = service.GetCountry("US");

            Assert.Equal(countryExpected, country);

            countryCountryMock
                .Verify(x => x.Read("US"), Times.AtLeastOnce);
        }

        [Fact]
        public void ShouldThrowNullArgumentException()
        {
            var countryCountryMock = new Mock< IRepository<Country>>();

            countryCountryMock
                .Setup(x => x.Read("US"))
                .Returns(() => null);

            var service = new CountryService(countryCountryMock.Object);
            
            Assert.Throws<KeyNotFoundException>(() => service.GetCountry("US"));
        }

        [Fact]
        public void ShouldRetryOnTimeOut()
        {
            var countryCountryMock = new Mock< IRepository<Country>>();

            countryCountryMock
                .Setup(x => x.Read("US"))
                .Throws<TimeoutException>();

            var service = new CountryService(countryCountryMock.Object);
            
            Assert.Throws<TimeoutException>(() => service.GetCountry("US"));
        }


        [Fact]
        public void ShouldThrowNotFoundException()
        {
            var fixture = new CountryServiceFixture();
            var service = fixture.CreateService();
            
            Assert.Throws<ArgumentNullException>(() => service.GetCountry(null));
        }

        [Fact]
        public void ShouldGetCountryByCodeWithOutMoq()
        {
            var countryExpected = new Country();

            var countryCountryMock = new TestCountryRepositoryCustomMock(
                countryExpected
            );

            var service = new CountryService(countryCountryMock);

            var country = service.GetCountry("US");

            Assert.Equal(countryExpected, country);
        }


        public class TestCountryRepositoryCustomMock : IRepository<Country>
        {
            private readonly Country _expectedCountryOnRead;

            public TestCountryRepositoryCustomMock(Country expectedCountryOnRead)
            {
                _expectedCountryOnRead = expectedCountryOnRead;
            }

            public void Create(Country country)
            {
                throw new NotImplementedException();
            }

            public Country Read(string countryCode)
            {
                return _expectedCountryOnRead;
            }

            public void Update(Country country)
            {
                throw new NotImplementedException();
            }

            public void Delete(string countryCode)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class CountryServiceFixture
    {
        public CountryServiceFixture()
        {
            CountryRepositoryMock = new Mock<IRepository<Country>>();

            CountryRepositoryMock
                .Setup(x => x.Read("US"))
                .Returns(() => CreateCountry());
        }

        public Country CreateCountry()
        {
            return new Country();
        }

        public Mock<IRepository<Country>> CountryRepositoryMock { get; set; }

        public CountryService CreateService()
        {
            return new CountryService(CountryRepositoryMock.Object);
        }
    }
}
