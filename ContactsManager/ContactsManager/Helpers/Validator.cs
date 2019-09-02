using ContactsManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContactsManager.Helpers
{
    public static class Validator
    {
        public static string RegisterValidator(this string text, Account account, string confirmPassword)
        {
            if (string.IsNullOrEmpty(account.Name))
            {

                return "You have to enter a valid name";
            }
            else if (string.IsNullOrEmpty(account.Email))
            {
                return "You have to enter a valid email";
            }
            else if (string.IsNullOrEmpty(account.Password))
            {
                return "You have to enter a valid password";
            }      
            else if (!account.Password.Equals(confirmPassword))
            {
                return "Your passwords do not match";
            }
            else
            {
                return string.Empty;
            }
        }

        public static string LoginValidator(this string text, Account account)
        {
            if (string.IsNullOrEmpty(account.Email))
            {
                return "You have to enter a valid email";
            }
            else if (string.IsNullOrEmpty(account.Password))
            {
                return "You have to enter a valid password";
            }          
            else
            {
                return string.Empty;
            }
        }

        public static void MoreMenuValidator(this string result, Contact param)
        {
            if (result.Equals($"Call +{param.PhoneNumber}"))
            {
                Device.OpenUri(new Uri(String.Format("tel: {0}", $"{param.PhoneNumber}")));
            }
            else if (result.Equals($"Email {param.Email}"))
            {
                Device.OpenUri(new Uri(String.Format("mailto: {0}", $"{param.Email}")));
            }
            else if (result.Equals($"Message +{param.PhoneNumber}"))
            {
                Device.OpenUri(new Uri(String.Format("sms: {0}", $"{param.PhoneNumber}")));

            }
            else if (result.Equals("Edit"))
            {

            }
        }
    }
}
