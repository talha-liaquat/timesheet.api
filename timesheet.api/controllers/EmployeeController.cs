﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;
using timesheet.contracts.Services;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var items = this.employeeService.GetEmployees();
            return new ObjectResult(items);
        }
    }
}