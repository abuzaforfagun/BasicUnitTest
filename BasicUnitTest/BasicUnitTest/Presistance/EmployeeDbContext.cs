using BasicUnitTest.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Presistance
{
    class EmployeeDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\;Database=EmployeeDb;Trusted_Connection=True;");
        }
    }
}
