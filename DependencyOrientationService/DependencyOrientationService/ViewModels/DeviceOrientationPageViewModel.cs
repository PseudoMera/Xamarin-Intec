using DependencyOrientationService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DependencyOrientationService.ViewModels
{
    public class DeviceOrientationPageViewModel
    {
        DeviceOrientation Orientation { get; set; }
        public string Text { get; set; }
        public DeviceOrientationPageViewModel()
        {
            IDeviceOrientationService service = DependencyService.Get<IDeviceOrientationService>();
            Orientation = service.GetOrientation();
            Text = Orientation.ToString();
        }
    }
}
