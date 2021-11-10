using firstORM.Todos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Models.Entities
{
    public class Assignee
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
