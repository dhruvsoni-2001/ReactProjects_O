using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Response;
using BoilerPlate.Response.EmailTemplate;

namespace BoilerPlate.Repository
{
    public interface IEmailTemplateRepository
    {
        public CreateUpdateEmailTemplateResponse CreateEmailTemplate(EmailTemplateRequest emailTemplateRequest);
        public BaseTotalRecordResponse<EmailTemplateResponse> GetEmailTemplates(int limit, int start, string search, string order_col, string order_by);
        public EmailTemplateResponse GetEmailTemplateById(int id);
        public CreateUpdateEmailTemplateResponse UpdateEmailTemplate(int id, EmailTemplateRequest emailTemplateRequest);
        public void DeleteEmailTemplate(int id);
        public bool UpdateEmailTemplateStatus(int id, UpdateEmailTemplateStatusRequest updateEmailTemplateStatusRequest);
    }
}
