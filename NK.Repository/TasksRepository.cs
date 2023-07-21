using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Repository
{
    public class TasksRepository: ITasksRepository
    {
        private readonly IConfiguration _configuration;
        private string constr = "";
        public TasksRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task<long> AddUpdateAsync(Tasks model)
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
                    p.Add("UserID", value: model.UserID);
                    p.Add("TaskTypeID", model.TaskTypeID);
                    p.Add("Title", model.Title);
                    p.Add("Detail", model.Detail);
                    p.Add("IdReturn", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await connection.ExecuteAsync("Tasks_AddUpdate", p, commandType: CommandType.StoredProcedure);
                    returnId = p.Get<int>("IdReturn");
                }
            }
            catch (Exception ex)
            {

            }

            return returnId;
        }


    }
}
