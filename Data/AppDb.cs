using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Management_System.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasOne(x => x.contract).WithOne(x => x.employee);
            modelBuilder.Entity<Employee>().HasMany(x => x.projects).WithOne(x => x.employee);
            modelBuilder.Entity<Project>().HasMany(x => x.employees).WithOne(x => x.project);
            modelBuilder.Entity<Employee>().HasOne(x => x.department).WithMany(x => x.employees);
            modelBuilder.Entity<EmployeeProject>().HasKey(x => new { x.EmployeeId, x.ProjectId });

            
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Location = "Giza", Name = "Backend" },
                new Department { Id = 2, Location = "Cairo", Name = "Frontend" },
                new Department { Id = 3, Location = "Alexandria", Name = "HR" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Adel", Email = "adel@gmail.com", Phone = "01282768929", DepartmentId = 1 },
                new Employee { Id = 2, Name = "Sara", Email = "sara@gmail.com", Phone = "01125678945", DepartmentId = 2 },
                new Employee { Id = 3, Name = "Omar", Email = "omar@gmail.com", Phone = "01054789632", DepartmentId = 1 },
                new Employee { Id = 4, Name = "Nour", Email = "nour@gmail.com", Phone = "01587456321", DepartmentId = 3 }
            );

            modelBuilder.Entity<Contract>().HasData(
                new Contract { Id = 1, ContractNumber = "1001", EmployeeId = 1, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 10, 1), Salary = 15000 },
                new Contract { Id = 2, ContractNumber = "1002", EmployeeId = 2, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2025, 3, 1), Salary = 12000 },
                new Contract { Id = 3, ContractNumber = "1003", EmployeeId = 3, StartDate = new DateTime(2024, 6, 15), EndDate = new DateTime(2026, 6, 15), Salary = 18000 },
                new Contract { Id = 4, ContractNumber = "1004", EmployeeId = 4, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2026, 2, 1), Salary = 10000 }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Budget = 5000, StartDate = new DateTime(2024, 1, 1), EndTime = new DateTime(2025, 1, 1), ProjectName = "ManagementSystem" },
                new Project { Id = 2, Budget = 15000, StartDate = new DateTime(2024, 5, 1), EndTime = new DateTime(2025, 5, 1), ProjectName = "ECommercePlatform" },
                new Project { Id = 3, Budget = 8000, StartDate = new DateTime(2024, 9, 1), EndTime = null, ProjectName = "MobileApp" }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 1, ProjectId = 2 },
                new EmployeeProject { EmployeeId = 2, ProjectId = 2 },
                new EmployeeProject { EmployeeId = 3, ProjectId = 1 },
                new EmployeeProject { EmployeeId = 3, ProjectId = 3 },
                new EmployeeProject { EmployeeId = 4, ProjectId = 3 }
            );

        }

        public DbSet<Employee> employee { get; set; }
        public DbSet<Contract> contract { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<EmployeeProject> employeeProject { get; set; }
    }
}