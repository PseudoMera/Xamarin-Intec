using PaintClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaintClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CanvasPage : ContentPage
    {
        public CanvasPage()
        {
            InitializeComponent();
            this.BindingContext = new CanvasPageViewModel();
        }
    }
}