using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CM.GeoManagement.Business;
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
            var countryService = new Mock<ICountryService>();

            var countryEdit = new CountryEdit(countryService.Object);
            
            countryEdit.OnSaveClick(this, EventArgs.Empty);

            countryService
                .Verify(x => x.Create(It.IsAny<Country>()));
        }
    }
}
