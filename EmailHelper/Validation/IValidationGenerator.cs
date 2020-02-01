using EmailHelper.EmailSend;
using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHelper.Validation
{
    public interface IValidationEmail
    {
        bool ValidateEmail(string emailAddress);
        bool ValidateEmail(string[] emailAddresses);
    }
    public interface IValidationAttachment
    {
        MailReturnValue ValidateAttachment(List<EmailAttachment> emailAttachments);
        MailReturnValue ValidateAttachment(List<EmailAttachment> emailAttachments,int sizeLimit);
    }

    public interface IValidationSendMail
    {
        MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody,string toMail);
        MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, string toMail,string toCC);
        MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, string toMail, string toCC,string toBCC);
        MailReturnValue ValidateSendMail(string fromMail, string mailSubject, string mailBody, EmailToList toMails);

    }
}
