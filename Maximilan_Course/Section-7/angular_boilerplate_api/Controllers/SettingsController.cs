using BoilerPlate.Repository;
using BoilerPlate.Request.Settings;
using BoilerPlate.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private readonly ISettingRepository settingRepository;

        public SettingsController(ISettingRepository _settingRepository)
        {
            settingRepository = _settingRepository;
        }

        /// <summary>
        /// To get all the results of Settings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSettings()
        {
            var settings = settingRepository.GetAll();
            return Ok(settings);
        }

        /// <summary>
        /// For Creating a setting
        /// </summary>
        /// <param name="createSettingRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSettings(UpdateSettingsRequest updateSettingsRequest)
        {
            var result = settingRepository.UpdateSettings(updateSettingsRequest);
            var response = new CommonResponse<string>()
            {
                Data = result ? "Settings saved successfully" : string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// For Updating setting.
        /// </summary>
        /// <param name="id">Represents the Id of Setting to be Updated</param>
        /// <param name="createSettingRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateSetting(int id, CreateSettingRequest createSettingRequest)
        {
            var updateSetting = settingRepository.UpdateSetting(id, createSettingRequest);
            return Ok(updateSetting);
        }
    }
}
