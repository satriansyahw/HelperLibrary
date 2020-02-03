using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHelper.MiscClass
{
   public class EmailToList
   {
        public List<string> ListEmailTo { get; set; }
        public List<string> ListEmailCc { get; set; }
        public List<string> ListEmailBcc { get; set; }
    }
    public class EmailAttachment
    {
        public string FileNameWithExt { get; set; }
        public byte[] FileAttachment{ get; set; }
    }
    public class EmailSMTPProperties
    {
        public int SMTPMailPort { get; set; }
        public string SMTPMailHost { get; set; }
    }
    public class EmailOutlookProperties
    {
        public string ExchangeMailServerAddress { get; set; }
        public string ExchangeMailServerUsername { get; set; }
        public string ExchangeMailServerPassword { get; set; }
        public string ExchangeUriService { get; set; }
        public int ExchangeConnectionTimeOut { get; set; }
    }
}
