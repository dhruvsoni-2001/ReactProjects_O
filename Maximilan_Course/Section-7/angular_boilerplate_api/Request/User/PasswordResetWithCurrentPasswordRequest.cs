using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Reseting password with current password requests
    /// </summary>
    public class PasswordResetWithCurrentPasswordRequest
    {
        [Required]
        public int Id { get; set; } 

        [Required]
        [JsonPropertyName("current_password")]
        public string CurrentPassword { get; set; }

        [Required]
        [JsonPropertyName("new_password")]
        public string NewPassword { get; set; }

        [Required]
        [JsonPropertyName("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}