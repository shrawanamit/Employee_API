///-----------------------------------------------------------------
///   class:       UserRL
///   Description: Repository Layer class for user and ado .net code connection with data base
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMSampleRepositoryLayer.serviceRepository
{
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// implimenting interface
    /// </summary>
    public class UserRL:IUserRL
    {
        /// <summary>
        /// data base connection veriable
        /// </summary>
         private SqlConnection sqlConnection;

        public UserRL()
        {
            var configuration = this.GetConfiguration();
            this.sqlConnection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }
        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel">employee data</param>
        /// <returns>boolean value </returns>
        public UserModel AddUser(UserModel userModel)
        { 
            try
            {
                UserModel userModeData = new UserModel();
                //for store procedure and connection to database
                SqlCommand sqlCommand = new SqlCommand("spUserRegistrationData", sqlConnection);
                ////take the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", userModel.LastName);
                sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
                sqlCommand.Parameters.AddWithValue("@MobNo", userModel.MobNo);
                sqlCommand.Parameters.AddWithValue("@Email", userModel.Email);
                sqlCommand.Parameters.AddWithValue("@Password", userModel.Password);
                sqlCommand.Parameters.AddWithValue("@Address", userModel.Address);
                sqlCommand.Parameters.AddWithValue("@Department", userModel.Department);
                sqlCommand.Parameters.AddWithValue("@VisitedDate", DateTime.Now);

                sqlConnection.Open();
                SqlDataReader Response = sqlCommand.ExecuteReader();
                return GetUserData(userModeData, Response);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// login User
        /// </summary>
        /// <param name="data">data of login type</param>
        /// <returns>status</returns>
        public UserModel UserLogin(UserLogin userLogin)
        {
            try
            {
                UserModel userModel = new UserModel();
                SqlCommand sqlCommand = new SqlCommand("spUserLogin", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@UserName", userLogin.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", userLogin.Password);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                return GetUserData(userModel, reader);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private UserModel GetUserData(UserModel userDetails, SqlDataReader response)
        {
            if (response.HasRows)
            {
                while (response.Read())
                {
                    userDetails.userId = Convert.ToInt32(response["userId"]);
                    userDetails.FirstName = response["FirstName"].ToString();
                    userDetails.LastName = response["LastName"].ToString();
                    userDetails.UserName = response["UserName"].ToString();
                    userDetails.MobNo = response["MobNo"].ToString();
                    userDetails.Email = response["Email"].ToString();
                    userDetails.Address = response["Address"].ToString();
                    userDetails.Department = response["Department"].ToString();
                    userDetails.VisitedDate = response["VisitedDate"].ToString();
                }
                this.sqlConnection.Close();
                return userDetails;
            }
            return null;
        }

        /// <summary>
        /// configuration with database
        /// </summary>
        /// <returns>return builder</returns>
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
