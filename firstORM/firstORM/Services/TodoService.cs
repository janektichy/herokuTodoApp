using firstORM.Database;
using firstORM.Models.Entities;
using firstORM.Todos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Services
{
    public class TodoService
    {
        private ApplicationDbContext DbContext { get; }
        
        public TodoService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Todo FindById(long id)
        {
            return DbContext.Todos.Find(id);
        }
        public Todo AddTodo(Todo todo)
        {
            var savedTodo = DbContext.Todos.Add(todo).Entity;
            DbContext.SaveChanges();
            return savedTodo;
        }
        public List<Todo> FindAll()
        {
            var allTodos = DbContext.Todos.Include(a => a.Assignee).ToList();
            return allTodos;
        }
        public void RemoveTodo(Todo todo)
        {
            DbContext.Todos.Remove(todo);
            DbContext.SaveChanges();
        }
        public bool EditTodo(long id, string title, bool isUrgent, bool isDone, string assignee)
        {
            Todo selectedTodo = DbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (title is not null)
            {
                selectedTodo.Title = title;
            }
            bool doesAssigneeExist = false;
            if (assignee is not null)
            {
                foreach (var item in DbContext.Assignees)
                {
                    if (item.Name == assignee)
                    {
                        doesAssigneeExist = true;
                        selectedTodo.AssigneeId = item.Id;
                    }
                }
            }
            else
            {
                doesAssigneeExist = true;
            }
            selectedTodo.IsUrgent = isUrgent;
            selectedTodo.IsDone = isDone;
            DbContext.SaveChanges();
            return doesAssigneeExist;
        }
    }
}
