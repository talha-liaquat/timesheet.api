using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.contracts.DataContracts
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal? WeeklyEffort { get; set; }

        public decimal? AvgWeeklyEffort { get; set; }
    }
}
