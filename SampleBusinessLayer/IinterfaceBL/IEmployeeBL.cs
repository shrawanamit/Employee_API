﻿///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: Repository Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

using EMSampleCommanLayer;
using EMSampleCommanLayer.Models;
using System.Collections.Generic;

namespace EMBusinessLayer.IinterfaceBL
{
    public interface IEmployeeBL
    {
        /// <summary>
        /// get employee data method
        /// </summary>
        /// <returns>list</returns>
        IList<EmployeeModel> GetAllEmployee();

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the added data</returns>
        bool AddEmployee(EmployeeModel employeeModel);

        /// <summary>
        /// update Employee data
        /// </summary>
        /// <param name="EmployeeID">id of emlpoyee</param>
        /// <param name="employeeModel">all data</param>
        /// <returns>id</returns>
        int UpdateEmployee(int EmployeeID, EmployeeModel employeeModel);

        /// <summary>
        /// deleate employee
        /// </summary>
        /// <param name="EmployeeID">id</param>
        /// <returns>id</returns>
        EmployeeID DeleteEmployee(int employeeID);

        /// <summary>
        ///  get specific employee
        /// </summary>
        /// <param name="EmployeeID">id</param>
        /// <returns>employeemodel</returns>
        EmployeeModel GetSpecificEmployee(int EmployeeID);

        /// <summary>
        /// login employee
        /// </summary>
        /// <param name="data">login data</param>
        /// <returns>status</returns>
        int LoginEmployee(Login login);

    }
}