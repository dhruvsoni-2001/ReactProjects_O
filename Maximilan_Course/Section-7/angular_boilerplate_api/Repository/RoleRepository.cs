using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.Role;
using BoilerPlate.Response;
using BoilerPlate.Response.Module;
using BoilerPlate.Response.Role;
using System.Data;

namespace BoilerPlate.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public RoleRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }

        public CreateRoleResponse CreateRole(CreateRoleRequest createRoleRequest)
        {
            var data = mapper.Map<CreateRoleRequest, Role>(createRoleRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            return mapper.Map<Role, CreateRoleResponse>(data);
        }

        public void DeleteRole(int id)
        {
            databaseExecutor.Delete("Delete from user_roles where role_id = " + id.ToString());
            databaseExecutor.Delete("Delete from role_permission where role_id = " + id.ToString());
            databaseExecutor.Delete<Role>(id);
        }

        public RoleResponse GetRoleById(int id)
        {
            var role = databaseExecutor.GetById<Role>(id);
            var roleModules = databaseExecutor.Get<RoleModulePermission>("select lower(p.name) as FirstName, m.name as ModuleName, m.label as MLabel, p.module as Module from role_permission rp inner join permission p on rp.permission_id = p.id inner join module m on p.module = m.id where rp.role_id = " + id.ToString()).ToList();

            var query = (from r in roleModules
                         group r by r.Module into g
                         select new ModulePermission()
                         {
                             CanCreate = g.Any(x => x.Name == "can_create"),
                             CanUpdate = g.Any(x => x.Name == "can_update"),
                             CanDelete = g.Any(x => x.Name == "can_delete"),
                             CanView = g.Any(x => x.Name == "can_view"),
                             Label = g.First().MLabel,
                             ModuleId = g.Key,
                             ModuleName = g.First().ModuleName,
                         }).ToList();

            return new RoleResponse()
            {
                Id = role.Id,
                Status = role.Status,
                Title = role.Title,
                ModulePermission = query,
                CreatedAt = role.CreatedAt
            };
        }

        public RoleResponse GetRoleByUserId(int userId)
        {
            var userRole = databaseExecutor.Get<UserRoles>("select *,role_id as RoleId from user_roles where User_Id = " + userId).FirstOrDefault();
            return GetRoleById(userRole.RoleId);
        }

        public BaseTotalRecordResponse<RoleResponse> GetRoles(int limit, int start, string search, string order_col, string order_by)
        {
            var roles = databaseExecutor.Get<Role>("Select * from Role");
            var response = new BaseTotalRecordResponse<RoleResponse>()
            {
                Response = new List<RoleResponse>(),
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                roles = roles.Where(x => x.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            response.RecordsTotal = roles.Count();
            
            if (!string.IsNullOrWhiteSpace(order_col))
            {
                if (order_col.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    roles = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? roles.OrderBy(x => x.Title) : roles.OrderByDescending(x => x.Title);
                }
                else
                {
                    roles = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? roles.OrderBy(x => x.Id) : roles.OrderByDescending(x => x.Id);
                }
            }

            roles = roles.Skip(start).Take(limit);

            foreach (var role in roles)
            {
                response.Response.Add(GetRoleById(role.Id));
            }

            return response;
        }

        public IEnumerable<RoleResponse> GetUserRole()
        {
            var result = new List<RoleResponse>();
            var roles = databaseExecutor.Get<Role>("Select * from Role");

            foreach (var role in roles)
            {
                result.Add(mapper.Map<Role, RoleResponse>(role));
            }

            return result;
        }

        public RoleResponse UpdateRole(int id, UpdateRoleBodyRequest updateRoleBodyRequest)
        {
            var existingRole = databaseExecutor.GetById<Role>(id);
            existingRole.Title = updateRoleBodyRequest.Title;
            existingRole.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(existingRole);

            databaseExecutor.Delete("Delete from Role_Permission where role_id = " + id);
            
            foreach (var permissionId in updateRoleBodyRequest.Permissions)
            {
                RolePermissions rolePermissions = new RolePermissions();
                rolePermissions.RoleId = id;
                rolePermissions.PermissionId = permissionId;
                rolePermissions.CreatedAt = DateTime.Now;
                rolePermissions.UpdatedAt = DateTime.Now;
                databaseExecutor.Create(rolePermissions);
            }
            
            return GetRoleById(id);
        }

        public bool UpdateRoleStatus(int id, UpdateRoleStatusRequest updateRoleStatusRequest)
        {
            var data = databaseExecutor.GetById<Role>(id);
            data.Status = updateRoleStatusRequest.Status;
            databaseExecutor.Update(data);
            return true;
        }
    }
}
