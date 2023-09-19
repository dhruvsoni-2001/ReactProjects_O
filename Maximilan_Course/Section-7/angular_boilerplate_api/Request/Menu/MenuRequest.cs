using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.Menu
{

    /// <summary>
    ///  This Class is used for Creating Menu Requests
    /// </summary>
    public class MenuRequest
    {
        [Required]
        public int ParentId { get; set; }

        [Required]
        public string Label { get; set; }

        [JsonPropertyName("menu_link")]
        public string MenuLink { get; set; }

        [JsonPropertyName("role_ids")]
        public string RoleIds { get; set; }

        public int Module { get; set; }

        public byte Sequence { get; set; }
    }
}