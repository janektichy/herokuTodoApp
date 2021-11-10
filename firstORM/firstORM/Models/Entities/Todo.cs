using firstORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Todos
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }
        public string DateOfCreation { get; set; }

        public Assignee Assignee { get; set; }
        public long? AssigneeId { get; set; }

        public Todo()
        {
            IsUrgent = false;
            IsDone = false;
            DateOfCreation = DateTime.Now.ToString();
        }
        public Todo(string title)
        {
            IsUrgent = false;
            IsDone = false;
            Title = title;
            DateOfCreation = DateTime.Now.ToString();
        }
    }
}
