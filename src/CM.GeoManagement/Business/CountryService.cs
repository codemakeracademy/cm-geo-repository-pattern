using System;
using System.Collections.Generic;
using System.Text;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.Business
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRegionRepository _regionRepository;

        public CountryService()
        {
            _countryRepository = new CountryRepository();
            _regionRepository = new RegionRepository();
        }

        public CountryService(IRepository<Country> countryRepository, 
            IRegionRepository regionRepository = null)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository ?? new RegionRepository();
        }

        public Country GetCountry(string countryCode)
        {
            if (countryCode == null) 
                throw new ArgumentNullException(nameof(countryCode));

            Country country;
            int tries = 0;
           
            while (true)
            {
                try
                {
                    country = _countryRepository.Read(countryCode);

                    if (country != null)
                    {
                        var regions = _regionRepository.ReadByCountryCode(countryCode);
                        country.Regions = regions;
                    }
                    
                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;

                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }

            if (country == null)
                throw new KeyNotFoundException();

            return country;
        }

        public Country Create(Country country)
        {
            _countryRepository.Create(country);

            return country;
        }
    }

    public interface ICountryService
    {
        Country GetCountry(string countryCode);
        Country Create(Country country);
    }
}
