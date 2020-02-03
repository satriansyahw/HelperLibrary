using System.Collections.Generic;
using System.Threading.Tasks;
using EmailHelper.EmailClient;
using EmailHelper.EmailMessage;
using EmailHelper.MiscClass;
using EmailHelper.Validation;

namespace EmailHelper.EmailSend
{
    public class OutlookEmailSendAsync : IEmailSendAsync
    {
        MailReturnValue result = new MailReturnValue();
        public OutlookEmailSendAsync(EmailOutlookProperties properties)
        {
            EmailProperties.GetInstance.ExchangeConnectionTimeout = properties.ExchangeConnectionTimeOut;
            EmailProperties.GetInstance.ExchangeMailServerAddress = properties.ExchangeMailServerAddress;
            EmailProperties.GetInstance.ExchangeMailServerPassword = properties.ExchangeMailServerPassword;
            EmailProperties.GetInstance.ExchangeMailServerUsername = properties.ExchangeMailServerUsername;
            EmailProperties.GetInstance.ExchangeUriService = properties.ExchangeUriService;

        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {  
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if(!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            result=await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail,toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC,toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC,toBCC);
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            Microsoft.Exchange.WebServices.Data.EmailMessage mailMessage = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                CreateOutlookMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }

        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);

            return result;
        }

        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public async virtual Task<MailReturnValue> SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit)
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
            result = await ClientOutlook.GetInstance.SentMailAsync(mailMessage);
            return result;
        }

    }
}
