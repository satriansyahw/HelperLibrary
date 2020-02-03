using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHelper.EmailSend
{
    public interface IEmailSend
    {
        MailReturnValue SendEmail(string fromMail,string mailSubject, string mailBody, bool isBodyHTML,string toMail);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC,string toBCC);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);

        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);

        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

        
    }
    public interface IEmailSendAsync
    {
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);

        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);

        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

    }

    public interface IEmailSendThread
    {
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);

        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);

        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

    }

    
    
}
