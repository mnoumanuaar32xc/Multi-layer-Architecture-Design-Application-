using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class UsersExtends:Users
    {
        public Tasks Tasks { get; set; }
    }
}
