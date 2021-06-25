using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CM.GeoManagement.Business;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.WebMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CM.GeoManagement.WebMvc.Tests.Controllers
{
    [TestClass]
    public class CountriesControllerTest
    {
        [TestMethod]
        public void ShouldCreateCountriesController()
        {
            CountriesController controller = new CountriesController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldReturnListOfCountries()
        {
            CountriesController controller = new CountriesController();
            controller.Index();
        }

        [TestMethod]
        public void ShouldCreateCountry()
        {
            var countryServiceMock = new Mock<ICountryService>();
            var controller = new CountriesController(countryServiceMock.Object);
            var country = new Country();

            var result = controller.Create(country) as RedirectToRouteResult;
            
            Assert.IsNotNull(result);
        }
    }
}
