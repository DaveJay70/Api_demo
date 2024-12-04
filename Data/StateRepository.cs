using Api_demo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_demo.Data
{
    public class StateRepository
    {
        private readonly string _connectionString;
        public StateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public IEnumerable<StateModel> SelectAll()
        {
            var states = new List<StateModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[PR_State_GetAll]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new StateModel
                    {
                        StateID = Convert.ToInt32(reader["StateID"]),
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        StateName = reader["StateName"].ToString(),
                        StateCode = reader["StateCode"].ToString()

                    });
                }

            }
             return states;
        }
    }
}
