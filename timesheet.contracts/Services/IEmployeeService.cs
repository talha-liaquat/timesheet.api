﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.contracts.DataContracts;

namespace timesheet.contracts.Services
{
    public interface IEmployeeService
    {
        IList<EmployeeDTO> GetEmployees();
    }
}
