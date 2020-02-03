using EmailHelper.EmailClient;
using EmailHelper.MiscClass;

namespace EmailHelper.EmailMessage
{
    public class CreateOutlookMessage : IMailMessage
    {
        /*Before call functions this this class function , make sure you have validated the mailto,maillcc,mailbcc or  to emails
         * , you can call methode ValidationSendMail.GetInstance.ValidateSendMail*/
        private static CreateOutlookMessage instance;
        public static CreateOutlookMessage GetInstance
        {
            get
            {
                if (instance == null) instance = new CreateOutlookMessage();
                return instance;
            }
        }
        public object CreateMessage(string fromMail, string mailSubject, string mailBody,bool isBodyHTML, string toMail)
        {
            Microsoft.Exchange.WebServices.Data.ExchangeService service = new Microsoft.Exchange.WebServices.Data.ExchangeService();
            service = ClientOutlookSvcPoint.GetInstance.CreateExchangeService();

            Microsoft.Exchange.WebServices.Data.EmailMessage message = new Microsoft.Exchange.WebServices.Data.EmailMessage(service);
            int maxLengthMailSubject = EmailProperties.GetInstance.MailSubjectMaxLength;
            mailSubject = mailBody.Length > maxLengthMailSubject
             ? mailSubject.Substring(0, maxLengthMailSubject) + "...." : mailSubject;
            message.Subject = mailSubject;
            message.ToRecipients.Add(toMail);
            Microsoft.Exchange.WebServices.Data.MessageBody messageBody = new Microsoft.Exchange.WebServices.Data.MessageBody();              
            messageBody.BodyType = isBodyHTML?Microsoft.Exchange.WebServices.Data.BodyType.HTML: Microsoft.Exchange.WebServices.Data.BodyType.Text;
            messageBody.Text = mailBody;
            return message;
        }

        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
            message.CcRecipients.Add(toCC.Trim());
            return message;
        }
        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC,string toBCC)
        {
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
            message.BccRecipients.Add(toBCC.Trim());
            return message;
        }

        public object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            string emailTo = toMails.ListEmailTo[0].Trim();
            Microsoft.Exchange.WebServices.Data.EmailMessage message = (Microsoft.Exchange.WebServices.Data.EmailMessage)
                this.CreateMessage(fromMail, mailSubject, mailBody, isBodyHTML, emailTo);
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
