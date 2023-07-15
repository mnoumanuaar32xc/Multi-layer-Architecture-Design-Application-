using NK.Model.DBModel;
using NK.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.ResponseModel
{
    public class UserResponseModel
    {
        public class GetUser: GenericResponseModel
        {
            public List<Users> Users { get; set; }

        }
    }
}
