using DependencyOrientationService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DependencyOrientationService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceOrientationPage : ContentPage
    {
        public DeviceOrientationPage()
        {
            InitializeComponent();
            this.BindingContext = new DeviceOrientationPageViewModel();
        }
    }
}