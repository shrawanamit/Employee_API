///-----------------------------------------------------------------
///   interface:      IUserRL
///   Description: Repositery Layer interface for user
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------
namespace EMSampleRepositoryLayer.interfaceRepository
{
    using EMSampleCommanLayer.Models;
    public interface IUserRL
    {
        /// <summary>
        /// Adds the user
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns>returns the added data</returns>
        bool AddUser(UserModel userModel);

        /// <summary>
        /// login user
        /// </summary>
        /// <param name="data">login data</param>
        /// <returns>status</returns>
        int UserLogin(UserLogin data);
    }
}
