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
    public class SMTPEmailEmailSend : IEmailSendThread
    {
        MailReturnValue result = new MailReturnValue();

        public virtual MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if (!result.IsSuccessMail)
            {
                return result;                
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            ClientSMTP.GetInstance.SentMailThread(mailMessage);
            return result;
        }
        public virtual MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC);
            ClientSMTP.GetInstance.SentMailThread(mailMessage);
            return result;

        }
        public virtual MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMail, toCC, toBCC);
            if (!result.IsSuccessMail)
            {
                return result;
               
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC, toBCC);
            ClientSMTP.GetInstance.SentMailThread(mailMessage);
            return result;
        }
        public virtual MailReturnValue SMTPSendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            result = ValidationSendMail.GetInstance.ValidateSendMail(fromMail, mailSubject, mailBody, toMails);
            if (!result.IsSuccessMail)
            {
                return result;
            }
            MailMessage mailMessage = CreateMailMessage.GetInstance.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
            ClientSMTP.GetInstance.SentMailThread(mailMessage);
            return result;

        }

    }
}
