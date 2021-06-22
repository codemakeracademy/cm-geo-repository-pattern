using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.WebForms
{
    public partial class CountryList : System.Web.UI.Page
    {
        private ICountryRepository _countryRepository;

        public CountryList()
        {
            _countryRepository = new CountryRepository();
        }

        public CountryList(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCountiesFromDatabase();
        }

        public void LoadCountiesFromDatabase()
        {
            Countries = _countryRepository.GetAll();
        }

        public List<Country> Countries { get; set; }
    }
}