using System;
using System.Collections.Generic;
using System.Text;
using timesheet.data;

namespace timesheet.business
{
    public abstract class BaseService
    {
        protected TimesheetDb Context { get; }

        protected BaseService(TimesheetDb context)
        {
            Context = context;
        }
    }
}
