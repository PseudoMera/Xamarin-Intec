using ContactsManager.Models;
using ContactsManager.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsManager.ViewModels
{
    class AddContactPageViewModel
    {
        public Contact contact { get; set; } = new Contact();
        public ICommand AddCommand { get; set; }
        public ICommand TakePhotoClicked { get; set; }
        public AddContactPageViewModel()
        {
            TakePhotoClicked = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

                contact.Photo = file.Path;
            });

            AddCommand = new Command(async () =>
            {
                MessagingCenter.Send(this, "CreateContact", contact);
                await App.Current.MainPage.Navigation.PopAsync();
                //await App.Current.MainPage.Navigation.PushAsync(new ContactsListPage());
            });

          

        }

      
    }
}
