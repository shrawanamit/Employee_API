///-----------------------------------------------------------------
///   class:       EmployeeBL
///   Description: Business Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMBusinessLayer.serviceBL
{
    using EMBusinessLayer.IinterfaceBL;
    using EMSampleCommanLayer;
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
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                ////check employeeModel not null
                if (employeeModel != null)
                {
                    ////this variable stores the response from employee repository of the AddEmployee
                    var response = this.employeeRL.AddEmployee(employeeModel);
                    ////check response is true
                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
        public int UpdateEmployee(int EmployeeID, EmployeeModel employeeModel)
        {
            try
            {
                var result = employeeRL.UpdateEmployee(EmployeeID, employeeModel);
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
        public EmployeeModel GetSpecificEmployee(int EmployeeID)
        {
            try
            {
                return  employeeRL.GetSpecificEmployee(EmployeeID);
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
        public EmployeeID DeleteEmployee(int employeeID)
        {
            try
            {
                EmployeeID response = null;
                ////check employeeModel not null
                if (employeeID != 0)
                {
                    ////this variable stores the response from employee repository of the AddEmployee
                     response = this.employeeRL.DeleteEmployee(employeeID);
                    ////check response is true
                    return response;
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// login Employee
        /// </summary>
        /// <param name="data">data of login type</param>
        /// <returns>status</returns>
        public int LoginEmployee(Login login)
        {
            try
            {
                var response = this.employeeRL.EmployeeLogin(login);
                if (!response.Equals(0))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
