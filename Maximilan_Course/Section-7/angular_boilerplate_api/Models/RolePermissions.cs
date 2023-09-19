using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    [Table("role_permission")]
    public class RolePermissions
    {
        public int Id { get; set; }

        [JsonPropertyName("role_id")]
        public int RoleId { get; set; }

        [JsonPropertyName("permission_id")]
        public int PermissionId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set;}

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
