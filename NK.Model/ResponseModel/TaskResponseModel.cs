using NK.Model.DBModel;
using NK.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class TaskResponseModel
    {
        public class TaskUser : GenericResponseModel
        {
            public List<Tasks> Tasks { get; set; }

        }
        public class Task_AddUpdate : GenericResponseModel
        {
            public long ReturnId { get; set; }

        }
        public class TaskSearch : GenericResponseModel
        {
            public List<TasksExtended> Tasks { get; set; }
        }
    }

}