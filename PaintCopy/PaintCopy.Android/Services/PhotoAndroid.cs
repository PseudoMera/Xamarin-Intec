using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using PaintCopy.Droid.Services;
using PaintCopy.Services;
using Xamarin.Forms;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(PhotoAndroid))]

namespace PaintCopy.Droid.Services
{
    public class PhotoAndroid : IPhoto
    {
        public Task<System.IO.Stream> PickPhotoAsync()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<System.IO.Stream>();

            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }

        public async Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            try
            {
                File picturesDirectory = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures);
                File folderDirectory = picturesDirectory;

                if (!string.IsNullOrEmpty(folder))
                {
                    folderDirectory = new File(picturesDirectory, folder);
                    folderDirectory.Mkdirs();
                }

                using (File bitmapFile = new File(folderDirectory, filename))
                {
                    bitmapFile.CreateNewFile();

                    using (FileOutputStream outputStream = new FileOutputStream(bitmapFile))
                    {
                        await outputStream.WriteAsync(data);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}