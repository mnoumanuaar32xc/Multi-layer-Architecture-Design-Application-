using NK.Model.DBModel;
using NK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Infrastructure
{
    public class TasksServices
    {


        private ITasksRepository _tasksRepository;
        public TasksServices(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<long> Task_AddUpdate(Tasks model)
        {
            long ReturnId = 0;

            ReturnId = await _tasksRepository.AddUpdateAsync(model);
            return ReturnId;
        }

    }
}
