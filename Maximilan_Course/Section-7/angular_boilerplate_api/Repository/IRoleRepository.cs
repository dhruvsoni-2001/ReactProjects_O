using BoilerPlate.Request.Role;
using BoilerPlate.Response;
using BoilerPlate.Response.Role;

namespace BoilerPlate.Repository
{
    public interface IRoleRepository
    {
        public BaseTotalRecordResponse<RoleResponse> GetRoles(int limit, int start, string search, string order_col, string order_by);

        public RoleResponse GetRoleById(int id);
        
        public CreateRoleResponse CreateRole(CreateRoleRequest createRoleRequest);

        public RoleResponse UpdateRole(int id, UpdateRoleBodyRequest updateRoleBodyRequest);

        public void DeleteRole(int id);

        public IEnumerable<RoleResponse> GetUserRole();

        public bool UpdateRoleStatus(int id, UpdateRoleStatusRequest updateRoleStatusRequest);

        public RoleResponse GetRoleByUserId(int userId);
    }
}
