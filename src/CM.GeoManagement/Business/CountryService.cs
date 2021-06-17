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

        public CountryService()
        {
            _countryRepository = new CountryRepository();
        }

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
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
    }

    public interface ICountryService
    {

    }
}
