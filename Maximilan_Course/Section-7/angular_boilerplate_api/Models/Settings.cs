using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Settings
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Label { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Value { get; set; }

        public string Description { get; set; }

        public byte Type { get; set; }

        [StringLength(50)]
        [JsonPropertyName("field_type")]
        public string FieldType { get; set; }

        [StringLength(50)]
        [JsonPropertyName("field_type_value")]
        public string FieldTypeValue { get; set; }

        [JsonPropertyName("seq_no")]
        public byte SeqNo { get; set; }

        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonPropertyName("updated_by")]
        public int UpdatedBy { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
