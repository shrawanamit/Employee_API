﻿///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: Repository Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using EMBusinessLayer.IinterfaceBL;
using EMSampleCommanLayer;
using EMSampleCommanLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    { 

        /// <summary>
        /// The employee business
        /// </summary>
        private readonly IEmployeeBL employeeBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeBusiness">The employee business.</param>
        public EmployeesController(IEmployeeBL employeeBusiness)
        {
            this.employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// get employee data
        /// </summary>
        /// <returns>status</returns>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> GetAllEmployees()
        {
            try
            {
                var data = this.employeeBusiness.GetAllEmployee();
                if(!data.Equals(null))
                {
                    bool status = true;
                    string message = "All data of Employees found ";
                    return this.Ok(new { status, message, data });
                }

                else 
                {
                    bool status = false;
                    string message = "All data of Employees not found ";
                    return this.BadRequest(new { status, message, data });
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

        /// <summary>
        /// insert data of employee
        /// </summary>
        /// <param name="employeeModel">data to insert</param>
        /// <returns>status</returns>
        [HttpPost]
        [Route("register")]
        public  ActionResult AddEmployee([FromBody] EmployeeModel employeeModel)
        {

            try
            {
                 bool data = this.employeeBusiness.AddEmployee(employeeModel);

                if (!data.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees Registration Successfull";
                    return this.Ok(new { status, Message, data });
                }
                else                                   
                {
                    bool status = false;
                    var Message = "Employees Registration Failed";
                    return this.BadRequest(new { status, Message, data= employeeModel });
                }
            }
            catch(Exception e)
            {
                return this.BadRequest(new { message = e.Message });
            }
        }

        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="EmployeeID">id</param>
        /// <param name="employeeModel">All data to update</param>
        /// <returns>status</returns>
        [HttpPut]
        [Route("{EmployeeID}")]
        public ActionResult PutEmployee([FromRoute] int EmployeeID, [FromBody] EmployeeModel employeeModel)
        {
            try 
            {
                var data = this.employeeBusiness.UpdateEmployee( EmployeeID,  employeeModel);
                if (!data.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees data updated by EmployeeID";
                    return this.Ok(new { status, Message, data });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees data updated by EmployeeID fail";
                    return this.BadRequest(new { status, Message, data = employeeModel });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        /// <summary>
        /// delete employe record
        /// </summary>
        /// <param name="employeeId">pass id</param>
        /// <returns>status</returns>
        [HttpDelete]
        [Route("{employeeId}")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                var data = this.employeeBusiness.DeleteEmployee(employeeId);
                if (!data.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees data deleted by EmployeeID";
                    return this.Ok(new { status, Message, data });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees data deleated by EmployeeID fail";
                    return this.BadRequest(new { status, Message, data = employeeId });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// get specific recod by id
        /// </summary>
        /// <param name="employeeID">id</param>
        /// <returns>status</returns>
        [HttpGet]
        [Route("{employeeID}")]
        public ActionResult GetSpesificEmployee(int employeeID)
        {
            try
            {
                var data = this.employeeBusiness.GetSpecificEmployee(employeeID);
                if (!data.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees specific data by EmployeeID";
                    return this.Ok(new { status, Message, data });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees specific by data EmployeeID fail";
                    return this.BadRequest(new { status, Message, data = employeeID });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// method for login user 
        /// </summary>
        /// <param name="login">login type data</param>
        /// <returns>status</returns>
        [HttpPost]
        [Route("login")]
        public ActionResult LoginEmployee([FromBody]Login login)
        {
            try
            {
                var data = this.employeeBusiness.LoginEmployee(login);
                if (!data.Equals(null))
                {
                    bool status = true;
                    var Message = "Employees login sucessfull";
                    return this.Ok(new { status, Message, data });
                }
                else
                {
                    bool status = false;
                    var Message = "Employees login unsucessfull";
                    return this.BadRequest(new { status, Message, data = login });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}