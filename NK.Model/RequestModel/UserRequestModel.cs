using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.RequestModel
{
    public class UserRequestModel
    {

        public class GetUser
        {
            public int ID { get; set; }
        }
        public class Login
        {
            public string UserName { get; set; }
            public string  Password { get; set; }
        }
    }
}
