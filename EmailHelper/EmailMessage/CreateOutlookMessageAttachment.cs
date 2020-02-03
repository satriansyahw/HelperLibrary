using EmailHelper.MiscClass;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace EmailHelper.EmailMessage
{
    public class CreateOutlookMessageAttachment : IMailMessageWithAttachment
    {
        /*Before call functions this this class function , make sure you have validated the mailto,maillcc,mailbcc or  to emails
         * , you can call methode ValidationSendMail.GetInstance.ValidateSendMail*/

        private static CreateOutlookMessageAttachment instance;
        public static CreateOutlookMessageAttachment GetInstance
        {
            get
            {
                if (instance == null) instance = new CreateOutlookMessageAttachment();
                return instance;
            }
        }
        private Microsoft.Exchange.WebServices.Data.EmailMessage  AddMessageAttachment(Microsoft.Exchange.WebServices.Data.EmailMessage message, List<EmailAttachment> emailAttachments)
        {
            if (emailAttachments != null)
            {
                foreach (var item in emailAttachments)
                {
                    Attachment attachment = new Attachment(new MemoryStream(item.FileAttachment), item.FileNameWithExt);
                    message.Attachments.AddFileAttachment(item.FileNameWithExt, new MemoryStream(item.FileAttachment));
                }
            }
            return message;
        }
        public object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            CreateOutlookMessage CreateMail = new CreateOutlookMessage();
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)CreateMail.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            message = this.AddMessageAttachment(message, emailAttachments);
            return message;
        }
        public object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                this.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments);
            message.CcRecipients.Add(toCC.Trim());
            return message;
        }
        public object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
             Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                this.CreateMessageWithAttachment(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments);
            message.BccRecipients.Add(toBCC.Trim());
            return message;
        }
        public object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            string emailTo = toMails.ListEmailTo[0].Trim();
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)this.CreateMessageWithAttachment(fromMail.Trim(), mailSubject, mailBody, isBodyHTML, emailTo, emailAttachments);
            for (int i = 1; i < toMails.ListEmailTo.Count; i++)
            {
                message.ToRecipients.Add(toMails.ListEmailTo[i]);
            }
            foreach (var item in toMails.ListEmailCc)
            {
                message.CcRecipients.Add(item);
            }
            foreach (var item in toMails.ListEmailBcc)
            {
                message.BccRecipients.Add(item);
            }
            return message;
        }


    }
}
