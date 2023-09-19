using BoilerPlate.Request.User;
using BoilerPlate.Response;
using BoilerPlate.Response.User;

namespace BoilerPlate.Repository
{
    public interface IUserRepository
    {
        public LoginResponse LoginUser(CredentialRequest credentialRequest);

        public CreateUserResponse CreateUser(CreateUserRequest createUserRequest);

        public BaseTotalRecordResponse<UserResponse> GetUsers(int limit, int start, string search, string order_col, string order_by);

        public UpdateUserResponse UpdateUser(int id, UpdateUserRequest updateUserRequest);

        public void DeleteUser(int id);

        public UpdatedStatusResponse UpdateStatus(int id, UpdatedStatusRequest updatedStatusRequest);

        public IEnumerable<UserRoleResponse> GetRoles();

        public ProfileResponse GetProfile(int id);

        public UpdateProfileResponse UpdateProfile(int id, UpdateProfileRequest updateProfileRequest);

        public void ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);

        public void ResetPasswordToken(string token, PasswordResetwithTokenRequest passwordResetwithTokenRequest);

        public bool ChangePassword(PasswordResetWithCurrentPasswordRequest passwordResetWithCurrentPasswordRequest);

    }
}