using EMBusinessLayer.IinterfaceBL;
using EMSampleCommanLayer.Models;
using EMSampleRepositoryLayer.interfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMBusinessLayer.serviceBL
{
    public class UserBL:IUserBl
    {
        /// <summary>
        /// varibal of interface Rl type
        /// </summary>
        private readonly IUserRL userRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusiness"/> class.
        /// </summary>
        /// <param name="employeeRepository"> userRepository.</param>
        public UserBL(IUserRL userRepository)
        {
            this.userRL = userRepository;
        }


        /// <summary>
        /// Adds the employee. Task allows the asynchronous operations
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the newly added employee</returns>
        /// <exception cref="Exception">throws the exception</exception>
        public bool AddUser(UserModel userModel)
        {
            try
            {
                ////check employeeModel not null
                if (userModel != null)
                {
                    ////this variable stores the response from employee repository of the AddEmployee
                    var response = this.userRL.AddUser(userModel);
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
        /// login Employee
        /// </summary>
        /// <param name="data">data of login type</param>
        /// <returns>status</returns>
        public int LoginUser(UserLogin userLogin)
        {
            try
            {
                var response = this.userRL.UserLogin(userLogin);
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
