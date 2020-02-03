using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailHelper.EmailMessage
{
    public interface IMailMessage
    {
        object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC,string toBCC);
        object CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    }
    public interface IMailMessageWithAttachment
    {
        object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        object CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);
    }
}

