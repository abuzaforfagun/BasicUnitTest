using BasicUnitTest.Core;
using BasicUnitTest.Repository;
using BasicUnitTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Tests
{
    [TestFixture]
    class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> employeeRepository;
        private EmployeeService employeeService;

        [SetUp]

        public void Setup()
        {
            employeeRepository = new Mock<IEmployeeRepository>();
            employeeService = new EmployeeService(employeeRepository.Object);

        }
        [Test]
        public void DeleteEmployee_WhenCalled_EmployeeDeleted()
        {
            employeeService.DeleteEmployee(1);
            employeeRepository.Verify(er => er.Delete(1));
        }
    }
}
