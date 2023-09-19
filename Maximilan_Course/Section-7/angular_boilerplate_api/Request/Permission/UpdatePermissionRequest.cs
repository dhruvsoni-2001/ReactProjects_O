using System.Text.Json.Serialization;

namespace BoilerPlate.Request.Permission
{
    /// <summary>
    /// This Class is used for Updating Permission Requests
    /// </summary>
    public class UpdatePermissionRequest
    {
        public string Label { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("module_id")]
        public int ModuleId { get; set; }

        public byte Status { get; set; }
    }
}