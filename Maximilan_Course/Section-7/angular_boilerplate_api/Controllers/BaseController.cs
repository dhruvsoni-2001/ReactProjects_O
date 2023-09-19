using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly int SuperAdminId = 1;
        protected void BlockSuperAdminUserRoleUpdate(int id)
        {
            if (id == SuperAdminId)
            {
                throw new Exception("Operation is not allowed.");
            }
        }
    }
}
