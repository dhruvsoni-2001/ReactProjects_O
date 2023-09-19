using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.User
{
    /// <summary>
    /// This Class is used for Update user Profile Request
    /// </summary>
    public class UpdateProfileRequest
    {
        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }
    }
}