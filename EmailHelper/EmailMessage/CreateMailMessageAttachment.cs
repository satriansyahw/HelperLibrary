using EmailHelper.MiscClass;
using EmailHelper.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace EmailHelper.EmailMessage
{
    public class CreateMailMessageAttachment : IMailMessageWithAttachment
    {
        /*Before call functions this this class function , make sure you have validated the mailto,maillcc,mailbcc or  to emails
         * , you can call methode ValidationSendMail.GetInstance.ValidateSendMail*/

        private static CreateMailMessageAttachment instance;
        public static CreateMailMessageAttachment GetInstance
        {
            get
            {
                if (instance == null) instance = new CreateMailMessageAttachment();
                return instance;
            }
        }
        private MailMessage AddMessageAttachment(MailMessage message, List<EmailAttachment> emailAttachments)
        {
            if (emailAttachments != null)
            {
                foreach (var item in emailAttachments)
                {
                    Attachment attachment = new Attachment(new MemoryStream(item.FileAttachment), item.FileNameWithExt);
                    message.Attachments.Add(attachment);
                }
            }
            return message;
        }
        public MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            CreateMailMessage CreateMail = new CreateMailMessage();
            MailMessage mailMessage = CreateMail.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            mailMessage = this.AddMessageAttachment(mailMessage, emailAttachments);
            return mailMessage;
        }
        public MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            MailMessage mailMessage = this.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments);
            mailMessage.CC.Add(toCC.Trim());
            return mailMessage;
        }
        public MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
            MailMessage mailMessage = this.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, toCC, emailAttachments);
            mailMessage.Bcc.Add(toBCC.Trim());
            return mailMessage;
        }
        public MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            string emailTo = toMails.ListEmailTo[0].Trim();
            MailMessage mailMessage = this.CreateMessageWithAttachment(fromMail.Trim(), mailSubject, mailBody, isBodyHTML, emailTo, emailAttachments);
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
