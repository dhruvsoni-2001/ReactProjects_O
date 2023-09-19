using System.Text.Json.Serialization;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Update user info Request
    /// </summary>
    public class UpdateUserRequest
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("role_id")]
        public int RoleId { get; set; }
    }
}