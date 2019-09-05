using ContactsManager.Models;
using ContactsManager.Views;
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

       public static async void MoreMenuValidator(this string result, Contact param)
        {
            if (result.Equals($"Call +{param.PhoneNumber}"))
            {
                if (!string.IsNullOrEmpty(param.PhoneNumber))
                    Device.OpenUri(new Uri(String.Format("tel: {0}", $"{param.PhoneNumber}")));
             
            }
            else if (result.Equals($"Email {param.Email}"))
            {
                if (!string.IsNullOrEmpty(param.Email))
                    Device.OpenUri(new Uri(String.Format("mailto: {0}", $"{param.Email}")));
                else
                    await App.Current.MainPage.DisplayAlert("Error", "This contact does not have an email", "Ok");
            }
            else if (result.Equals($"Message +{param.PhoneNumber}"))
            {
                if(!string.IsNullOrEmpty(param.PhoneNumber))
                    Device.OpenUri(new Uri(String.Format("sms: {0}", $"{param.PhoneNumber}")));

            }
           
        }

        public static string AddValidator(this string result, Contact contact)
        {
            if(string.IsNullOrEmpty(contact.FirstName))
            {
                return "You need to enter a name";
            }
            else if(string.IsNullOrEmpty(contact.PhoneNumber))
            {
                return "You need to enter a phone number";
            }
            else if(contact.PhoneNumber.Length != 10)
            {
                return "Your phone number needs to have 10 digits";
            }
            else
            {
                return string.Empty;
            }

        }
    }
}
