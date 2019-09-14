using CustomRenderer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomRenderer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomRendererPage : ContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();
            this.BindingContext = new CustomRendererPageViewModel();
        }
    }
}