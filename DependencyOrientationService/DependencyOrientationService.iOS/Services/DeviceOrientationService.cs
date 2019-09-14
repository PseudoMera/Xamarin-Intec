using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DependencyOrientationService.iOS.Services;
using DependencyOrientationService.Services;
using Foundation;
using UIKit;
using Xamarin.Forms.Internals;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationService))]
namespace DependencyOrientationService.iOS.Services
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            bool isPortrait = orientation == UIInterfaceOrientation.Portrait ||
                orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}