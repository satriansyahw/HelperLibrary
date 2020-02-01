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
}
