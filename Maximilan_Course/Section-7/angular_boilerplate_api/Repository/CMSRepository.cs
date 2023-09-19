using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.CMS;
using BoilerPlate.Response;
using BoilerPlate.Response.CMS;

namespace BoilerPlate.Repository
{
    public class CMSRepository : ICMSRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public CMSRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }
        public CreateUpdateCMSResponse CreateCMS(CreateUpdateCMSRequest createCMSRequest)
        {
            var data = mapper.Map<CreateUpdateCMSRequest, CMS>(createCMSRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            return mapper.Map<CMS, CreateUpdateCMSResponse>(data);
        }

        public BaseTotalRecordResponse<CMSResponse> GetAllCMS(int limit, int start, string search, string order_col, string order_by)
        {
            var allCms = databaseExecutor.GetAll<CMS>();
            var response = new BaseTotalRecordResponse<CMSResponse>()
            {
                Response = new List<CMSResponse>(),
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                allCms = allCms.Where(x => (!string.IsNullOrWhiteSpace(x.PageName) && x.PageName.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.Slug) && x.Slug.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.Description) && x.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      );
            }

            response.RecordsTotal = allCms.Count();

            if (!string.IsNullOrWhiteSpace(order_col))
            {
                switch (order_col.ToLower())
                {
                    case "pagename":
                        allCms = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? allCms.OrderBy(x => x.PageName) : allCms.OrderByDescending(x => x.PageName);
                        break;
                    case "slug":
                        allCms = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? allCms.OrderBy(x => x.Slug) : allCms.OrderByDescending(x => x.Slug);
                        break;  
                    case "description":
                        allCms = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? allCms.OrderBy(x => x.Description) : allCms.OrderByDescending(x => x.Description);
                        break;
                    default:
                        allCms = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? allCms.OrderBy(x => x.Id) : allCms.OrderByDescending(x => x.Id);
                        break;
                }
            }

            allCms = allCms.Skip(start).Take(limit);

            foreach (var cms in allCms)
            {
                response.Response.Add(mapper.Map<CMS, CMSResponse>(cms));
            }

            return response;
        }

        public CMSResponse GetCMSById(int id)
        {
            var data = databaseExecutor.GetById<CMS>(id);
            data.Id = id;
            return mapper.Map<CMS, CMSResponse>(data);
        }

        public CreateUpdateCMSResponse UpdateCMS(int id, CreateUpdateCMSRequest updateCMSRequest)
        {
            var existingCMS = databaseExecutor.GetById<CMS>(id);
            existingCMS.PageName = updateCMSRequest.PageName;
            existingCMS.Slug = updateCMSRequest.Slug;
            existingCMS.Description = updateCMSRequest.Description;
            existingCMS.Content = updateCMSRequest.Content;
            existingCMS.MetaTitle = updateCMSRequest.MetaTitle;
            existingCMS.MetaDescription = updateCMSRequest.MetaDescription;
            existingCMS.MetaKeyword = updateCMSRequest.MetaKeyword;
            existingCMS.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(existingCMS);
            return mapper.Map<CMS, CreateUpdateCMSResponse>(existingCMS);
        }

        public void DeleteCMS(int id)
        {
            databaseExecutor.Delete<CMS>(id);
        }

        public bool UpdateCMSStatus(int id, UpdateCMSStatusRequest updateCMSStatusRequest)
        {
            var data = databaseExecutor.GetById<CMS>(id);
            data.Status = updateCMSStatusRequest.Status;
            databaseExecutor.Update(data);
            return true;
        }
    }
}
