using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DataService
{
    public class ServiceDbContext: DbContext
    {
      public  string connectionString = "";
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options):base (options) 
        {
            connectionString = options.ContextType.Name.ToString();

        }


        //Service service = new Service(connectionString);


    }
}
