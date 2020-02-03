using EmailHelper.MiscClass;
using System.Net.Mail;


namespace EmailHelper.EmailMessage
{
    public class CreateSMTPMessage:IMailMessage
    {
        /*Before call functions this this class function , make sure you have validated the mailto,maillcc,mailbcc or  to emails
         * , you can call methode ValidationSendMail.GetInstance.ValidateSendMail*/
        private static CreateSMTPMessage instance;
        public static CreateSMTPMessage GetInstance
        {
            get
            {
                if (instance == null) instance = new CreateSMTPMessage();
                return instance;
            }
        }
        public object CreateMessage(string fromMail, string mailSubject, string mailBody,bool isBodyHTML, string toMail)
        {         
            MailMessage mailMessage = new MailMessage(fromMail.Trim(), toMail.Trim());
            int maxLengthMailSubject = EmailProperties.GetInstance.MailSubjectMaxLength;
            mailSubject = mailBody.Length > maxLengthMailSubject
                ? mailSubject.Substring(0, maxLengthMailSubject) + "...." : mailSubject;
            mailMessage.IsBodyHtml = isBodyHTML;
            mailMessage.Subject = mailSubject;
            mailMessage.Body = mailBody;
            return mailMessage;
        }

        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            MailMessage mailMessage = (MailMessage)this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            mailMessage.CC.Add(toCC.Trim());
            return mailMessage;
        }
        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC,string toBCC)
        {
            MailMessage mailMessage = (MailMessage)this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
            mailMessage.Bcc.Add(toBCC.Trim());
            return mailMessage;
        }

        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            string emailTo = toMails.ListEmailTo[0].Trim();
            MailMessage mailMessage = (MailMessage)this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, emailTo);
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
