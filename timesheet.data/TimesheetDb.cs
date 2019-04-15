using Microsoft.EntityFrameworkCore;
using System;
using timesheet.model;

namespace timesheet.data
{
    public class TimesheetDb : DbContext
    {
        public TimesheetDb(DbContextOptions<TimesheetDb> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Worklog> Worklogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worklog>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.Worklogs)
                .HasForeignKey(x => x.EmployeeId)
                .IsRequired(true)
                .HasConstraintName("FK_WORKLOGS_EMPLOYEES_EMPLOYEE_ID");

            modelBuilder.Entity<Worklog>()
                .HasOne(x => x.Task)
                .WithMany(x => x.Worklogs)
                .HasForeignKey(x => x.TaskId)
                .IsRequired(true)
                .HasConstraintName("FK_WORKLOGS_TASKS_TASK_ID");
        }
    }
}