using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailHelper.EmailMessage
{
    public interface IMailMessage
    {
        MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail);
        MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC);
        MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC,string toBCC);
        MailMessage CreateMessage(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    }
    public interface IMailMessageWithAttachment
    {
        MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
        MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
        MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
        MailMessage CreateMessageWithAttachment(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);
    }
}

