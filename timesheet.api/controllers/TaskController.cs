using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using timesheet.contracts.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timesheet.api.controllers
{
    [Route("api/v1/task")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var items = this.taskService.GetTasks();
            return new ObjectResult(items);
        }
    }
}
