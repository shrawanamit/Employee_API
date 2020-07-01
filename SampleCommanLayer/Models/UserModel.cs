
namespace EMSampleCommanLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// first name
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        /// <value>
        /// last name
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        /// <value>
        /// last name
        /// </value>
        [Required]
        public string UserName { get; set; }

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
    }
}
