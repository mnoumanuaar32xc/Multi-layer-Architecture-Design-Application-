using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK.Model.DBModel
{
    public class Tasks
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long TaskTypeID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

    }

}
