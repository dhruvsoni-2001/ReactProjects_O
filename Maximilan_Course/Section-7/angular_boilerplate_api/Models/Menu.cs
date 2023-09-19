using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public string Label { get; set; }

        [JsonPropertyName("menu_link")]
        public string MenuLink { get; set; }

        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }

        public int Module { get; set; }

        public byte Sequence { get; set; }

        [JsonPropertyName("bootstrap_class")]
        public string BootstrapClass { get; set; }

        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }

        [Required]
        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}