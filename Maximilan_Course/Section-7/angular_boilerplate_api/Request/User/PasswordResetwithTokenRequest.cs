using System.Text.Json.Serialization;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Password reset with token request
    /// </summary>
    public class PasswordResetwithTokenRequest
    {
        public string Password { get; set; }

        [JsonPropertyName("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}