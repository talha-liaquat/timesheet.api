using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using timesheet.contracts.DataContracts;
using timesheet.contracts.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timesheet.api.controllers
{
    [Route("api/v1/worklog")]
    [ApiController]
    public class WorklogController : ControllerBase
    {
        private readonly IWorklogService worklogService;
        public WorklogController(IWorklogService worklogService)
        {
            this.worklogService = worklogService;
        }

        [HttpGet("{employeeId}/{week}")]
        public IActionResult GetWorklog(int employeeId, int week)
        {
            var items = this.worklogService.GetWorklog(employeeId, week);
            return new ObjectResult(items);
        }

        [HttpPost("add")]
        public IActionResult AddWorklog([FromBody]List<WorklogRequest> worklogRequests)
        {
             this.worklogService.AddWorklog(worklogRequests);
                return new ObjectResult(true);
        }
    }
}
