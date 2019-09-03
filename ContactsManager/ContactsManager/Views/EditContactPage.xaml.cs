using ContactsManager.Models;
using ContactsManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(Contact contact)
        {
            InitializeComponent();
            this.BindingContext = new EditContactPageViewModel(contact);
        }
    }
}