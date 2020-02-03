using EmailHelper.MiscClass;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHelper.EmailClient
{
    public interface IClientMail
    {
        MailReturnValue SentMail(object mailMessage);
        Task<MailReturnValue> SentMailAsync(object mailMessage);
        void SentMailThread(object mailMessage);
    }
    public interface IOutlookServicePoint
    {
        ExchangeService CreateExchangeService();
        bool CertificateValidationCallBack(object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors);
    }
}