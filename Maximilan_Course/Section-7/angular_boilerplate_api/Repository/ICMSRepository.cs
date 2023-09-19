using BoilerPlate.Request.CMS;
using BoilerPlate.Response;
using BoilerPlate.Response.CMS;

namespace BoilerPlate.Repository
{
    public interface ICMSRepository
    {
        public CreateUpdateCMSResponse CreateCMS(CreateUpdateCMSRequest createCMSRequest);
        public CMSResponse GetCMSById(int id);
        public BaseTotalRecordResponse<CMSResponse> GetAllCMS(int limit, int start, string search, string order_col, string order_by);
        public CreateUpdateCMSResponse UpdateCMS(int id, CreateUpdateCMSRequest updateCMSRequest);
        public void DeleteCMS(int id);
        public bool UpdateCMSStatus(int id, UpdateCMSStatusRequest updateCMSStatusRequest);
    }
}
