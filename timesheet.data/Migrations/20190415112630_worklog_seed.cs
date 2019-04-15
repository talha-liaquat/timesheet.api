using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.data.Migrations
{
    public partial class worklog_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (1, 2, '2019-04-15', 2.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (1, 3, '2019-04-15', 2.50);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (1, 5, '2019-04-15', 3.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (2, 1, '2019-04-16', 8.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (2, 1, '2019-04-17', 8.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (2, 1, '2019-04-18', 8.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (6, 4, '2019-04-14', 10.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (8, 4, '2019-04-17', 8.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (8, 2, '2019-04-17', 2.00);
            INSERT INTO [Worklogs] ([EmployeeId], [TaskId], [Date], [Hours]) VALUES (8, 5, '2019-04-14', 3.00);
                GO  ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
