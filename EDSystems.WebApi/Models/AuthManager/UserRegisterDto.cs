using System.ComponentModel.DataAnnotations;

namespace EDSystems.WebApi.Models.AuthManager
{
    /// <summary>
    ///
    /// </summary>
    public class UserRegisterDto
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}