using EmailHelper.EmailSend;
using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;

namespace EmailHelper
{
    public class EmailWrapper: IEmailSend
    {
        IEmailSend emailSend = null;

        public EmailWrapper(EmailSMTPProperties properties)
        {
            emailSend = new SMTPEmailSend(properties);
        }
        public EmailWrapper(EmailOutlookProperties properties)
        {
            emailSend = new OutlookEmailSend(properties);
        }
        public EmailWrapper()
        {
            //default, using default conf
            emailSend = new SMTPEmailSend();
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,emailAttachments);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments,sizeLimit);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments, sizeLimit);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments, sizeLimit);
        }

        public MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmail(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments, sizeLimit);
        }
    }
}
