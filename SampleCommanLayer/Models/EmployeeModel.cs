///-----------------------------------------------------------------
///   class:       EmployeeRL
///   Description: Repository Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

using LanguageExt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMSampleCommanLayer.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// Employee ID
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// first name
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// last name
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// Mobile NO
        /// </value>
        [Required]
        public string MobNo { get; set; }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>
        /// email
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// password
        /// </value>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>
        /// Address
        /// </value>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Department
        /// </summary>
        /// <value>
        /// Department
        /// </value>
        [Required]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets Salary
        /// </summary>
        ///  <value>
        /// salary
        /// </value>
        [Required]
        public int Salary{ get; set; }
    }
}
