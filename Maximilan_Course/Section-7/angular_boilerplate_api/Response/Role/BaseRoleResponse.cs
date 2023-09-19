using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Role
{
    /// <summary>
    /// This Class is used for Getting All User Response
    /// </summary>
    public class BaseRoleResponse
    {
        [JsonPropertyName("total_records")]
        public int TotalRecords { get; set; }

        public List<RoleResponse> RoleResponse { get; set; }

        public BaseRoleResponse()
        {
            RoleResponse = new List<RoleResponse>();
            RoleResponse.Add(new RoleResponse());
        }
    }
}
