///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: Repository Layer class for employee and ado .net code connection with data base
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMSampleRepositoryLayer.serviceRepository
{
    using EMSampleCommanLayer;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// ado .net class repositry layer
    /// </summary>
    public class EmployeeRL: IEmployeeRL
    {
        /// <summary>
        /// data base connection veriable
        /// </summary>
         private SqlConnection sqlConnection;

        public EmployeeRL()
        {
            var configuration = this.GetConfiguration();
            this.sqlConnection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        /// <summary>
        /// list of employee deyail
        /// </summary>
        /// <returns>List ofemployee</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                /// declaration list of type Employee Model
                List<EmployeeModel> employeeModelsList = new List<EmployeeModel>();
                /// new instance sql command
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ///open sql connection
                sqlConnection.Open();
                ///reading data base forward stream
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    /// instace of employee model
                    EmployeeModel employeeModel = new EmployeeModel();
                    employeeModel.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);
                    employeeModel.FirstName = sqlDataReader["FirstName"].ToString();
                    employeeModel.LastName = sqlDataReader["LastName"].ToString();
                    employeeModel.MobNo = sqlDataReader["MobNo"].ToString();
                    employeeModel.Email = sqlDataReader["Email"].ToString();
                    employeeModel.Address = sqlDataReader["Address"].ToString();
                    employeeModel.Department = sqlDataReader["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(sqlDataReader["Salary"]);
                    employeeModelsList.Add(employeeModel);
                }
                sqlConnection.Close();
                return employeeModelsList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employeeModel">employee data</param>
        /// <returns>boolean value </returns>
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                //for store procedure and connection to database
                SqlCommand sqlCommand = new SqlCommand("spEmployeeRegistration", sqlConnection);
                ////take the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                sqlCommand.Parameters.AddWithValue("@MobNo", employeeModel.MobNo);
                sqlCommand.Parameters.AddWithValue("@Email", employeeModel.Email);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary.ToString());
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
        /// update employee id
        /// </summary>
        /// <param name="EmployeeID">id</param>
        /// <param name="employeeModel">employee model</param>
        /// <returns>status</returns>
        public int UpdateEmployeeByID(int EmployeeID, EmployeeModel employeeModel)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployees", sqlConnection);
                ////take the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = EmployeeID;
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                sqlCommand.Parameters.AddWithValue("@MobNo", employeeModel.MobNo);
                sqlCommand.Parameters.AddWithValue("@Email", employeeModel.Email);
                sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary.ToString());
                sqlConnection.Open();
                int Response = sqlCommand.ExecuteNonQuery();
                if (Response == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
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
        /// <summary>
        /// delete employee detail by id
        /// </summary>
        /// <param name="EmployeeID">id of employee</param>
        /// <returns>employee id</returns>
        public EmployeeID DeleteEmployeeByID(int EmployeeID)
        { 
            try
            {
                ///instace of employeeid model
                EmployeeID employee = new EmployeeID();
                ///for store procedure and connection to database
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeesByID", sqlConnection);
                ///take the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = EmployeeID;
                sqlConnection.Open();
                SqlDataReader Response = sqlCommand.ExecuteReader();
                return employee;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// get specific employee by id
        /// </summary>
        /// <param name="EmployeeID">employee id</param>
        /// <returns>id of employee</returns>
        public EmployeeModel GetEmployeeByID(int EmployeeID)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                SqlCommand command = new SqlCommand("spGetSpecificEmployee", sqlConnection);
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = EmployeeID;
                sqlConnection.Open();
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(Response["EmployeeID"]);
                    employee.FirstName = Response["FirstName"].ToString();
                    employee.LastName = Response["LastName"].ToString();
                    employee.MobNo = Response["MobNo"].ToString();
                    employee.Email = Response["Email"].ToString();
                    employee.Address = Response["Department"].ToString();
                    employee.Department = Response["Department"].ToString();
                    employee.Salary = Convert.ToInt32(Response["Salary"]);
                }
                return employee;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally 
            {
                sqlConnection.Close();
            }
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
