///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: cantrller Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------
namespace EmployeeManagement.Controllers
{
    using System;
    using EMBusinessLayer.IinterfaceBL;
    using EMSampleCommanLayer.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The employee business
        /// </summary>
        private readonly IUserBl userBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeBusiness">The employee business.</param>
        public UserController(IUserBl userBl)
        {
            this.userBL = userBl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public ActionResult AddEmployee(UserModel UserModel)
        {

            try
            {
                ///passing data
                var response = this.userBL.AddUser(UserModel);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees Registration Successfull";
                    return this.Ok(new { status, Message, response });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees Registration Failed";
                    return this.BadRequest(new { status, Message, response = UserModel });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("userLogin")]
        public ActionResult LoginEmployee([FromBody]UserLogin userLogin)
        {
            try
            {
                /// passing data for login
                var response = this.userBL.LoginUser(userLogin);
                if (!response.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees login sucessfull";
                    return this.Ok(new { status, Message, response });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees login unsucessfull";
                    return this.BadRequest(new { status, Message, response = userLogin });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
