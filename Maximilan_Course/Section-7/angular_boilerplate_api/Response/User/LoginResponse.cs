using BoilerPlate.Response.Role;
using System.Text.Json.Serialization;

namespace BoilerPlate.Response.User
{
    /// <summary>
    /// This Class is used for User Login Response
    /// </summary>
    public class LoginResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        public RoleResponse Role {  get; set; }
    }
}
