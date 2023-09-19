using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Creating User Requests
    /// </summary>
    public class CreateUserRequest
    {
        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("role_id")]
        public int RoleId { get; set; }

        public byte Status { get; set; } 
    }
}