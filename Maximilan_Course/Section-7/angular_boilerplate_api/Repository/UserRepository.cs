using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.User;
using BoilerPlate.Response;
using BoilerPlate.Response.User;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BoilerPlate.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly ITokenService _tokenService;
        private readonly IMapper mapper;

        public UserRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper, ITokenService tokenService)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
            _tokenService = tokenService;
        }

        public CreateUserResponse CreateUser(CreateUserRequest createUserRequest)
        {
            var data = mapper.Map<CreateUserRequest, Users>(createUserRequest);
            data.CreatedAt = DateTime.Now;
            var id = databaseExecutor.Create(data);
            data.Id = id;

            UserRoles userRoles = new UserRoles()
            {
                RoleId = createUserRequest.RoleId,
                CreatedAt = DateTime.Now,
                Status = 1,
                UserId = id
            };

            databaseExecutor.Create(userRoles);

            var response = mapper.Map<Users, CreateUserResponse>(data);
            var role = databaseExecutor.GetById<Role>(createUserRequest.RoleId);
            response.RoleId = createUserRequest.RoleId;
            response.RoleTitle = role.Title;
            return response;
        }

        public void DeleteUser(int id)
        {
            databaseExecutor.Delete("Delete from user_roles where user_id = " + id.ToString());
            databaseExecutor.Delete<Users>(id);
        }

        public void ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public ProfileResponse GetProfile(int id)
        {
            var data = databaseExecutor.GetById<Users>(id);
            data.Id = id;
            return mapper.Map<Users, ProfileResponse>(data);
        }

        public IEnumerable<UserRoleResponse> GetRoles()
        {
            var roles = databaseExecutor.Get<UserRoleResponse>("Select * from role;").ToList();
            return roles;
        }

        public BaseTotalRecordResponse<UserResponse> GetUsers(int limit, int start, string search, string order_col, string order_by)
        {
            var users = databaseExecutor.Get<UserResponse>("select u.Id,u.contact_number as ContactNumber,u.last_name as LastName,u.first_name as FirstName,r.title, u.email,u.status, r.Id as RoleId from users u left join user_roles ur on u.id = ur.user_id left join role r on ur.role_id = r.id;");

            var response = new BaseTotalRecordResponse<UserResponse>()
            {
                Response = new List<UserResponse>(),
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                users = users.Where(x => (!string.IsNullOrWhiteSpace(x.Title) && x.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.FirstName) && x.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.LastName) && x.LastName.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.ContactNumber) && x.ContactNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      );
            }

            if (!string.IsNullOrWhiteSpace(order_col))
            {
                switch (order_col.ToLower())
                {
                    case "roles.title":
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.Title) : users.OrderByDescending(x => x.Title);
                        break;
                    case "first_name":
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.FirstName) : users.OrderByDescending(x => x.FirstName);
                        break;
                    case "last_name":
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.LastName) : users.OrderByDescending(x => x.LastName);
                        break;
                    case "email":
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.Email) : users.OrderByDescending(x => x.Email);
                        break;
                    case "contact_number":
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.ContactNumber) : users.OrderByDescending(x => x.ContactNumber);
                        break;
                    default:
                        users = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? users.OrderBy(x => x.Id) : users.OrderByDescending(x => x.Id);
                        break;
                }
            }

            response.RecordsTotal = users.Count();
            response.Response = users.Skip(start).Take(limit).ToList();

            return response;
        }

        public LoginResponse LoginUser(CredentialRequest credentialRequest)
        {
            var existingUser = databaseExecutor.Get<Users>("Select * from users where email= '" + credentialRequest.Email + "'").FirstOrDefault();
            if (existingUser == null)
            {
                throw new Exception("Invalid Credentials.");
            }
            if (existingUser.Password != credentialRequest.Password)
            {
                throw new Exception("Invalid Credentials.");
            }
            var exisingUser2 = databaseExecutor.GetById<Users>(existingUser.Id);
            var loginResponse = mapper.Map<Users, LoginResponse>(exisingUser2);

            var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.UniqueName, exisingUser2.FirstName),
                            new Claim(JwtRegisteredClaimNames.NameId,  exisingUser2.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.AuthTime, "20")
                    };

            loginResponse.AccessToken = _tokenService.GenerateAccessToken(claims);
            return loginResponse;
        }

        public bool ChangePassword(PasswordResetWithCurrentPasswordRequest passwordResetWithCurrentPasswordRequest)
        {
            var user = databaseExecutor.GetById<Users>(passwordResetWithCurrentPasswordRequest.Id);

            if (user.Password != passwordResetWithCurrentPasswordRequest.CurrentPassword)
            {
                throw new Exception("The provided current password is invalid!");
            }

            user.Password = passwordResetWithCurrentPasswordRequest.NewPassword;
            databaseExecutor.Update(user);

            return true;
        }

        public void ResetPasswordToken(string token, PasswordResetwithTokenRequest passwordResetwithTokenRequest)
        {
            throw new NotImplementedException();
        }

        public UpdateProfileResponse UpdateProfile(int id, UpdateProfileRequest updateProfileRequest)
        {
            var data = databaseExecutor.GetById<Users>(id);
            data.FirstName = updateProfileRequest.FirstName;
            data.LastName = updateProfileRequest.LastName;
            data.ContactNumber = updateProfileRequest.ContactNumber;
            databaseExecutor.Update(data);
            return new UpdateProfileResponse()
            {
                ContactNumber = updateProfileRequest.ContactNumber,
                LastName = updateProfileRequest.LastName,
                FirstName = updateProfileRequest.FirstName,
                Email = data.Email,
                CreatedAt = data.CreatedAt
            };
        }

        public UpdatedStatusResponse UpdateStatus(int id, UpdatedStatusRequest updatedStatusRequest)
        {
            var data = databaseExecutor.GetById<Users>(id);
            data.Status = updatedStatusRequest.Status;
            databaseExecutor.Update(data);
            return new UpdatedStatusResponse() { Status = updatedStatusRequest.Status };
        }

        public UpdateUserResponse UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            var data = mapper.Map<UpdateUserRequest, Users>(updateUserRequest);
            var existingUser = databaseExecutor.GetById<Users>(id);
            data.Password = existingUser.Password;
            data.Id = id;
            databaseExecutor.Update(data);

            var userRole = databaseExecutor.Get<UserRoles>("select *,role_id as RoleId from user_roles where User_Id = " + id).FirstOrDefault();
            if (userRole != null)
            {
                userRole.UserId = id;
                userRole.RoleId = updateUserRequest.RoleId;
                userRole.UpdatedAt = DateTime.Now;
                databaseExecutor.Update(userRole);
            }
            else
            {
                UserRoles userRoles = new UserRoles()
                {
                    RoleId = updateUserRequest.RoleId,
                    UserId = id,
                    CreatedAt = DateTime.Now,
                    Status = 1
                };
                databaseExecutor.Create(userRoles);
            }

            var response = mapper.Map<Users, UpdateUserResponse>(data);

            var role = databaseExecutor.GetById<Role>(updateUserRequest.RoleId);
            response.RoleId = updateUserRequest.RoleId;
            response.RoleTitle = role.Title;

            return response;
        }
    }
}