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
        MailReturnValue SMTPSendEmail(string fromMail,string mailSubject, string mailBody, bool isBodyHTML,string toMail);
        MailReturnValue SMTPSendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC);
        MailReturnValue SMTPSendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC,string toBCC);
        MailReturnValue SMTPSendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);

        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);

        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
        MailReturnValue SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

        
    }
    public interface IEmailSendAsync
    {
        Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC);
        Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    }

    public interface IEmailSendThread
    {
        MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC);
        MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    }

    public interface IEmailSendAttachment
    {
        bool SMTPSendEmailAttachment10MB(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, string toMail);
        bool SMTPSendEmailAttachment10MB(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, string toMail, string toCC);
        bool SMTPSendEmailAttachment10MB(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, string toMail, string toCC, string toBCC);
        bool SMTPSendEmailAttachment10MB(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, EmailToList toMails);

        bool SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments,int attachLimitSize,string toMail);
        bool SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, int attachLimitSize, string toMail, string toCC);
        bool SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, int attachLimitSize, string toMail, string toCC, string toBCC);
        bool SMTPSendEmailAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, List<EmailAttachment> attachments, int attachLimitSize, EmailToList toMails);
    }
    
    
}
