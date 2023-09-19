using BoilerPlate.Response.Dashboard;

namespace BoilerPlate.Repository
{
    public interface IDashboardRepository
    {
        public StatisticsResponse GetStatstics();
    }
}