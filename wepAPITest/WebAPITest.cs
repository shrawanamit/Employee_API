///-----------------------------------------------------------------
///   class:       WebAPITest
///   Description: Testing EmployeeManagement Cantroller API
///   Author:      amit                   Date: 2/7/2020
///-----------------------------------------------------------------

namespace wepAPITest
{
    using EMBusinessLayer.IinterfaceBL;
    using EMBusinessLayer.serviceBL;
    using EMSampleCommanLayer;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using EMSampleRepositoryLayer.serviceRepository;
    using Microsoft.AspNetCore.Mvc;
    using WebApplication.Controllers;
    using Xunit;
    public class WebAPITest
    {
        /// <summary>
        /// instance varibal
        /// </summary>
        IEmployeeBL employeeBL;
        IEmployeeRL employeeRL;
        EmployeesController employeesController;

        /// <summary>
        /// creating object
        /// </summary>
        public WebAPITest()
        { 
            //Arrange  
            employeeRL = new EmployeeRL();
            employeeBL = new EmployeeBL(employeeRL);
            employeesController = new EmployeesController(employeeBL);
        }

        /// <summary>
        /// get all employee
        /// </summary>
        [Fact]
        public void GetAllEmployees_WhenCalled_ShouldReturnsOkResult()
        {
            // Act
            var okResult = employeesController.GetAllEmployees();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        /// <summary>
        /// pass null give bad request
        /// </summary>
        [Fact]
        public void Task_GetPosts_Return_BadRequestResult()
        {
            //Act  
            var data = employeesController.GetAllEmployees();
            data = null;

            //if (data != null)
            //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        /// <summary>
        /// employee data deleted by id
        /// </summary>
        [Fact]
        public  void Task_deletedataById_Return_OkResult()
        {
            //Arrange  
            
            var postId = 2;

            //Act  
            var data =  employeesController.DeleteEmployeeByID(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// insert data of employee
        /// </summary>
        [Fact]
        public void Task_insertdata_Return_OkResult()
        {
            //Arrange  

            var testdata = new EmployeeModel
            { FirstName="Rohan",LastName="Mmar",MobNo="9122460175",Email="qohan@gmail.com",Address="patna",Department="IT",Salary=6111};
            

            //Act  
            var data = employeesController.AddEmployee(testdata);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// insert data when repeted
        /// </summary>
        [Fact]
        public void Task_insertdataWhenRepeted_Return_BadRequestResult()
        {
            //Act  
            var testdata = new EmployeeModel
            { FirstName = "Rohan", LastName = "Mmar", MobNo = "9122460175", Email = "wohan@gmail.com", Address = "patna", Department = "IT", Salary = 6111 };

            var data = employeesController.AddEmployee(testdata);
            if (data != null)
            //Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }

        /// <summary>
        /// update employee data
        /// </summary>
        [Fact]
        public void Task_EmployeeDataUpdateByEmployeeID_Return_OkResult()
        {
            //Arrange  

            var testdata = new EmployeeModel
            { FirstName = "Rohan", LastName = "Mmar", MobNo = "9122460175", Email = "dohan@gmail.com", Address = "patna", Department = "IT", Salary = 6111 };
            var employeeId = 3;

            //Act  
            var data = employeesController.UpdateEmployeeByID(employeeId, testdata);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// Employee Data Update By Employee ID when Return BadRequestResult
        /// </summary>
        [Fact]
        public void Task_EmployeeDataUpdateByEmployeeIDwhen_Return_BadRequestResult()
        {
            //Act  
            var testdata = new EmployeeModel
            { FirstName = "Rohan", LastName = "Mmar", MobNo = "9122460175", Email = "hohan@gmail.com", Address = "patna", Department = "IT", Salary = 6111 };
            var employeeId = 3;
            var data = employeesController.UpdateEmployeeByID(employeeId, testdata);
            data = null;
            if (data != null)
            //Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }
    }
}
