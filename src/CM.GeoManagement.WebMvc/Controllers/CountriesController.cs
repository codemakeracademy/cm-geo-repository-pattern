using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM.GeoManagement.Business;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.WebMvc.Controllers
{
    public class CountriesController : Controller
    {
        private ICountryService _countryService;


        public CountriesController()
        {
            _countryService = new CountryService();
        }

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }



        // GET: Countries
        public ActionResult Index()
        {
            var countries 
                = _countryService.GetCountries();

            return View(countries);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            var defaultValues = new Country();
            defaultValues.Regions = new List<Region>()
            {
                new Region()
            };

            return View(defaultValues);
        }

        // POST: Countries/Create
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                _countryService
                    .Create(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Countries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countries/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
