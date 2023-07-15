using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NK.Model.DBModel;
using System.ComponentModel;

namespace NK.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;

        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public List<Users> GetUserById(int id)
        {

            var sql = "SELECT * FROM Users WHERE ID = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                var p = new
                {
                    ID = id,
                };
                connection.Open();
                List<Users> users = connection.QueryAsync<Users>(sql, p).Result.AsList();
                connection.Close();

                return users;

            }

        }
        public bool AddAsync(Users model)
        {

            return true;
        }

        public bool DeleteAsync(int id)
        {

            return true;
        }

        public bool UpdateAsync(Users model)
        {
            throw new NotImplementedException();
        }


    }
}