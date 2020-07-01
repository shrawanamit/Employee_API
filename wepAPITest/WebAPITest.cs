using EMBusinessLayer.IinterfaceBL;
using EMBusinessLayer.serviceBL;
using EMSampleRepositoryLayer.interfaceRepository;
using EMSampleRepositoryLayer.serviceRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication.Controllers;
using Xunit;

namespace wepAPITest
{
    public class WebAPITest
    {
        EmployeesController employeesController;
        IEmployeeBL employeeBL;
        IEmployeeRL employeeRL;
        

        public WebAPITest()
        {
            employeeRL = new EmployeeRL();
            employeeBL = new EmployeeBL(employeeRL);
            employeesController = new EmployeesController(employeeBL);
        }

        [Fact]
        public void GetAllEmployees_WhenCalled_ShouldReturnsOkResult()
        {
            // Act
            var okResult = employeesController.GetAllEmployees();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
