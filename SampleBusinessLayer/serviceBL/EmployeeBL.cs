///-----------------------------------------------------------------
///   class:       EmployeeBL
///   Description: Business Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMBusinessLayer.serviceBL
{
    using EMBusinessLayer.IinterfaceBL;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class Employee of business layer
    /// </summary>
    public class EmployeeBL:IEmployeeBL
    {
        /// <summary>
        /// varibal of interface rl type
        /// </summary>
        private readonly IEmployeeRL employeeRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusiness"/> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public EmployeeBL(IEmployeeRL employeeRepository)
        {
            this.employeeRL = employeeRepository;
        }

        /// <summary>
        /// get all employee
        /// </summary>
        /// <returns>list of employee</returns>
        public IList<EmployeeModel> GetAllEmployee()
        {
            try
            {
                ////this variable stores the response from the GetAllEmployee method
                var response = this.employeeRL.GetAllEmployee();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Adds the employee. Task allows the asynchronous operations
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the newly added employee</returns>
        /// <exception cref="Exception">throws the exception</exception>
        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                ////this variable stores the response from employee repository of the AddEmployee
                return this.employeeRL.AddEmployee(employeeModel);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        
        /// <summary>
        /// update employee data 
        /// </summary>
        /// <param name="EmployeeID">id</param>
        /// <param name="employeeModel">employee data</param>
        /// <returns>status</returns>
        public EmployeeModel UpdateEmployeeByID(int EmployeeID, EmployeeModel employeeModel)
        {
            try
            {
                var result = employeeRL.UpdateEmployeeByID(EmployeeID, employeeModel);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        ///  API for get specific emplyee details
        /// </summary>
        /// <param name="ID"> get specific Entry</param>
        /// <returns></returns>
        public EmployeeModel GetEmployeeByID(int EmployeeID)
        {
            try
            {
                return  employeeRL.GetEmployeeByID(EmployeeID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// delete employee detail by id
        /// </summary>
        /// <param name="EmployeeID">id of employee</param>
        /// <returns>employee id</returns>
        public EmployeeModel DeleteEmployeeByID(int employeeID)
        {
            try
            {
                ////this variable stores the response from employee repository of the AddEmployee
                return employeeRL.DeleteEmployeeByID(employeeID);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
