using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Users
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [MaxLength(20)]
        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonPropertyName("email_verified_at")]
        public DateTime EmailVarifiedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }

        [JsonPropertyName("remember_token")]
        public string RememberToken { get; set; }

        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonPropertyName("updated_by")]
        public int UpdatedBy { get; set; }

        [JsonPropertyName("update_password_date")]
        public DateTime? UpdatePasswordDate { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; } 

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; } 

        public string Avatar { get; set; }

        [MaxLength(20)]
        public string Provider { get; set; }

        [JsonPropertyName("provider_id")]
        public string ProviderId { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public string Iama { get; set; }

        [MaxLength(50)]
        public string JourneyAgainst { get; set; }

        public int State { get; set; }

        public int City { get; set; }

        public string PatientAge { get; set; }

        public int Gender { get; set; }

        public int Status { get; set; }
    }
}