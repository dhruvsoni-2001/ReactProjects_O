using BoilerPlate.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        private readonly IDashboardRepository dashboardRepository;

        public DashboardController(IDashboardRepository _dashboardRepository)
        {
            dashboardRepository = _dashboardRepository;
        }

        /// <summary>
        /// Get Statstics
        /// </summary>
        /// <returns>Returns Response of Statstics</returns>
        [HttpGet("statistics")]
        public IActionResult GetStatstics()
        {
            var response = dashboardRepository.GetStatstics();
            return Ok(response);
        }
    }
}