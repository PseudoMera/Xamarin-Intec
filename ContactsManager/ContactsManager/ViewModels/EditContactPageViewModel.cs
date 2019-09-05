using ContactsManager.Models;
using ContactsManager.Views;
using ContactsManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using System.ComponentModel;
using ContactsManager.Helpers;

namespace ContactsManager.ViewModels
{
    class EditContactPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Contact MyContact { get; set; } = new Contact();
        public ICommand SaveProfile { get; set; }

        public ICommand PickPhoto { get; set; }

        public ICommand TakePhoto { get; set; }

        public string EditError { get; set; }
        public EditContactPageViewModel(Contact contact)
        {
            MyContact = contact;

            TakePhoto = new Command(async () =>
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


                contact.Photo = file.Path;
            });

            PickPhoto = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                });

                if (file == null)
                    return;

                contact.Photo = file.Path;
            });

            SaveProfile = new Command(async () =>
            {

                EditError = EditError.AddValidator(contact);
                if (EditError.Equals(string.Empty))
                {
                    MessagingCenter.Send(this, "EditContact", MyContact);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
        }

        protected void OnPropertyChanged(string change)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(change));
        }
    }
}
