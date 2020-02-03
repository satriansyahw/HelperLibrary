using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EmailHelper.EmailClient;
using EmailHelper.EmailMessage;
using EmailHelper.MiscClass;

using EmailHelper.Validation;

namespace EmailHelper.EmailSend
{
    public class OutlookEmailSend : IEmailSend
    {
        MailReturnValue result = new MailReturnValue();
        public OutlookEmailSend(EmailOutlookProperties properties)
        {
            EmailProperties.GetInstance.ExchangeConnectionTimeout = properties.ExchangeConnectionTimeOut;
            EmailProperties.GetInstance.ExchangeMailServerAddress = properties.ExchangeMailServerAddress;
            EmailProperties.GetInstance.ExchangeMailServerPassword = properties.ExchangeMailServerPassword;
            EmailProperties.GetInstance.ExchangeMailServerUsername = properties.ExchangeMailServerUsername;
            EmailProperties.GetInstance.ExchangeUriService = properties.ExchangeUriService;

        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {  
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if(!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            result= ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail,toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC,toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC,toBCC);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }

        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail,emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC, toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);

            return result;
        }

        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments, sizeLimit);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments, sizeLimit);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC, toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments, sizeLimit);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC, toBCC, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }
        public virtual MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            result = ValidationAtttachment.GetInstance.ValidateAttachment(emailAttachments,sizeLimit);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessageAttachment.GetInstance.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments);
            result = ClientOutlook.GetInstance.SentMail(mailMessage);
            return result;
        }

    }
}
