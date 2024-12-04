using Api_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Api_demo.Data
{
    public class CityRepository
    {
        private readonly string _connectionString;
        public CityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public IEnumerable<CityModel> SelectAll()
        {
            var cities = new List<CityModel>();
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[PR_City_GetAll]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new CityModel
                    {
                        CityID = Convert.ToInt32(reader["CityID"]),
                        StateID = Convert.ToInt32(reader["StateID"]),
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        CityName = reader["CityName"].ToString(),
                        PinCode = reader["PinCode"].ToString(),

                    });
                }
            }
            return cities;
        }
        


    }
}
