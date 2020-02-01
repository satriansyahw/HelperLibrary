using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmailHelper.Validation
{
    public class ValidationEmail : IValidationEmail
    {
        private static ValidationEmail instance;
        public static ValidationEmail GetInstance
        {
            get
            {
                if (instance == null) instance = new ValidationEmail();
                return instance;
            }
        }
        public bool ValidateEmail(string emailAddress)
        {
            bool result = false;
            emailAddress = emailAddress.Trim();
            if (!string.IsNullOrEmpty(emailAddress))
            {
                if (!string.IsNullOrWhiteSpace(emailAddress))
                {
                    result = new EmailAddressAttribute().IsValid(emailAddress);
                }
            }
            return result;
        }
        
        public bool ValidateEmail(string[] emailAddresses)
        {
            bool result = false;
            for (int i = 0; i < emailAddresses.Length; i++)
            {
                if(!string.IsNullOrEmpty(emailAddresses[i]))
                {
                    if(!string.IsNullOrWhiteSpace(emailAddresses[i]))
                    {
                        string email = emailAddresses[i].Trim();
                        result = new EmailAddressAttribute().IsValid(email);
                        if (!result)
                            break;
                    }
                }
                   
            }
            return result;
        }
    }
}
