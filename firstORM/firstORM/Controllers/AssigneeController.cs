using firstORM.Models;
using firstORM.Models.Entities;
using firstORM.Services;
using firstORM.Todos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstORM.Controllers
{
    [Route("assignee")]
    public class AssigneeController : Controller
    {
        public AssigneeService AssigneeService { get; set; }
        public AssigneeController(AssigneeService service)
        {
            AssigneeService = service;
        }
        [HttpGet("")]
        [HttpGet("list")]
        public IActionResult List()
        {
            AssigneeViewModel model = new AssigneeViewModel();
            model.Assignees = AssigneeService.FindAll().ToList();
            return View(model);
        }
        [HttpGet("addAssignee")]
        public IActionResult AddAssignee()
        {
            return View("addAssignee");
        }
        [HttpPost("add")]
        public IActionResult Add(string name, string email)
        {
            Assignee newAssignee = new Assignee() { Email = email, Name = name};
            AssigneeService.AddAssignee(newAssignee);
            return RedirectToAction("List");
        }
        [HttpGet("{id=id}/delete")]
        public IActionResult DeleteAssignee([FromRoute] long id)
        {
            Assignee selectedAssignee = AssigneeService.FindById(id);
            AssigneeService.RemoveAssignee(selectedAssignee);
            return RedirectToAction("List");
        }
        [HttpGet("{id=id}/edit")]
        public IActionResult EditAssignee([FromRoute] long id)
        {
            Assignee selectedAssignee = AssigneeService.FindById(id);
            AssigneeViewModel model = new AssigneeViewModel();
            model.Assignee = selectedAssignee;
            return View("EditAssignee", model);
        }
        [HttpPost("{id=id}/edit")]
        public IActionResult EditAssignee([FromRoute] long id, string name, string email)
        {
            AssigneeService.EditAssignee(id, name, email);
            return RedirectToAction("List");
        }
        [HttpGet("listAssigned")]
        public IActionResult ListAssignedTodos([FromQuery] long Id)
        {
            TodoViewModel model = new TodoViewModel();
            model.Todos = AssigneeService.FindById(Id).Todos;
            return View("Views/Todo/List.cshtml", model);
        }
    }
}
