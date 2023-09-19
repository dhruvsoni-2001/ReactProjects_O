using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    [Table("user_roles")]
    public class UserRoles
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("user_id")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [JsonPropertyName("role_id")]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(1)]
        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}