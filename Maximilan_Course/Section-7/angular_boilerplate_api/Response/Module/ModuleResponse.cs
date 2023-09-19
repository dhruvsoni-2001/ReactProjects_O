namespace BoilerPlate.Response.Module
{
    /// <summary>
    /// This Class is used for Module Response 
    /// </summary>
    public class ModuleResponse : BaseModuleResponse
    {
        public string Label { get; set; }

        public string Name { get; set; }

        public byte Status { get; set; }
    }
}