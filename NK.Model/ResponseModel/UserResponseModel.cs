using NK.Model.DBModel;
using NK.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class UserResponseModel
    {
        public class GetUser: GenericResponseModel
        {
            public List<Users> Users { get; set; }

        }
        public class User_AddUpdate : GenericResponseModel
        {
            public long  ReturnId { get; set; }

        }
    }
}
