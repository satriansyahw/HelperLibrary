using EmailHelper.MiscClass;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHelper.EmailClient
{
    public interface IClientMail
    {
        MailReturnValue SentMail(MailMessage mailMessage);
        Task<MailReturnValue> SentMailAsync(MailMessage mailMessage);
        void SentMailThread(MailMessage mailMessage);
    }
}
