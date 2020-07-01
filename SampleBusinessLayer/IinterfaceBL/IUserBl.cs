using EMSampleCommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMBusinessLayer.IinterfaceBL
{
    public interface IUserBl
    {
        /// <summary>
        /// Adds the User
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the added data</returns>
        bool AddUser(UserModel userModel);

        /// <summary>
        /// login User
        /// </summary>
        /// <param name="data">login data</param>
        /// <returns>status</returns>
        int LoginUser(UserLogin userlogin);
    }
}
