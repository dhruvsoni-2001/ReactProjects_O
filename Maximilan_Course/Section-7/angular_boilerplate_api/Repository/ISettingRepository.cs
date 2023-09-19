using BoilerPlate.Request.Settings;
using BoilerPlate.Response.Settings;

namespace BoilerPlate.Repository
{
    public interface ISettingRepository
    {
        SettingsResponse CreateSettings(CreateSettingRequest createSettingRequest);
       
        List<SettingsResponse> GetAll();
        bool UpdateSettings(UpdateSettingsRequest updateSettingsRequest);
        SettingsResponse UpdateSetting(int id, CreateSettingRequest createSettingRequest);
    }
}

