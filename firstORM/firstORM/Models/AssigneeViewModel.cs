using firstORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Models
{
    public class AssigneeViewModel
    {
        public Assignee Assignee { get; set; }
        public List<Assignee> Assignees { get; set; }
        public AssigneeViewModel()
        {
            Assignees = new List<Assignee>();
        }
    }
}
