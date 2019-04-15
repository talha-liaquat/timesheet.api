using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.contracts.DataContracts;

namespace timesheet.contracts.Services
{
    public interface IWorklogService
    {
        IList<WorklogDTO> GetWorklog(int employeeId, int week);
        void AddWorklog(IList<WorklogRequest> worklogs);
        IList<WorklogDetail> GetWorklogs(int employeeId, DateTime? startDate, DateTime? endDate);
    }
}
