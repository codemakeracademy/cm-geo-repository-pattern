using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CM.GeoManagement.BusinessEntities;

namespace CM.GeoManagement.Repositories
{
    public class RegionRepository  : BaseRepository, IRegionRepository
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
    }

    public interface IRegionRepository
    {
        void Create(Region region);
    }
}
