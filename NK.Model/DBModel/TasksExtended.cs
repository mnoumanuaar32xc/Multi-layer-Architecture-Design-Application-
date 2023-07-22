using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class TasksExtended:Tasks
    {
        public DEF_tasksType DEF_TasksType { get; set; }
        public Users Users { get; set; }

    }
}
