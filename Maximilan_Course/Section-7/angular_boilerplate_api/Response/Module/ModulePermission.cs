using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Module
{
    /// <summary>
    /// This Class is used for Module permission Response
    /// </summary>
    public class ModulePermission
    {
        [JsonPropertyName("can_create")]
        public bool CanCreate { get; set; }

        [JsonPropertyName("can_update")]
        public bool CanUpdate { get; set; }

        [JsonPropertyName("can_view")]
        public bool CanView { get; set; }

        [JsonPropertyName("can_delete")]
        public bool CanDelete { get; set; }

        [JsonPropertyName("module_id")]
        public int ModuleId { get; set; }

        [JsonPropertyName("module_name")]
        public string ModuleName { get; set; }

        public string Label { get; set; }
    }
}