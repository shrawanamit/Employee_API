///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: Repository Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMSampleRepositoryLayer.serviceRepository
{
    using EMSampleCommanLayer;
    using EMSampleCommanLayer.Models;
    using EMSampleRepositoryLayer.interfaceRepository;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// ado .net class repositry layer
    /// </summary>
    public class EmployeeRL: IEmployeeRL
    {
        /// <summary>
        /// data base connection veriable
        /// </summary>
        private static readonly string ConnectionVariable = "Data Source=DESKTOP-LSKIBA4;Initial Catalog=EmployeeDB;Integrated Security=True";

        /// <summary>
        /// list of employee deyail
        /// </summary>
        /// <returns>List ofemployee</returns>
        public List<EmployeeModel> GetAllEmployee()
        {
            ///sql connection veriable
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
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
                    employeeModel.FirstName = sqlDataReader["FirstName"].ToString();
                    employeeModel.LastName = sqlDataReader["LastName"].ToString();
                    employeeModel.MobNo = sqlDataReader["MobNo"].ToString();
                    employeeModel.Email = sqlDataReader["Email"].ToString();
                    employeeModel.Password = sqlDataReader["Password"].ToString();
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
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
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
                sqlCommand.Parameters.AddWithValue("@Password", employeeModel.Password);
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
        public int UpdateEmployee(int EmployeeID, EmployeeModel employeeModel)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
            
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
                sqlCommand.Parameters.AddWithValue("@Password", employeeModel.Password);
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
        public EmployeeID DeleteEmployee(int EmployeeID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
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
        public EmployeeModel GetSpecificEmployee(int EmployeeID)
        {
            /// connection to database
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
            try
            {
                EmployeeModel employee = new EmployeeModel();
                SqlCommand command = new SqlCommand("spGetSpecificEmployee", sqlConnection);
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = EmployeeID;
                sqlConnection.Open();
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                { 
                    employee.FirstName = Response["FirstName"].ToString();
                    employee.LastName = Response["LastName"].ToString();
                    employee.MobNo = Response["MobNo"].ToString();
                    employee.Email = Response["Email"].ToString();
                    employee.Password = Response["Password"].ToString();
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
        /// login Employee
        /// </summary>
        /// <param name="data">data of login type</param>
        /// <returns>status</returns>
        public int EmployeeLogin(Login data)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionVariable);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spLogin", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", data.Email);
                sqlCommand.Parameters.AddWithValue("@Password", data.Password);
                sqlConnection .Open();
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
