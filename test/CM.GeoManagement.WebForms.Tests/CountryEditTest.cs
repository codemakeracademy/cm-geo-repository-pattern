using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;
using Moq;
using Xunit;

namespace CM.GeoManagement.WebForms.Tests
{
    public class CountryEditTest
    {

        [Fact]
        public void ShouldCreateCountry()
        {
            var countryRepository = new Mock<ICountryRepository>();

            var countryEdit = new CountryEdit(countryRepository.Object);
            
            countryEdit.OnSaveClick(this, EventArgs.Empty);

            countryRepository
                .Verify(x => x.Create(It.IsAny<Country>()));
        }
    }
}
