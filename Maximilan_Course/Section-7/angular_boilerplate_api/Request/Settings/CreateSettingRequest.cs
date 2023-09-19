using System.Text.Json.Serialization;

namespace BoilerPlate.Request.Settings
{
    public class UpdateSettingsRequest
    {
        public List<CreateSettingRequest> SettingData { get; set; }
    }
    public class CreateSettingRequest
    {
        public int Id { get; set; }

        public string? Label { get; set; }

        public string? Description { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }

        public byte Type { get; set; }

        [JsonPropertyName("field_type")]
        public string FieldType { get; set; }

        [JsonPropertyName("field_type_value")]
        public string FieldTypeValue { get; set; }
    }
}
