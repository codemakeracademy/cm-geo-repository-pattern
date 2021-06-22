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

    public class CountryRepository : BaseRepository, ICountryRepository, IRepository<Country>
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

        public virtual Country Read(string countryCode)
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

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();

            using (var connection = new SqlConnection("Server=.\\sql2019;Database=Blaze;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Countries]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        countries.Add(new Country()
                        {
                            CountryCode = reader["CountryCode"]?.ToString(),
                            CountryName = reader["CountryName"]?.ToString()
                        });
                    }
                }

            }

            return countries;  
        }
    }

    public class CountryRepository2 : BaseRepository, IRepository<Country>
    {
        public void Create(Country entity)
        {
            var country = (Country) entity;

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
    }

    public interface ICountryRepository
    {
        void Create(Country country);
        Country Read(string countryCode);
        void Update(Country country);
        void Delete(string countryCode);

        List<Country> GetAll();
    }

    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Create(TEntity country);
        TEntity Read(string countryCode);
        void Update(TEntity country);
        void Delete(string countryCode);
    }


    public class Entity1Repository : IRepository<Region>
    {
        public void Create(Region country)
        {
            throw new NotImplementedException();
        }

        public Region Read(string countryCode)
        {
            var t = new List<Country>();

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
    }

}
