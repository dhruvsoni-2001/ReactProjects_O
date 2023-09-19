using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Settings
{
    public class SettingsResponse
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Label { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Value { get; set; }

        public byte Type { get; set; }

        [StringLength(50)]
        [JsonPropertyName("field_type")]
        public string FieldType { get; set; }

        [StringLength(50)]
        [JsonPropertyName("field_type_value")]
        public string FieldTypeValue { get; set; }
    }
}
