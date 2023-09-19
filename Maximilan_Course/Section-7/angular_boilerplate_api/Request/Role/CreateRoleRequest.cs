using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.Role
{
    /// <summary>
    /// This Class is used for Creating Role Requests
    /// </summary>
    public class CreateRoleRequest
    {
        [Required]
        public string Title { get; set; }
    }
}