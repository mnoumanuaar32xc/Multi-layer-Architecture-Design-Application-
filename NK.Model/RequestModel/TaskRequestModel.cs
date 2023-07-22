using NK.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class TaskRequestModel
    {

        public class GetTask
        {
            public int ID { get; set; }
        }

        public class Task_AddUpdate
        {
            public Tasks Task { get; set; }

        }

        public class Search
        {
            public long UserId { get; set; }
            public long TaskId { get; set; }
            public int TaskTypeId { get; set; }

        }
    }
}