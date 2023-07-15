using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Infrastructure
{
    public interface IServices
    {
        public Task<List<Users>> GetUserById(int id);
    }
}
