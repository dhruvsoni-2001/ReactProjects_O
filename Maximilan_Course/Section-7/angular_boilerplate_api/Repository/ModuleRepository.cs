using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Request.Module;
using BoilerPlate.Response.EmailTemplate;
using BoilerPlate.Response.Module;

namespace BoilerPlate.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public ModuleRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }
        public ModuleResponse CreateModule(CreateModuleRequest createModuleRequest)
        {
            var data = mapper.Map<CreateModuleRequest, Module>(createModuleRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            return mapper.Map<Module, ModuleResponse>(data);
        }

        public void DeleteModule(int id)
        {
            databaseExecutor.Delete<Module>(id);
        }

        public ModuleResponse GetModuleById(int id)
        {
            var module = databaseExecutor.GetById<Module>(id);
            return mapper.Map<Module, ModuleResponse>(module); ;
        }

        public IEnumerable<ModuleResponse> GetModules()
        {
            var modules = databaseExecutor.Get<ModuleResponse>("Select * from Module");
            return modules;
        }

        public ModuleResponse UpdateModule(int id,UpdateModuleRequest updateModuleRequest)
        {
            var existingModule = databaseExecutor.GetById<Module>(id);
            existingModule.Label = updateModuleRequest.Label;
            existingModule.Name = updateModuleRequest.Name;
            existingModule.Status = updateModuleRequest.Status;
            existingModule.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(existingModule);
            return mapper.Map<Module, ModuleResponse>(existingModule);
        }
    }
}
