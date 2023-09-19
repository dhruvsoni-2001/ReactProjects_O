using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Request.Permission;
using BoilerPlate.Response.EmailTemplate;
using BoilerPlate.Response.Permission;

namespace BoilerPlate.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public PermissionRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }
        public PermissionResponse CreatePermission(CreatePermissionRequest createPermissionRequest)
        {
            var data = mapper.Map<CreatePermissionRequest, Permission>(createPermissionRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;

            return mapper.Map<Permission, PermissionResponse>(data);
        }

        public void DeletePermission(int id)
        {
            databaseExecutor.Delete<Permission>(id);
        }

        public PermissionResponse GetPermissionById(int id)
        {
            var permission = databaseExecutor.GetById<Permission>(id);
            return mapper.Map<Permission, PermissionResponse>(permission);
        }

        public IEnumerable<ModulePermissionResponse> GetPermissions()
        {
            var permissions = databaseExecutor.Get<PermissionIntermidiatResponse>("select p.*, m.id as ModuleId, m.name as ModuleName, m.label as ModuleLabel from permission p inner join module m on p.module = m.id;");
            var groups = (from p in permissions
                         group p by p.ModuleId into g
                         select new ModulePermissionResponse
                         {
                             ModuleId = g.Key,
                             ModuleLabel = g.First().ModuleLabel,
                             ModuleName = g.First().ModuleName,
                             Permissions = g.Select(x => new PermissionResponse()
                             {
                                 Id = x.Id,
                                 Description = x.Description,
                                 Label = x.Label,
                                 Name = x.Name,
                                 Status = x.Status,
                             }).ToList()
                         }).ToList();

            return groups;
        }

        public PermissionResponse UpdatePermission(int id, UpdatePermissionRequest updatePermissionRequest)
        {
            var existingPermission = databaseExecutor.GetById<Permission>(id);
            existingPermission.Label = updatePermissionRequest.Label;
            existingPermission.Name = updatePermissionRequest.Name;
            existingPermission.Description = updatePermissionRequest.Description;
            existingPermission.ModuleId = updatePermissionRequest.ModuleId;
            existingPermission.Status = updatePermissionRequest.Status;
            existingPermission.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(existingPermission);
            return mapper.Map<Permission, PermissionResponse>(existingPermission);
        }
    }
}
