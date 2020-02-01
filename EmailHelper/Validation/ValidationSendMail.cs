using System;
using System.Collections.Generic;
using System.Text;
using EmailHelper.MiscClass;
using EmailHelper.Properties;

namespace EmailHelper.Validation
{
    public class ValidationSendMail : IValidationSendMail
    {
        /*note this function not check mail subject & mail body, if neeeded you can add it*/
        MailReturnValue result = new MailReturnValue();
        private static ValidationSendMail instance;
        public static ValidationSendMail GetInstance
        {
            get
            {
                if (instance == null) instance = new ValidationSendMail();
                return instance;
            }
        }
        public MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, string toMail)
        {
            bool IsGoodFromMail = ValidationEmail.GetInstance.ValidateEmail(fromMail);
            if (!IsGoodFromMail)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailFrom);
                return result;
            }
            bool isGoodToMail = ValidationEmail.GetInstance.ValidateEmail(toMail);
            if (!isGoodToMail)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailTo);
                return result;
            }
            if(string.IsNullOrEmpty(mailBody) || string.IsNullOrWhiteSpace(mailBody))
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailBody);
                return result;
            }
            if (string.IsNullOrEmpty(mailSubject) || string.IsNullOrWhiteSpace(mailSubject))
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailSubject);
                return result;
            }
            result = result.SetMailReturnValue(true, string.Empty);
            return result;
        }

        public MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, string toMail, string toCC)
        {
            result = this.ValidateSendMail(fromMail, mailSubject, mailBody, toMail);
            if(result.IsSuccessMail)
            {
                bool IsGoodCCMail = ValidationEmail.GetInstance.ValidateEmail(toCC);
                if (!IsGoodCCMail)
                {
                    result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailCC);
                    return result;
                }

            }
            return result;
        }

        public MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, string toMail, string toCC, string toBCC)
        {
            result = this.ValidateSendMail(fromMail, mailSubject, mailBody, toMail,toCC);
            if (result.IsSuccessMail)
            {
                bool IsGoodBCCMail = ValidationEmail.GetInstance.ValidateEmail(toBCC);
                if (!IsGoodBCCMail)
                {
                    result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailBCC);
                    return result;
                }

            }
            return result;
        }

        public MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, EmailToList toMails)
        {
            if (toMails == null)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongEmailToListNull); return result;
            }
            if (toMails.ListEmailTo == null & toMails.ListEmailCc == null & toMails.ListEmailBcc == null)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongEmailToListNull);
            }
            if(toMails.ListEmailTo.Count + toMails.ListEmailCc.Count + toMails.ListEmailBcc.Count ==0)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongEmailToListNull);
            }
            bool isGoodToMail = ValidationEmail.GetInstance.ValidateEmail(toMails.ListEmailTo.ToArray());
            if (!isGoodToMail)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailTo);
                return result;
            }
            bool isGoodCCMail = ValidationEmail.GetInstance.ValidateEmail(toMails.ListEmailCc.ToArray());
            if (!isGoodCCMail)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailCC);
                return result;
            }
            bool isGoodBCCMail = ValidationEmail.GetInstance.ValidateEmail(toMails.ListEmailBcc.ToArray());
            if (!isGoodBCCMail)
            {
                result = result.SetMailReturnValue(false, EmailProperties.GetInstance.WrongMailBCC);
                return result;
            }
            result = result.SetMailReturnValue(true, string.Empty);
            return result;
        }
    }
    

}