using System.Collections.Generic;
using EmailHelper.MiscClass;

namespace EmailHelper.Validation
{
    public class ValidationAtttachment : IValidationAttachment
    {
        MailReturnValue result = new MailReturnValue();
        private static ValidationAtttachment instance;
        public static ValidationAtttachment GetInstance
        {
            get
            {
                if (instance == null) instance = new ValidationAtttachment();
                return instance;
            }
        }
        public MailReturnValue ValidateAttachment(List<EmailAttachment> emailAttachments)
        {
            int emailLimit = EmailProperties.GetInstance.EmailAttachmentSize;
            int totLimit = 0;
            foreach (var item in emailAttachments)
            {
                totLimit += item.FileAttachment.Length;
            }
            if (totLimit < emailLimit)
            {
                result = result.SetMailReturnValue(true, string.Empty);
            }
            else
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongAttachment+" Max Size : "+ EmailProperties.GetInstance.EmailAttachmentSize.ToString());
            }
            return result;
        }

        public MailReturnValue ValidateAttachment(List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            int emailLimit = sizeLimit;
            int totLimit = 0;
            foreach (var item in emailAttachments)
            {
                totLimit += item.FileAttachment.Length;
            }
            if (totLimit < emailLimit)
            {
                result = result.SetMailReturnValue(true, string.Empty);
            }
            else
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongAttachment + " Max Size : " + sizeLimit.ToString());

            }
            return result;
        }

       
    }
}
