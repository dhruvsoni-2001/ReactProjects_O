using BoilerPlate.Models;
using BoilerPlate.Request.Module;
using BoilerPlate.Response.Module;

namespace BoilerPlate.Repository
{
    public interface IModuleRepository
    {
        public IEnumerable<ModuleResponse> GetModules();

        public ModuleResponse GetModuleById(int id);

        public ModuleResponse CreateModule(CreateModuleRequest createModuleRequest);

        public ModuleResponse UpdateModule(int id, UpdateModuleRequest updateModuleRequest);

        public void DeleteModule(int id);
    }
}
