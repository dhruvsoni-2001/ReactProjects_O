using AutoMapper;
using BoilerPlate.Models;
using BoilerPlate.Request.CMS;
using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Request.Menu;
using BoilerPlate.Request.Module;
using BoilerPlate.Request.Permission;
using BoilerPlate.Request.Products;
using BoilerPlate.Request.Role;
using BoilerPlate.Request.Settings;
using BoilerPlate.Request.User;
using BoilerPlate.Response.CMS;
using BoilerPlate.Response.EmailTemplate;
using BoilerPlate.Response.Menu;
using BoilerPlate.Response.Module;
using BoilerPlate.Response.Permission;
using BoilerPlate.Response.Products;
using BoilerPlate.Response.Role;
using BoilerPlate.Response.Settings;
using BoilerPlate.Response.User;

namespace BoilerPlate.CustomHandlers
{
    public class CustomMapperHandler : Profile
    {
        public CustomMapperHandler()
        {
            CreateMap<CreateModuleRequest, Module>();
            
            CreateMap<Module, ModuleResponse>();

            CreateMap<UpdateModuleRequest, Module>();

            CreateMap<ModuleResponse, Module>();

            CreateMap<CreatePermissionRequest, Permission>();
           
            CreateMap<Permission, PermissionResponse>();

            CreateMap<UpdatePermissionRequest, Permission>();

            CreateMap<CreateRoleRequest, Role>();
            CreateMap<CreateUserRequest, Users>();
            CreateMap<Users, CreateUserResponse>();

            CreateMap<UpdateUserRequest , Users>();
            CreateMap<Users, UpdateUserResponse>();
            CreateMap<UpdateRoleBodyRequest, Role>();

            CreateMap<UpdatedStatusRequest , Users>();
            CreateMap<Users , UpdatedStatusResponse>();
            CreateMap<UpdateRoleStatusRequest, Role>();

            CreateMap<UpdateProfileRequest, Users>();
            CreateMap<Users, ProfileResponse>();
            CreateMap<Users, UpdateProfileResponse>();

            CreateMap<Role, UpdateRoleStatusResponse>();

            CreateMap<Role, RoleResponse>();
            CreateMap<MenuRequest, Menu >();
            CreateMap<Menu , MenuResponse>();

            CreateMap<UserRoleResponse, Role>();
            CreateMap<Role, CreateRoleResponse>();

            CreateMap<CredentialRequest, Users>();
            CreateMap<Users, LoginResponse>();

            CreateMap<Products, ProductsResponse>().ReverseMap();
            CreateMap<CreateProductRequest, ProductsResponse>().ReverseMap();
            CreateMap<CreateProductRequest, Products>().ReverseMap();
            CreateMap<Products, UpdateProductResponse>().ReverseMap();

            CreateMap<Settings, SettingsResponse>().ReverseMap();
            CreateMap<CreateSettingRequest, Settings>().ReverseMap();

            CreateMap<EmailTemplateRequest, EmailTemplate>();
            CreateMap<EmailTemplate, CreateUpdateEmailTemplateResponse>();

            CreateMap<EmailTemplate, EmailTemplateResponse>();

            CreateMap<CreateUpdateCMSRequest, CMS>();
            CreateMap<CMS, CreateUpdateCMSResponse>();
            CreateMap<CMS, CMSResponse>();
        }
    }
}