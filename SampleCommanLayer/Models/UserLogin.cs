
namespace EMSampleCommanLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserLogin
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "Email Is Required")]
        public string UserName { get; set; }

        /// <summary>
        /// password of employee
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
