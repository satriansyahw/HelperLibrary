using System;
using System.Collections.Generic;
using System.Text;

namespace EmailHelper.MiscClass
{
    public class MailReturnValue
    {
        public bool IsSuccessMail { get; set; }
        public string ErrorMessage { get; set; }
        public MailReturnValue SetMailReturnValue(bool IsSuccessMail,string ErrorMessage)
        {
            MailReturnValue result = new MailReturnValue();
            result.IsSuccessMail = IsSuccessMail;
            result.ErrorMessage = ErrorMessage;
            return result;
        }
    }
}
