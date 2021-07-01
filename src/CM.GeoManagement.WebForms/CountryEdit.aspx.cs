using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
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

        public Country Country { set; get; }
        
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

            Country = ViewState["MyObject"] as Country;

            if (Country != null)
            {
                regionsRepeater.DataSource = Country.Regions;
                regionsRepeater.DataBind();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var countryCodeReq = Request.QueryString["countryCode"];
                LoadCountry(countryCodeReq);
            }
            else
            {
                ReadValues();
            }
        }

        private void ReadValues()
        {
            Country.CountryCode = countryCode.Text;
            Country.CountryName = countryName.Text;

            for (var index = 0; index < regionsRepeater.Items.Count; index++)
            {
                var item = regionsRepeater.Items[index];
                var region = Country.Regions[index];

                region.RegionCode = ((TextBox) item.FindControl("regionCode")).Text;
                region.RegionName = ((TextBox) item.FindControl("regionName")).Text;
                region.CountryCode = ((HiddenField) item.FindControl("countryCode")).Value;
            }
        }


        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            regionsRepeater.DataBind();
            DataBind();
            ViewState["MyObject"] = Country;
        }


        public void LoadCountry(string countryCodeReq)
        {
            if (countryCodeReq != null)
            {
                Country = _countryService.GetCountry(countryCodeReq);
                Country.Regions.Add(new Region());
            }
            else
            {
                Country = new Country()
                {
                    Regions = new List<Region>()
                    {
                        new Region()
                    }
                };
            }

            regionsRepeater.DataSource = Country.Regions;
        }

        public void OnSaveClick(object sender, EventArgs e)
        {
            _countryService.Create(Country);

          //  Response?.Redirect("CountryList");
        }

        protected void AddRegion(object sender, EventArgs e)
        {
            Country?.AddRegion(new Region()
            {
                CountryCode = Country.CountryCode
            });
        }

    }
}