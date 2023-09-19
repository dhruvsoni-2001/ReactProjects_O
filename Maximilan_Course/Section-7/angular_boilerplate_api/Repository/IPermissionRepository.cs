using BoilerPlate.Request.Permission;
using BoilerPlate.Response.Permission;

namespace BoilerPlate.Repository
{
    public interface IPermissionRepository
    {
        public IEnumerable<ModulePermissionResponse> GetPermissions();

        public PermissionResponse GetPermissionById(int id);
        public PermissionResponse CreatePermission(CreatePermissionRequest createPermissionRequest);

        public PermissionResponse UpdatePermission(int id, UpdatePermissionRequest updatePermissionRequest);

        public void DeletePermission(int id);
    }
}
