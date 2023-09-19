using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.Settings;
using BoilerPlate.Response.Settings;

namespace BoilerPlate.Repository
{
    public class SettingRepository : ISettingRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public SettingRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }

        public List<SettingsResponse> GetAll()
        {
            var settings = databaseExecutor.Get<SettingsResponse>
                ("Select id as Id, label as Label, name as FirstName, value as Value, description as Description, type as Type, field_type as FieldType, field_type_value as FieldTypeValue from settings where type != 0 Order By type, seq_no, id;").ToList();             
            return settings;
        }

        public SettingsResponse CreateSettings(CreateSettingRequest createSettingRequest)
        {
            var data = mapper.Map<CreateSettingRequest, Settings>(createSettingRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            data.CreatedAt = DateTime.Now;
            return mapper.Map<Settings, SettingsResponse>(data);
        }

        public bool UpdateSettings(UpdateSettingsRequest updateSettingsRequest)
        {
            foreach (var setting in updateSettingsRequest.SettingData)
            {
                UpdateSetting(setting.Id, setting);
            }
            return true;
        }

        public SettingsResponse UpdateSetting(int id, CreateSettingRequest createSettingRequest)
        {
            var updateSettings = databaseExecutor.GetById<Settings>(id);
            updateSettings.Label = createSettingRequest.Label;
            updateSettings.Name = createSettingRequest.Name;
            updateSettings.Description = createSettingRequest.Description;
            updateSettings.Value  = createSettingRequest.Value;
            updateSettings.Type = createSettingRequest.Type;
            updateSettings.FieldType = createSettingRequest.FieldType;
            updateSettings.FieldTypeValue = createSettingRequest.FieldTypeValue;
            updateSettings.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(updateSettings);
            return mapper.Map < Settings, SettingsResponse > (updateSettings);
        }
    }
}
