using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using CM.GeoManagement.BusinessEntities;

namespace CM.GeoManagement.Repositories
{
    public class RegionRepository  : BaseRepository, IRegionRepository, IRepository<Region>
    {
        public void Create(Region region)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Regions] (RegionCode, CountryCode, RegionName) " +
                    "VALUES( @RegionCode, @CountryCode, @RegionName)", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = region.CountryCode
                };

                var regionNameParam = new SqlParameter("@RegionName", SqlDbType.VarChar, 100)
                {
                    Value = region.RegionName
                };

                var regionCodeParam = new SqlParameter("@RegionCode", SqlDbType.VarChar, 100)
                {
                    Value = region.RegionCode
                };

                command.Parameters.Add(countryCodeParam);
                command.Parameters.Add(regionNameParam);
                command.Parameters.Add(regionCodeParam);

                command.ExecuteNonQuery();

            }

        }

        public Region Read(string countryCode)
        {
            throw new NotImplementedException();
        }

        public void Update(Region country)
        {
            throw new NotImplementedException();
        }

        public void Delete(string countryCode)
        {
            throw new NotImplementedException();
        }

        public List<Region> ReadByCountryCode(string countryCode)
        {
            List<Region> regions = new List<Region>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Regions] WHERE CountryCode = @CountryCode "
                    , connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = countryCode
                };
                
                command.Parameters.Add(countryCodeParam);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        regions.Add(new Region()
                        {
                            CountryCode = reader["CountryCode"]?.ToString(),
                            RegionCode = reader["RegionCode"]?.ToString(),
                            RegionName = reader["RegionName"]?.ToString(),
                        });
                    }
                }

            }

            return regions;
        }
    }

    public interface IRegionRepository
    {
        void Create(Region region);

        List<Region> ReadByCountryCode(string countryCode);
    }
}
