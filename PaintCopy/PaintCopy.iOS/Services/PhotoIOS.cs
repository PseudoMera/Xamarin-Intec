using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using PaintCopy.iOS.Services;
using PaintCopy.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoIOS))]
namespace PaintCopy.iOS.Services
{
    public class PhotoIOS : IPhoto
    {
        TaskCompletionSource<Stream> taskCompletionSource;
        UIImagePickerController imagePicker;
        public Task<Stream> PickPhotoAsync()
        {
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);

            taskCompletionSource = new TaskCompletionSource<Stream>();
            return taskCompletionSource.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                NSData data = image.AsJPEG(1);
                Stream stream = data.AsStream();

                taskCompletionSource.SetResult(stream);
            }
            else
            {
                taskCompletionSource.SetResult(null);
            }
            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }
        public Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            NSData nsData = NSData.FromArray(data);
            UIImage image = new UIImage(nsData);
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            image.SaveToPhotosAlbum((UIImage img, NSError error) =>
            {
                taskCompletionSource.SetResult(error == null);
            });

            return taskCompletionSource.Task;
        }
    }
}