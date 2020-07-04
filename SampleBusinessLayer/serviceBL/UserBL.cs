///-----------------------------------------------------------------
///   class:       UserBL
///   Description: Business Layer class for User
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMBusinessLayer.serviceBL
{
    using EMBusinessLayer.IinterfaceBL;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using System;
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
        public UserModel AddUser(UserModel userModel)
        {
            try
            {
                    return  this.userRL.AddUser(userModel);
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
        public UserModel LoginUser(UserLogin userLogin)
        {
            try
            {
               return this.userRL.UserLogin(userLogin);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
