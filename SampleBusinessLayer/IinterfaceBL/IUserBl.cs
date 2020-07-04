///-----------------------------------------------------------------
///   class:       IUserBl
///   Description: interface class for user business Layer
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMBusinessLayer.IinterfaceBL
{
    using EMSampleCommanLayer.Models;
    public interface IUserBl
    {
        /// <summary>
        /// Adds the User
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the added data</returns>
        UserModel AddUser(UserModel userModel);

        /// <summary>
        /// login User
        /// </summary>
        /// <param name="data">login data</param>
        /// <returns>status</returns>
        UserModel LoginUser(UserLogin userLogin);
    }
}
