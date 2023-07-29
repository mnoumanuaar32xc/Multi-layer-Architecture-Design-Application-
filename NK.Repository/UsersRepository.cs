using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NK.Model.DBModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace NK.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;
        private string constr = "";
        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public List<Users> GetUserById(int id)
        {
            constr = _configuration.GetConnectionString("DapperConnection");

            var sql = "SELECT * FROM Users WHERE ID = @Id";
            using (var connection = new SqlConnection(constr))
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
        public async Task<long> AddUpdateAsync(Users model)
        {
            constr =
            _configuration.GetConnectionString("DapperConnection");
            long returnId = 0;
            try
            {
                using (var connection = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("ID", value: model.ID);
                    p.Add("Name", value: model.Name);
                    p.Add("Address", model.Address);
                    p.Add("UserName", model.UserName);
                    p.Add("Password", model.Password);
                    p.Add("IdReturn", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await connection.ExecuteAsync("User_AddUpdate", p, commandType: CommandType.StoredProcedure);
                    returnId = p.Get<int>("IdReturn");
                }
            }
            catch (Exception ex)
            {
                 
            }
      
            return returnId;
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