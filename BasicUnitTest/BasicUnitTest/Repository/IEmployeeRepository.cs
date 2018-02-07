using System.Collections.Generic;
using BasicUnitTest.Core;

namespace BasicUnitTest.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeeList { get; set; }

        void Delete(int id);
        List<Employee> GetAll();
    }
}