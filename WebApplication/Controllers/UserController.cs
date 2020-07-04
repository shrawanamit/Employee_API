///-----------------------------------------------------------------
///   class:       UserController
///   Description: Controller Layer class for User management
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------
namespace EmployeeManagement.Controllers
{
    using System;
    using EMBusinessLayer.IinterfaceBL;
    using EMSampleCommanLayer.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The employee business
        /// </summary>
        private readonly IUserBl userBL;
        private IConfiguration config;


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeBusiness">The employee business.</param>
        public UserController(IUserBl userBl, IConfiguration config)
        {
            this.userBL = userBl;
            this.config = config;
        }

        /// <summary>
        /// insert the employee data
        /// </summary>
        /// <param name="employeeModel">employee data</param>
        /// <returns>status</returns>
        [HttpPost]
        [Route("")]
        public ActionResult AddUser(UserModel UserModel)
        {

            try
            {
                ///passing data
                var response = this.userBL.AddUser(UserModel);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees Registration Successfull";
                    return this.Ok(new { status, Message, Data = response });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees Registration Failed";
                    return this.BadRequest(new { status, Message, Data = UserModel });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return this.BadRequest(new { status, message = e.Message });
            }
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="userLogin">Login data</param>
        /// <returns>status</returns>
        [HttpPost]
        [Route("userLogin")]
        public ActionResult LoginUser([FromBody]UserLogin userLogin)
        {
            try
            {
                /// passing data for login
                var response = this.userBL.LoginUser(userLogin);
                if (!response.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees login sucessfull";
                    return this.Ok(new { status, Message, Data= response });
                }
                else
                {
                    bool status = false;
                    var Message = "UserName and PassWORD Must be correct";
                    return this.BadRequest(new { status, Message, Data = userLogin });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return this.BadRequest(new { status, message = e.Message });
            }
        }
    }
}
