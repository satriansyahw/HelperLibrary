# EmailHelper version 1.0.0

## Minimum Requirement For Installation  
   1.TargetFramework netcoreapp 2.1 </br>
   2.Microsoft.CodeAnalysis 3.4.0 </br>
   3.Microsoft.Exchange.WebServce 2.2.0 </br>

## How To Use
	1. Instance your desired EmailWraper ,ex: var emailWrapper = new EmailWrapper(). </br>
	var hasil = emailWrapper.SendMail('','',...)
	2. Parameters needed, emailfrom,emailto,subject,body or attachment

## Return Value (MailReturnValue)
	1.IsSuccessMail ,true if success
    2.ErrorMessage ,will empty if success and throw message when false

## Functions
	1. For Sending emails using SMTP Client and Outlook Exchange server
	2. You Can access from Email Wrapper ( normal,async,thread)
	3. This helper will check valid email and valid attachment

## Wrapper
	1.EmailWrapper
	2.EmailWrapperAsync
	3.EmailWrapperThread

## List Of available methods (IMailSend)
	1.MailReturnValue SendEmail(string fromMail,string mailSubject, string mailBody, bool isBodyHTML,string toMail);
    2.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC);
    3.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC,string toBCC);
    4.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    5.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
    6.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
    7.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
    8.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);
    9.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
    10.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    11.MailReturnValue SendEmail(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    12.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

## List Of available methods (IMailSendAsync)
	1.MailReturnValue SendEmailAsync(string fromMail,string mailSubject, string mailBody, bool isBodyHTML,string toMail);
    2.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC);
    3.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC,string toBCC);
    4.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    5.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
    6.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
    7.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
    8.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);
    9.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
    10.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    11.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    12.MailReturnValue SendEmailAsync(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

## List Of available methods (IMailSendThread)
	1.MailReturnValue SendEmailThread(string fromMail,string mailSubject, string mailBody, bool isBodyHTML,string toMail);
    2.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC);
    3.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail,string toCC,string toBCC);
    4.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails);
    5.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments);
    6.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments);
    7.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments);
    8.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments);
    9.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, List<EmailAttachment> emailAttachments, int sizeLimit);
    10.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    11.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, string toMail, string toCC, string toBCC, List<EmailAttachment> emailAttachments, int sizeLimit);
    12.MailReturnValue SendEmailThread(string fromMail, string mailSubject, string mailBody, bool isBodyHTML, EmailToList toMails, List<EmailAttachment> emailAttachments, int sizeLimit);

# HAPPYCoding
contact me at satriansyahw@gmail.com




	   
