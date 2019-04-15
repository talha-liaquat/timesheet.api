using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.contracts.DataContracts
{
    public class WorklogRequest
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
    }
}
