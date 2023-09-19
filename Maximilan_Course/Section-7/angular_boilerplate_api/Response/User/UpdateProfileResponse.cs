using System.Text.Json.Serialization;

namespace BoilerPlate.Response.User
{
    public class UpdateProfileResponse
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}