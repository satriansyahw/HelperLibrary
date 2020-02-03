using EmailHelper.EmailSend;
using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;

namespace EmailHelper
{
    public class EmailWrapperThread : IEmailSendThread
    {
        IEmailSendThread emailSend = null;

        public EmailWrapperThread(EmailSMTPProperties properties)
        {
            emailSend = new SMTPEmailSendThread(properties);
        }
        public EmailWrapperThread(EmailOutlookProperties properties)
        {
            emailSend = new OutlookEmailSendThread(properties);
        }
        public EmailWrapperThread()
        {
            //default, using default conf
            emailSend = new SMTPEmailSendThread();
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMails);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,emailAttachments);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail, emailAttachments,sizeLimit);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC, emailAttachments, sizeLimit);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMail,toCC,toBCC, emailAttachments, sizeLimit);
        }

        public MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit)
        {
            return emailSend.SendEmailThread(fromMail, mailSubject, mailBody, isBodyHTML, toMails, emailAttachments, sizeLimit);
        }
    }
}
