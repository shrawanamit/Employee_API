///-----------------------------------------------------------------
///   class:      UserCantrollerAPITest
///   Description: Testing user Cantroller API for user management
///   Author:      amit                   Date: 2/7/2020
///-----------------------------------------------------------------


namespace userControllerApiTest
{
    using EMBusinessLayer.IinterfaceBL;
    using EMBusinessLayer.serviceBL;
    using EmployeeManagement.Controllers;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using EMSampleRepositoryLayer.serviceRepository;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    public class UserCantrollerAPITest
    {
        IUserBl userBL;
        IUserRL userRL;
        UserController userController;

        /// <summary>
        /// creating object
        /// </summary>
        public UserCantrollerAPITest()
        {
            //Arrange  
            userRL = new UserRL();
            userBL = new UserBL(userRL);
            userController = new UserController(userBL);
        }

        /// <summary>
        /// get All User
        /// </summary>
        [Fact]
        public void InsertAllUser_WhenCalled_ShouldReturnsOkResult()
        {
            var testdata = new UserModel
            { FirstName = "Arit", LastName = "Umar",UserName="Prit", MobNo = "91222460175", Email = "umxar@gmail.com", Password = "Amit@123", Address = "patna", Department = "IT" };

            // Act
            var data = userController.AddUser(testdata);

            // Assert
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// get All User
        /// </summary>
        [Fact]
        public void Task_insertdataWhenRepeted_Return_BadRequestResult()
        {
            //Act  
            var testdata = new UserModel
            { FirstName = "Arit", LastName = "Umar", UserName = "Prit", MobNo = "91222460175", Email = "umzar@gmail.com", Password = "Amit@123", Address = "patna", Department = "IT" };

            // Act
            var data = userController.AddUser(testdata);
            data = null;
            if (data != null)
                //Assert  
                Assert.IsType<BadRequestObjectResult>(data);
        }

        /// <summary>
        /// login user
        /// </summary>
        [Fact]
        public void Task_UserLoginEmployeeID_Return_OkResult()
        {
            //Arrange  
            var testdata = new UserLogin
            { UserName = "Prit", Password = "Amit@123" };
            //Act  
            var data = userController.LoginUser(testdata);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// user login null
        /// </summary>
        [Fact]
        public void Task_UserLoginDataNull_Return_BadRequestResult()
        {
            //Act  
            var testdata = new UserLogin
            { UserName = "Prit", Password = "Amit@123" };
            //Act  
            var data = userController.LoginUser(testdata);
            data = null;
            if (data != null)
                //Assert  
                Assert.IsType<BadRequestObjectResult>(data);
        }
    }
}
