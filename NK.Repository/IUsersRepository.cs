using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Repository
{
    public interface IUsersRepository
    {
        public List<Users> GetUserById(int id);
        bool AddAsync(Users model);

        bool UpdateAsync(Users model);
    }
}
