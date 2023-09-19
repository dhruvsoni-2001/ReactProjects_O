namespace BoilerPlate.Response.Permission
{
    /// <summary>
    /// This Class is used for Getting All Permission Response
    /// </summary>
    public class PermissionResponse
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte Status { get; set; }
    }

    public class ModulePermissionResponse
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleLabel { get; set; }
        public List<PermissionResponse> Permissions { get; set; }
    }

    public class PermissionIntermidiatResponse
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte Status { get; set; }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleLabel { get; set; }
    }

}
