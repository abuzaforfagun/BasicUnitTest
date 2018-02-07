using BasicUnitTest.Core;
using BasicUnitTest.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeeList;
        private EmployeeDbContext employeeDbContext;
        private UnitOfWork unitOfWork;

        public List<Employee> EmployeeList
        {
            get { return this.employeeList; }
            set { this.employeeList = value; }
        }

        public EmployeeRepository()
        {
            employeeList = new List<Employee>();
            employeeDbContext = new EmployeeDbContext();
            unitOfWork = new UnitOfWork(employeeDbContext);
        }


        public List<Employee> GetAll()
        {
            this.EmployeeList = employeeDbContext.Employees.ToList();
            return EmployeeList;
        }

        public void Delete(int id)
        {
            var emp = this.employeeList.SingleOrDefault(e => e.Id == id);
            this.EmployeeList.Remove(emp);
            employeeDbContext.Employees.Remove(emp);
            unitOfWork.Done();
        }
    }
}
