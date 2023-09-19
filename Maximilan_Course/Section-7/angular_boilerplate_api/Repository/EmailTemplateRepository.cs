using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Response;
using BoilerPlate.Response.EmailTemplate;

namespace BoilerPlate.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public EmailTemplateRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }
        public CreateUpdateEmailTemplateResponse CreateEmailTemplate(EmailTemplateRequest emailTemplateRequest)
        {
            var data = mapper.Map<EmailTemplateRequest, EmailTemplate>(emailTemplateRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            return mapper.Map<EmailTemplate, CreateUpdateEmailTemplateResponse>(data);
        }

        public EmailTemplateResponse GetEmailTemplateById(int id)
        {
            var data = databaseExecutor.GetById<EmailTemplate>(id);
            data.Id = id;
            return mapper.Map<EmailTemplate, EmailTemplateResponse>(data);
        }

        public BaseTotalRecordResponse<EmailTemplateResponse> GetEmailTemplates(int limit, int start, string search, string order_col, string order_by)
        {
            var emailTemplates = databaseExecutor.GetAll<EmailTemplate>();
            var response = new BaseTotalRecordResponse<EmailTemplateResponse>()
            {
                Response = new List<EmailTemplateResponse>(),
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                emailTemplates = emailTemplates.Where(x => (!string.IsNullOrWhiteSpace(x.TemplateTitle) && x.TemplateTitle.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      || (!string.IsNullOrWhiteSpace(x.Subject) && x.Subject.Contains(search, StringComparison.OrdinalIgnoreCase))
                                      );
            }

            response.RecordsTotal = emailTemplates.Count();

            if (!string.IsNullOrWhiteSpace(order_col))
            {
                switch (order_col.ToLower())
                {
                    case "title":
                        emailTemplates = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? emailTemplates.OrderBy(x => x.TemplateTitle) : emailTemplates.OrderByDescending(x => x.TemplateTitle);
                        break;
                    case "subject":
                        emailTemplates = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? emailTemplates.OrderBy(x => x.Subject) : emailTemplates.OrderByDescending(x => x.Subject);
                        break;
                    default:
                        emailTemplates = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? emailTemplates.OrderBy(x => x.Id) : emailTemplates.OrderByDescending(x => x.Id);
                        break;
                }
            }

            emailTemplates = emailTemplates.Skip(start).Take(limit);

            foreach (var emailTemplate in emailTemplates)
            {
                response.Response.Add(mapper.Map<EmailTemplate, EmailTemplateResponse>(emailTemplate));
            }

            return response;
        }

        public CreateUpdateEmailTemplateResponse UpdateEmailTemplate(int id, EmailTemplateRequest emailTemplateRequest)
        {
            var existingEmailTemplate = databaseExecutor.GetById<EmailTemplate>(id);
            existingEmailTemplate.TemplateTitle = emailTemplateRequest.TemplateTitle;
            existingEmailTemplate.Subject = emailTemplateRequest.Subject;
            existingEmailTemplate.Content = emailTemplateRequest.Content;
            existingEmailTemplate.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(existingEmailTemplate);
            return mapper.Map<EmailTemplate, CreateUpdateEmailTemplateResponse>(existingEmailTemplate);
        }

        public void DeleteEmailTemplate(int id)
        {
            databaseExecutor.Delete<EmailTemplate>(id);
        }

        public bool UpdateEmailTemplateStatus(int id, UpdateEmailTemplateStatusRequest updateEmailTemplateStatusRequest)
        {
            var data = databaseExecutor.GetById<EmailTemplate>(id);
            data.Status = updateEmailTemplateStatusRequest.Status;
            databaseExecutor.Update(data);
            return true;
        }
    }
}
