using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Repository
{
    public interface ITasksRepository
    {
        public Task<long> AddUpdateAsync(Tasks model);

    }
}
