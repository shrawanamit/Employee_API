///-----------------------------------------------------------------
///   class:      UserModel
///   Description: comman Layer class for userData
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------
namespace EMSampleCommanLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// first name//^[A-Z]{1}[a-z]{3}$//^[A-Za-z0-9]*[@#$%^&*][0-9a-zA-Z]*$
        /// </value>
        [Required(ErrorMessage = "First name required")]
       // [RegularExpression("^[A-Z]{1}[a-z]{3}$", ErrorMessage = "FirstName is not valid")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        /// <value>
        /// last name
        /// </value>
        [Required(ErrorMessage = "lastname required")]
       // [RegularExpression("^[A-Z]{1}[a-z]{3}$", ErrorMessage = "LastName is not valid")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        /// <value>
        /// last name
        /// </value>
        [Required(ErrorMessage = "user name required")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// Mobile NO
        /// </value>
        [Required(ErrorMessage = "Mobile number required")]
        //[RegularExpression("([1-9]{1}[0-9]{9})$", ErrorMessage = "Phone number is not valid")]
        public string MobNo { get; set; }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>
        /// email
        /// </value>
        [Required(ErrorMessage = "emailID required")]
       // [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// password
        /// </value>
        [Required(ErrorMessage ="Password required")]
        // [RegularExpression("^[A-Za-z0-9]*[@#$%^&*][0-9a-zA-Z]*$", ErrorMessage = "Password is not valid")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>
        /// Address
        /// </value>
        [Required(ErrorMessage = " Address required")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Department
        /// </summary>
        /// <value>
        /// Department
        /// </value>
        [Required(ErrorMessage = " Department required")]
        public string Department { get; set; }
    }
}
