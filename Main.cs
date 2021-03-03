using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter(new PixelFilter<LightningParameters>(
                "����������/����������",
				(pixel, parameters)=>pixel * parameters.Coefficient
                ));
			window.AddFilter(new PixelFilter<EmptyParameters>(
                "������� ������.",
                (pixel, parameters) =>
                {
                    var lightness = pixel.R + pixel.G + pixel.B;
                    lightness /= 3;
                    return new Pixel(lightness, lightness, lightness);
				}));
			window.AddFilter(new TransformFilter(
                "�������� �� �����������.",
				size=>size,
				(point, size) => new Point(size.Width-point.X-1, point.Y)
                ));
			window.AddFilter(new TransformFilter(
                "������� ������ �. �.",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(point.Y, point.X)
                ));
			Application.Run (window);
		}
	}
}
