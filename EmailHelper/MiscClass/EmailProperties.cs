using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHelper.MiscClass
{
    public class EmailProperties
    {
        private static EmailProperties instance;
        public static EmailProperties GetInstance
        {
            get
            {
                if (instance == null) instance = new EmailProperties();
                return instance;
            }
        }
        public  int EmailAttachmentSize = 10  * 1024 * 1000;//in MB 
        public int MailSubjectMaxLength = 150;//in MB 
        public string WrongMailTo = "Wrong mail to, please re-check again";//
        public string WrongMailCC = "Wrong mail CC, please re-check again";//
        public string WrongMailBCC = "Wrong mail BCC, please re-check again";//
        public string WrongMailFrom = "Wrong mail from, please re-check again";//
        public string WrongEmailToListNull = "EmailToList cannot be null, please re-check again";//
        public string WrongMailBody = "Wrong mail body, cannot empty";//in MB 
        public string WrongMailSubject = "Wrong mail subject, cannot empty";//
        public string WrongMailMessageNull = "Error MailMessage, cannot null";//
        public string WrongAttachment= "Wromg mail attachment, please check attachment file and it's size ";//

        public string SMTPMailHost = "mx.apo.epson.net";
        public int SMTPMailPort = 25;

        public string ExchangeMailServerAddress = @"papua.system@sep.epson.com.sg";
        public string ExchangeMailServerUsername = @"papua.system@sep.epson.com.sg";
        public string ExchangeMailServerPassword = @"pebisdghelov";
        public string ExchangeUriService = @"https://outlook.office365.com/EWS/Exchange.asmx";
        public int ExchangeConnectionTimeout = 300000;
    }
    
}
