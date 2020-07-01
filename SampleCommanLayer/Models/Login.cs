///-----------------------------------------------------------------
///   class:       logincomman
///   Description: Repository Layer class for employee
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EMSampleCommanLayer
{
    /// <summary>
    /// set get method for employee login
    /// </summary>
    public class Login
    {
        /// <summary>
        /// email
        /// </summary>
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }

        /// <summary>
        /// password of employee
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
