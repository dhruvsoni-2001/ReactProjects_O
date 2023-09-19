using BoilerPlate.DbConnector;
using BoilerPlate.Response.Dashboard;

namespace BoilerPlate.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DatabaseExecutor databaseExecutor;

        public DashboardRepository(DatabaseExecutor _databaseExecutor)
        {
            databaseExecutor = _databaseExecutor;
        }

        public StatisticsResponse GetStatstics()
        {
            var response= new StatisticsResponse();
            response.User = databaseExecutor.GetScaler<int>("Select Count(id) from users;");
            response.Role = databaseExecutor.GetScaler<int>("Select count(id) from Role;");
            response.CMS = databaseExecutor.GetScaler<int>("Select count(id) from CMS;");
            response.EmailTemplate = databaseExecutor.GetScaler<int>("Select count(id) from EmailTemplate;");
            response.Product = databaseExecutor.GetScaler<int>("Select count(id) from Products;");
            return response;
        }
    }
}