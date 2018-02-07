using BasicUnitTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public ActionResult DeleteEmployee(int id)
        {
            employeeRepository.Delete(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }

        public class RedirectResult : ActionResult { }
        public class ActionResult { }

    }
}
