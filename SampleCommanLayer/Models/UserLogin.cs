///-----------------------------------------------------------------
///   class:       UserLogin
///   Description: comman Layer class for userLogin
///   Author:      amit                   Date: 30/6/2020
///-----------------------------------------------------------------
namespace EMSampleCommanLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserLogin
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "username Is Required")]
        public string UserName { get; set; }

        /// <summary>
        /// password of employee
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
