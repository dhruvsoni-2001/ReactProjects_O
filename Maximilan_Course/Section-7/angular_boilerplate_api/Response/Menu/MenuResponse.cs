using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Menu
{
    /// <summary>
    /// This Class is used for Getting All Menu Response 
    /// </summary>
    public class MenuResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        public string Label { get; set; }

        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }

        public string Module { get; set; }

        public byte Sequence { get; set; }

        [JsonPropertyName("menu_link")]
        public string MenuLink { get; set; }

        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }

        public List<MenuResponse> ChildItems { get; set; }
    }
}
