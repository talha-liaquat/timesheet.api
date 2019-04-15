using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.contracts.DataContracts
{
    public class WorklogDTO
    {
        public string TaskName { get; set; }
        public decimal Sunday { get; set; }
        public decimal Monday { get; set; }
        public decimal Tuesday { get; set; }
        public decimal Wednesday { get; set; }
        public decimal Thursday { get; set; }
        public decimal Friday { get; set; }
        public decimal Saturday { get; set; }
    }
}
