using BoilerPlate.Response.Module;
using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Role
{
    /// <summary>
    /// This Class is used for Role Response
    /// </summary>
    public class RoleResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonPropertyName("module_permission")]
        public List<ModulePermission> ModulePermission { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public RoleResponse()
        {
        }
    }

    public class RoleModulePermission
    {
        public string Name { get; set; }
        public string ModuleName { get; set; }
        public string MLabel { get; set; }
        public int Module { get; set; }
    }
}