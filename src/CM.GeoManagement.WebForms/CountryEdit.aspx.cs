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
    public partial class CountryEdit : System.Web.UI.Page
    {
        private ICountryRepository _countryRepository;

        public CountryEdit()
        {
            _countryRepository = new CountryRepository();
        }

        public CountryEdit(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var countryCodeReq = Request.QueryString["countryCode"];

                LoadCountry(countryCodeReq);
            }
        }

        public void LoadCountry(string countryCodeReq)
        {
            if (countryCodeReq != null)
            {
                var country = _countryRepository.Read(countryCodeReq);

                countryCode.Text = country.CountryCode;
                countryName.Text = country.CountryName;
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            var country = new Country()
            {
                CountryCode = countryCode?.Text,
                CountryName = countryName?.Text,
            };

            _countryRepository.Create(country);

            Response?.Redirect("CountryList");
        }
    }
}