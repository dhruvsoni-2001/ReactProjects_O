namespace BoilerPlate.Request.Role
{
    /// <summary>
    /// This Class is used for Update Role title Requests
    /// </summary>
    public class UpdateRoleBodyRequest
    {
        public string Title { get; set; }

        public List<int> Permissions { get; set; }
    }
}