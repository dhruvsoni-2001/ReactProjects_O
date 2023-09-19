using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Creating User Requests
    /// </summary>
    public class ForgotPasswordRequest
    {
        [Required]
        //[EmailAddress]
        public string Email { get; set; }
    }
}