using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.Permission
{
    /// <summary>
    ///  This Class is used for Creating Permission Requests
    /// </summary>
    public class CreatePermissionRequest
    {
        [Required]
        public string Label { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("module_id")]
        public int Module { get; set; }

        public byte Status { get; set; }
    }
}