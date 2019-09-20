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

        private List<SKPath> paths = new List<SKPath>();
        private List<Color> MyColors = new List<Color>();
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);
            int index = 0;
           
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
        }

        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
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
                    paths.Add(temporaryPaths[e.Id]);
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

        private void ClearClicked(object sender, EventArgs e)
        {

            MyColors.Clear();
            paths.Clear();
            //I think we can use this x name to work around the mvvm
            PaintCopy.InvalidateSurface();
            
        }

        private void ImageClicked(object sender, EventArgs e)
        {
            PaintCopy.PaintSurface += (s, ee) =>
            {
                SKImage myImage = ee.Surface.Snapshot();
                SKData encodedImage = myImage.Encode(SKEncodedImageFormat.Png, 100);

            };

            PaintCopy.InvalidateSurface();
        }
    }
}