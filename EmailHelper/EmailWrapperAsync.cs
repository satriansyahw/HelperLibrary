using EmailHelper.EmailSend;
using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailHelper
{
    public class EmailWrapperAsync : IEmailSendAsync
    {
        IEmailSendAsync emailSend = null;

        public EmailWrapperAsync(EmailSMTPProperties properties)
        {
            emailSend = new SMTPEmailSendAsync(properties);
        }
        public EmailWrapperAsync(EmailOutlookProperties properties)
        {
            emailSend = new OutlookEmailSendAsync(properties);
        }
        public EmailWrapperAsync()
        {
            //default, using default conf
            emailSend = new SMTPEmailSendAsync();
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,emailAttachments);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments,sizeLimit);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments, sizeLimit);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments, sizeLimit);
        }

        public virtual async Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return await emailSend.SendEmailAsync(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments, sizeLimit);
        }
    }
}
