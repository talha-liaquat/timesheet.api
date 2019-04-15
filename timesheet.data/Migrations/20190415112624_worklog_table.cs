using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.data.Migrations
{
    [DbContext(typeof(TimesheetDb))]
    [Migration("20190415112624_worklog_table")]
    public class worklog_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worklogs",
                columns: table => new
                {
                    //Primary Key
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),

                    //Foreign Keys
                    EmployeeId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),

                    //Columns
                    Date = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKLOGS", x => x.Id);
                    table.ForeignKey("FK_WORKLOGS_EMPLOYEES_EMPLOYEE_ID", x => x.EmployeeId, "Employees", "Id", "dbo");
                    table.ForeignKey("FK_WORKLOGS_TASKS_TASK_ID", x => x.TaskId, "Tasks", "Id", "dbo");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Worklogs");
        }
    }
}
