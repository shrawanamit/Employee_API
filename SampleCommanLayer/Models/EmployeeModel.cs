///-----------------------------------------------------------------
///   class:       EmployeeModel
///   Description: comman Layer class for user
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

namespace EMSampleCommanLayer.Models
{
    using System.ComponentModel.DataAnnotations;
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
        [Required (ErrorMessage = "Mobile number required")]
        //[RegularExpression("([1-9]{1}[0-9]{9})$", ErrorMessage = "Phone number is not valid")]
        public string MobNo { get; set; }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>
        /// email
        /// </value>
        [Required(ErrorMessage = "emailID required")]
        //[RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string Email { get; set; }


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

        /// <summary>
        /// Gets or sets Salary
        /// </summary>
        ///  <value>
        /// salary
        /// </value>
        [Required]
        public string JoiningDate { get; set; }
        /// <summary>
        /// Gets or sets Salary
        /// </summary>
        ///  <value>
        /// salary
        /// </value>
        [Required]
        public string ModifiedDate { get; set; }
    }
}
