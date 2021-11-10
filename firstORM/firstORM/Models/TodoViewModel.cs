using firstORM.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Models
{
    public class TodoViewModel
    {
        public Todo Todo { get; set; }
        public List<Todo> Todos { get; set; }

        public TodoViewModel()
        {
            Todos = new List<Todo>();
        }
    }
}
