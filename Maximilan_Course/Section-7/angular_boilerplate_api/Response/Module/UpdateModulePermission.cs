using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Module
{
    /// <summary>
    /// This Class is used for Update Module Permission Response
    /// </summary>
    public class UpdateModulePermission
    {
        public ModulePermission Role { get; set; }

        public ModulePermission Permission { get; set; }

        public ModulePermission Settings { get; set; }

        public ModulePermission Users { get; set; }

        public ModulePermission Product { get; set; }

        [JsonPropertyName("email_template")]
        public ModulePermission EmailTemplate { get; set; }

        public ModulePermission Cms { get; set; }

        public ModulePermission String { get; set; }

        public UpdateModulePermission()
        {
            Role = new ModulePermission();
            Permission = new ModulePermission();
            Settings = new ModulePermission();
            Users = new ModulePermission();
            Product = new ModulePermission();
            EmailTemplate = new ModulePermission();
            Cms = new ModulePermission();
            String = new ModulePermission();
        }
    }
}