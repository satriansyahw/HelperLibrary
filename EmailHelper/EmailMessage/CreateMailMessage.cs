using EmailHelper.MiscClass;
using EmailHelper.Properties;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailHelper.EmailMessage
{
    public class CreateMailMessage:IMailMessage
    {
        /*Before call functions this this class function , make sure you have validated the mailto,maillcc,mailbcc or  to emails
         * , you can call methode ValidationSendMail.GetInstance.ValidateSendMail*/
        private static CreateMailMessage instance;
        public static CreateMailMessage GetInstance
        {
            get
            {
                if (instance == null) instance = new CreateMailMessage();
                return instance;
            }
        }
        public MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody,bool isBodyHTML, string toMail)
        {         
            MailMessage mailMessage = new MailMessage(fromMail.Trim(), toMail.Trim());
            int maxLengthMailSubject = EmailProperties.GetInstance.MailSubjectMaxLength;
            mailBody = mailBody.Length > maxLengthMailSubject
                ? mailBody.Substring(0, maxLengthMailSubject) + "...." : mailBody;
            mailMessage.IsBodyHtml = isBodyHTML;
            mailMessage.Subject = mailSubject;
            mailMessage.Body = mailBody;
            return mailMessage;
        }

        public MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            MailMessage mailMessage = this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            mailMessage.CC.Add(toCC.Trim());
            return mailMessage;
        }
        public MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC,string toBCC)
        {
            MailMessage mailMessage = this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
            mailMessage.Bcc.Add(toBCC.Trim());
            return mailMessage;
        }

        public MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            string emailTo = toMails.ListEmailTo[0].Trim();
            MailMessage mailMessage =  this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, emailTo);
            for (int i = 1; i < toMails.ListEmailTo.Count; i++)
            {
                mailMessage.To.Add(toMails.ListEmailTo[i]);
            }
            foreach (var item in toMails.ListEmailCc)
            {
                mailMessage.CC.Add(item);
            }
            foreach (var item in toMails.ListEmailBcc)
            {
                mailMessage.Bcc.Add(item);
            }
       
            return mailMessage;
        }
    }
}
