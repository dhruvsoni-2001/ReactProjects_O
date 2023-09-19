using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Credential Requests
    /// </summary>
    public class CredentialRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}