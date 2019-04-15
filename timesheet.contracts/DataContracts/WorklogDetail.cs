using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.contracts.DataContracts
{
    public class WorklogDetail
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
    }
}
