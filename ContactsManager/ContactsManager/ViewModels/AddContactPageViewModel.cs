using ContactsManager.Models;
using ContactsManager.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ContactsManager.Helpers;
using System.ComponentModel;

namespace ContactsManager.ViewModels
{
    class AddContactPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Contact contact { get; set; } = new Contact();
        public ICommand AddCommand { get; set; }
        public ICommand TakePhotoClicked { get; set; }

        public ICommand PickPhoto { get; set; }

        public string AddError { get; set; }

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

                contact.Photo = file.Path;
            });

            PickPhoto = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();
                
                if(!CrossMedia.Current.IsPickPhotoSupported)
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

            AddCommand = new Command(async () =>
            {
                AddError = AddError.AddValidator(contact);

                if (AddError.Equals(string.Empty))
                {
                    
                    MessagingCenter.Send(this, "CreateContact", contact);
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
