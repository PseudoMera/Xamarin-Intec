using PaintCopy.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaintCopy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CanvasPage : ContentPage
    {
        public Dictionary<Xamarin.Forms.Color, SKColor> ColorDictionary { get; set; }
        public Button RealButton { get; set; } = new Button();

        SKImage myImage = null;

        public CanvasPage()
        {
            InitializeComponent();

            ColorDictionary = new Dictionary<Color, SKColor>();
            ColorDictionary.Add(Color.Red, SKColors.Red);
            ColorDictionary.Add(Color.Blue, SKColors.Blue);
            ColorDictionary.Add(Color.Green, SKColors.Green);
            ColorDictionary.Add(Color.Yellow, SKColors.Yellow);
            ColorDictionary.Add(Color.Black, SKColors.Black);
            ColorDictionary.Add(Color.DeepPink, SKColors.DeepPink);
            RealButton.BackgroundColor = Color.Green;
        }

        // private List<SKPath> paths = new List<SKPath>();
        private List<Color> MyColors = new List<Color>();
        private LinkedList<SKPath> paths = new LinkedList<SKPath>();
        private LinkedList<SKPath> trackChanges = new LinkedList<SKPath>();

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);
            int index = 0;

            //Roniel me dio un hint, muchas gracias!
            if(libraryBitmap != null)
            {
                canvas.DrawBitmap(libraryBitmap,
                 new SKRect(0, 0, info.Width,info.Height ));
            }

            foreach (var touchPath in paths)
            {
                Color color = MyColors[index];
                var stroke = new SKPaint
                {
                    Color = ColorDictionary[color],
                    StrokeWidth = 5,
                    Style = SKPaintStyle.Stroke
                };
                canvas.DrawPath(touchPath, stroke);
                index++;
            }
            myImage = surface.Snapshot();

        }

        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        private SKBitmap libraryBitmap;

        private void OnTouch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    MyColors.Add(RealButton.BackgroundColor);
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.AddLast(temporaryPaths[e.Id]);
                    temporaryPaths.Remove(e.Id);
                    break;
            }

            e.Handled = true;

            // update the UI on the screen
            ((SKCanvasView)sender).InvalidateSurface();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            RealButton.BackgroundColor = myButton.BackgroundColor;
        }

        private async void ClearClicked(object sender, EventArgs e)
        {

            var option = await App.Current.MainPage.DisplayActionSheet("Warning", "Cancel", "DO IT!");
            if (option == "Cancel") return;

            trackChanges.Clear();
            MyColors.Clear();
            paths.Clear();
            PaintCopy.InvalidateSurface();

        }

        private async void ImageClicked(object sender, EventArgs e)
        {

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission>();

            if (status != PermissionStatus.Granted)
            {

                status = await CrossPermissions.Current.RequestPermissionAsync<StoragePermission>();
            }

            if (status == PermissionStatus.Granted)
            {                       

                PaintCopy.InvalidateSurface();

                SKData data = myImage.Encode(SKEncodedImageFormat.Png, 100);
                DateTime dt = DateTime.Now;
                string filename = String.Format("FingerPaint-{0:D4}{1:D2}{2:D2}-{3:D2}{4:D2}{5:D2}{6:D3}.png",
                                                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

                IPhoto photoLibrary = DependencyService.Get<IPhoto>();
                bool result = await photoLibrary.SavePhotoAsync(data.ToArray(), "FingerPaint", filename);

                if (!result)
                {
                    await DisplayAlert("FingerPaint", "Artwork could not be saved. Sorry!", "OK");
                }


            }
        }

            private async void UndoClick(object sender, EventArgs e)
            {
                try
                {
                    var node = paths.Last;
                    paths.Remove(paths.Last);
                    trackChanges.AddLast(node);
                    PaintCopy.InvalidateSurface();
                }
                catch (ArgumentException ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "There is nothing to undo!", "Ok");
                }

            }

            private async void RedoClick(object sender, EventArgs e)
            {
                try
                {
                    var node = trackChanges.Last;
                    trackChanges.Remove(trackChanges.Last);
                    paths.AddLast(node);
                    PaintCopy.InvalidateSurface();
                }
                catch (ArgumentNullException ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "There is nothing to redo", "Ok");
                }
            }

        private async void PickClick(object sender, EventArgs e)
        {
          
                IPhoto photoLibrary = DependencyService.Get<IPhoto>();

                using (Stream stream = await photoLibrary.PickPhotoAsync())
                {
                    if (stream != null)
                    {
                        libraryBitmap = SKBitmap.Decode(stream);
                        PaintCopy.InvalidateSurface();
                    }
                }
            
        }
    }
  }

