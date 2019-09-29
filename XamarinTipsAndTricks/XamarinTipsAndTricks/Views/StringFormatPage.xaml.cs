using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTipsAndTricks.ViewModels;

namespace XamarinTipsAndTricks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StringFormatPage : ContentPage
    {
        public StringFormatPage()
        {
            InitializeComponent();
            BindingContext = new StringFormatPageViewModel(); 
        }
    }
}