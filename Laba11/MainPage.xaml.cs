using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Laba11
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private const int NodeCount = 200;
        public MainPage()
        {
            this.InitializeComponent();

			var rnd = new Random();

			var x = rnd.Next((int)Window.Current.Bounds.Width);
			var y = rnd.Next((int)Window.Current.Bounds.Height);
			
			for (int i = 0; i < NodeCount; i++)
			{
				var points = new PointCollection();
				var polyline1 = new Polyline();
				polyline1.StrokeThickness = 4;

				points.Add(new Point(x, y));
				var brush = new SolidColorBrush(Color.FromArgb(255, (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));

				x = rnd.Next((int)Window.Current.Bounds.Width);
				y = rnd.Next((int)Window.Current.Bounds.Height);
				points.Add(new Point(x, y));

				polyline1.Stroke = brush;

				polyline1.Points = points;

				RootCanvas.Children.Add(polyline1);
			}
		}
    }
}
