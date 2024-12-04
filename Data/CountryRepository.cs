using Api_demo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_demo.Data
{
    public class CountryRepository
    {
        private readonly string _connectionString;
        public CountryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public IEnumerable<CountryModel> SelectAll()
        {
            var country = new List<CountryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[PR_Country_GetAll]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    country.Add(new CountryModel
                    {
                        
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        CountryName = reader["CountryName"].ToString()
                       
                    });
                }

            }
            return country;
        }
    }
}
