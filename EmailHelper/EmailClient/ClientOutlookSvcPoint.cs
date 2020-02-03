using EmailHelper.MiscClass;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Net;


namespace EmailHelper.EmailClient
{
    public class ClientOutlookSvcPoint:IOutlookServicePoint
    {
        private static ClientOutlookSvcPoint instance;
        public static ClientOutlookSvcPoint GetInstance
        {
            get
            {
                if (instance == null) instance = new ClientOutlookSvcPoint();
                return instance;
            }
        }

        public bool CertificateValidationCallBack(object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                return true;

            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) && (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                            continue;
                        else
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            return false;
                    }
                }
                return true;
            }
            else
                return false;
        }

        public ExchangeService CreateExchangeService()
        {
            ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidationCallBack;
            Microsoft.Exchange.WebServices.Data.ExchangeService service = new Microsoft.Exchange.WebServices.Data.ExchangeService();
            service.Credentials = new Microsoft.Exchange.WebServices.Data.WebCredentials(EmailProperties.GetInstance.ExchangeMailServerUsername, EmailProperties.GetInstance.ExchangeMailServerPassword);
            service.Url = new Uri(EmailProperties.GetInstance.ExchangeUriService);
            service.Timeout = EmailProperties.GetInstance.ExchangeConnectionTimeout;
            return service;
        }
    }
}
