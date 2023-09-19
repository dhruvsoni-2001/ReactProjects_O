using System.Text.Json.Serialization;

namespace BoilerPlate.Response.User
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int RoleId { get; set; }
    }
}
