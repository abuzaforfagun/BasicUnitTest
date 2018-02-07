using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BasicUnitTest.Migrations.EmployeeDb
{
    public partial class SeedEmployeeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Employees (Name) values ('emp 1');");
            migrationBuilder.Sql("Insert Into Employees (Name) values ('emp 2');");
            migrationBuilder.Sql("Insert Into Employees (Name) values ('emp 3');");
            migrationBuilder.Sql("Insert Into Employees (Name) values ('emp 4');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from employees");
        }
    }
}
