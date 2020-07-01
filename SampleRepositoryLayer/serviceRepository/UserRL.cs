using EMSampleCommanLayer.Models;
using EMSampleRepositoryLayer.interfaceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EMSampleRepositoryLayer.serviceRepository
{
    public class UserRL:IUserRL
    {
        /// <summary>
        /// data base connection veriable
        /// </summary>
        private static readonly string ConnectionVariable = "Data Source=DESKTOP-LSKIBA4;Initial Catalog=EmployeeDB;Integrated Security=True";

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel">employee data</param>
        /// <returns>boolean value </returns>
        public bool AddUser(UserModel userModel)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
            try
            {
                //for store procedure and connection to database
                SqlCommand sqlCommand = new SqlCommand("spUserRegistration", sqlConnection);
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
                sqlConnection.Open();
                int Response = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (Response != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        public int UserLogin(UserLogin userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUserLogin", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName", userLogin.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", userLogin.Password);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int Status = 0;
                while (reader.Read())
                {
                    ///assign the value in status
                    Status = reader.GetInt32(0);
                }
                if (Status == 1)
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
            finally
            {
                ///closing the connection
                sqlConnection.Close();
            }
        }
    }
}
