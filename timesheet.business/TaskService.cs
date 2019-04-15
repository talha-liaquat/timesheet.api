using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.contracts.DataContracts;
using timesheet.contracts.Services;
using timesheet.data;

namespace timesheet.business
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(TimesheetDb context) : base(context) { }

        public IQueryable<TaskDTO> GetTasks()
        {
            return from task in Context.Tasks
                   select new TaskDTO
                   {
                       Id = task.Id,
                       Name = task.Name
                   };
        }
    }
}
