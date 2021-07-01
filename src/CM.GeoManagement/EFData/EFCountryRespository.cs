using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.GeoManagement.BusinessEntities;
using CM.GeoManagement.Repositories;

namespace CM.GeoManagement.EFData
{
    public class EFCountryRepository : ICountryRepository
    {
        private GeoDataContext _context;

        public EFCountryRepository()
        {
            _context = new GeoDataContext();
        }
        
        public void Create(Country country)
        {
            _context
                .Countries
                .Add(country);

            _context.SaveChanges();
        }

        public Country Read(string countryCode)
        {
            throw new NotImplementedException();
        }

        public void Update(Country country)
        {
            throw new NotImplementedException();
        }

        public void Delete(string countryCode)
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            var countries = _context
                .Countries
                .Include("Regions")
                .ToList();

            foreach (var country in countries)
            {
                _context.Countries.Remove(country);
            }
            
            _context.SaveChanges();
        }
    }
}
