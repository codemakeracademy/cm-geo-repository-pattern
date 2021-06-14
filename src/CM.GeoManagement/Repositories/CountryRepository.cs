using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CM.GeoManagement.BusinessEntities;

namespace CM.GeoManagement.Repositories
{
    /// <summary>
    /// CRUD. Create Read, Update, Delete
    /// </summary>

    public class CountryRepository : BaseRepository
    {
        public void Create(Country country)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO [Countries] (CountryCode, CountryName) " +
                    "VALUES( @CountryCode, @CountryName)", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = country.CountryCode
                };

                var countryNameParam = new SqlParameter("@CountryName", SqlDbType.VarChar, 100)
                {
                    Value = country.CountryName
                };

                command.Parameters.Add(countryCodeParam);
                command.Parameters.Add(countryNameParam);

                command.ExecuteNonQuery();

            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var deleteRegionsCommand = new SqlCommand(
                    "DELETE FROM [Regions]", connection);
                deleteRegionsCommand.ExecuteNonQuery();

                var command = new SqlCommand(
                    "DELETE FROM [Countries]", connection);

                command.ExecuteNonQuery();
            }
        }

        public Country Read(string countryCode)
        {
            using (var connection = new SqlConnection("Server=.\\sql2019;Database=Blaze;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Countries] WHERE CountryCode = @CountryCode", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = countryCode
                };

                command.Parameters.Add(countryCodeParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Country()
                        {
                            CountryCode = reader["CountryCode"]?.ToString(),
                            CountryName = reader["CountryName"]?.ToString()
                        };
                    }
                }

            }

            return null;   
        }

        public void Update(Country country)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "UPDATE [Countries] SET CountryName = @CountryName " +
                    " WHERE CountryCode = @CountryCode", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = country.CountryCode
                };

                var countryNameParam = new SqlParameter("@CountryName", SqlDbType.VarChar, 100)
                {
                    Value = country.CountryName
                };

                command.Parameters.Add(countryCodeParam);
                command.Parameters.Add(countryNameParam);

                command.ExecuteNonQuery();

            }
        }

        public void Delete(string countryCode)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [Countries] WHERE CountryCode = @CountryCode", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = countryCode
                };

                command.Parameters.Add(countryCodeParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
