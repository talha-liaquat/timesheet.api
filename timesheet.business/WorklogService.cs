using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using timesheet.contracts.DataContracts;
using timesheet.contracts.Services;
using timesheet.data;

namespace timesheet.business
{
    public class WorklogService : BaseService, IWorklogService
    {
        public WorklogService(TimesheetDb context) : base(context) { }

        public void AddWorklog(IList<WorklogRequest> worklogs)
        {
            var worklogEntites =
                from w in worklogs
                select new model.Worklog
                {
                    EmployeeId = w.EmployeeId,
                    TaskId = w.TaskId,
                    Date = w.Date,
                    Hours = w.Hours
                };

            Context.Worklogs.AddRange(worklogEntites);
            Context.SaveChanges();
        }

        public IList<WorklogDTO> GetWorklog(int employeeId, int week)
        {
            var stats =
                   (from log in Context.Worklogs
                    where log.EmployeeId == employeeId && log.Week == week
                    group log by new { log.Task.Name, log.Date.Date } into grp
                    select new
                    {
                        TaskName = grp.Key.Name,
                        Day = grp.Key.Date.DayOfWeek,
                        Hours = grp.Select(x => x.Hours).Sum()
                    }).ToList();

            var tasks = stats.Select(x => x.TaskName).Distinct();

            return tasks.Select(x => new WorklogDTO
            {
                TaskName = x,
                Sunday = stats.Where(c => c.Day == DayOfWeek.Sunday && c.TaskName == x).Sum(s => s.Hours),
                Monday = stats.Where(c => c.Day == DayOfWeek.Monday && c.TaskName == x).Sum(s => s.Hours),
                Tuesday = stats.Where(c => c.Day == DayOfWeek.Tuesday && c.TaskName == x).Sum(s => s.Hours),
                Wednesday = stats.Where(c => c.Day == DayOfWeek.Wednesday && c.TaskName == x).Sum(s => s.Hours),
                Thursday = stats.Where(c => c.Day == DayOfWeek.Thursday && c.TaskName == x).Sum(s => s.Hours),
                Friday = stats.Where(c => c.Day == DayOfWeek.Friday && c.TaskName == x).Sum(s => s.Hours),
                Saturday = stats.Where(c => c.Day == DayOfWeek.Saturday && c.TaskName == x).Sum(s => s.Hours),
            }).ToList();
        }

        public IList<WorklogDetail> GetWorklogs(int employeeId, DateTime? startDate, DateTime? endDate)
        {
            return this.Context.Worklogs
                .Where(w => w.EmployeeId == employeeId && (startDate == null || w.Date >= startDate) && w.Date <= endDate)
                ?.Select(w => new WorklogDetail { EmployeeId = w.EmployeeId, Date = w.Date, Hours = w.Hours })?.ToList();
        }
    }
}