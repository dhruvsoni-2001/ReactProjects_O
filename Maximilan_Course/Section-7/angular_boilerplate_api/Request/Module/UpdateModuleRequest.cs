namespace BoilerPlate.Request.Module
{
    /// <summary>
    ///  This Class is used for Update Module Requests
    /// </summary>
    public class UpdateModuleRequest
    {
        public string Label { get; set; }

        public string Name { get; set; }

        public byte Status { get; set; }
    }
}