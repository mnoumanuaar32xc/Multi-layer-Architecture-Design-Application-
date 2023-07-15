using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.DataService
{
    public class Service:IService
    {
        string connection = "";
        public Service(string dbConnection) {
        
        }

        public string GetDataTest()
        { 
        return connection;
        
        }

    }
}
