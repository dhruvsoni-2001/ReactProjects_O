using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Menu
{
    /// <summary>
    /// This Class is used for Chile Item Response
    /// </summary>
    public class ChildItemsData
    {
        public int Id { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        public string Label { get; set; }

        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }

        public string Module { get; set; }

        public byte Sequence { get; set; }

        [JsonPropertyName("menu_link")]
        public string MenuLink { get; set; }

        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }
    }
}