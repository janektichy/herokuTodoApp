using firstORM.Database;
using firstORM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Services
{
    public class AssigneeService
    {
        private ApplicationDbContext DbContext { get; }

        public AssigneeService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Assignee FindById(long id)
        {
            Assignee selectedAssignee = DbContext.Assignees.Include(a => a.Todos).FirstOrDefault(a => a.Id == id);
            return selectedAssignee;
        }
        public Assignee AddAssignee(Assignee assignee)
        {
            var savedAssignee = DbContext.Assignees.Add(assignee).Entity;
            DbContext.SaveChanges();
            return savedAssignee;
        }
        public List<Assignee> FindAll()
        {
            var allAssignees = DbContext.Assignees.Include(a => a.Todos).ToList();
            
            return allAssignees;
        }
        public void RemoveAssignee(Assignee assignee)
        {
            DbContext.Assignees.Remove(assignee);
            DbContext.SaveChanges();
        }
        public void EditAssignee(long id, string name, string email)
        {
            Assignee selectedAssignee = DbContext.Assignees.FirstOrDefault(t => t.Id == id);
            if (name is not null)
            {
                selectedAssignee.Name = name;
            }
            if (email is not null)
            {
                selectedAssignee.Email = email;
            }
            DbContext.SaveChanges();
        }
    }
}
