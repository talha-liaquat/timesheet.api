using System;
using System.Linq;
using timesheet.data;
using timesheet.model;
using timesheet.contracts.Services;
using timesheet.contracts.DataContracts;
using System.Collections.Generic;

namespace timesheet.business
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private IWorklogService worklogService;

        public EmployeeService(TimesheetDb context, IWorklogService worklogService) :base(context)
        {
            this.worklogService = worklogService;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return Context.Employees;
        }

        IList<EmployeeDTO> IEmployeeService.GetEmployees()
        {
            var weekDetails = GetWeekDetails(DateTime.Today);

            var employees = (from emp in Context.Employees
                             select new EmployeeDTO
                             {
                                 Id = emp.Id,
                                 Code = emp.Code,
                                 Name = emp.Name,
                             }).ToList();

            foreach(var emp in employees)
            {
                emp.WeeklyEffort = GetTotalWeeklyEffort(emp.Id, weekDetails.startDate, weekDetails.endDate);
                emp.AvgWeeklyEffort = GetAvgWeeklyEffort(emp.Id, weekDetails.endDate);
            }
            return employees;
        }

        private (DateTime startDate, DateTime endDate) GetWeekDetails(DateTime date)
        {
            var startDate = date.AddDays(DayOfWeek.Sunday - date.DayOfWeek);
            var endDate = startDate.AddDays(6);
            return (startDate, endDate);
        }

        private decimal? GetTotalWeeklyEffort(int empId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var worklogs = worklogService.GetWorklogs(empId, startDate, endDate);
                return decimal.Round(worklogs.Sum(t => t.Hours) / 7, 2, MidpointRounding.AwayFromZero);
            }
            catch(Exception e)
            {
                System.IO.File.WriteAllText("D:\\2.rxr", e.ToString());
                throw;
            }
        }

        private decimal? GetAvgWeeklyEffort(int empId, DateTime endDate)
        {
            var worklogs = worklogService.GetWorklogs(empId, null, endDate);
            return decimal.Round(worklogs.Sum(t => t.Hours) / (decimal)(endDate - new DateTime(endDate.Year, 1, 1)).TotalDays, 2, MidpointRounding.AwayFromZero);
        }
    }
}