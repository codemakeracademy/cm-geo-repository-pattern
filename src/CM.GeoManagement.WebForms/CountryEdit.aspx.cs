using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CM.GeoManagement.Business;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.WebForms
{
    public partial class CountryEdit : System.Web.UI.Page
    {
        private readonly ICountryService _countryService;

        public CountryEdit()
        {
            _countryService = new CountryService();
        }

        public CountryEdit(ICountryService countryService)
        {
            _countryService = countryService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var countryCodeReq = Request.QueryString["countryCode"];

                LoadCountry(countryCodeReq);
            }
            
                var items = regionsRepeater.Items;
            
        }

        public void LoadCountry(string countryCodeReq)
        {
            if (countryCodeReq != null)
            {
                var country = _countryService.GetCountry(countryCodeReq);

                countryCode.Text = country.CountryCode;
                countryName.Text = country.CountryName;

                country.Regions.Add(new Region());

                regionsRepeater.DataSource = country.Regions;
                regionsRepeater.DataBind();
            }
            else
            {

                regionsRepeater.DataSource = new List<Region>() {new Region()};
                regionsRepeater.DataBind();
            }
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            var country = new Country()
            {
                CountryCode = countryCode?.Text,
                CountryName = countryName?.Text,
            };

            _countryService.Create(country);

          //  Response?.Redirect("CountryList");
        }
    }
}