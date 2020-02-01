using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EmailHelper.EmailMessage;
using EmailHelper.MiscClass;
using EmailHelper.Properties;
using EmailHelper.Validation;

namespace EmailHelper.EmailSend
{
    public class SMTPEmailSendAsync : IEmailSendAsync
    {
        MailReturnValue result = new MailReturnValue();
        public virtual async Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            result = await ClientSMTP.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public virtual async Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC);
            result = await ClientSMTP.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public virtual async Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC, toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC, toBCC);
            result = await ClientSMTP.GetInstance.SentMailAsync(mailMessage);
            return result;
        }
        public virtual async Task<MailReturnValue> SMTPSendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
            result = await ClientSMTP.GetInstance.SentMailAsync(mailMessage);
            return result;
        }

    }
}
