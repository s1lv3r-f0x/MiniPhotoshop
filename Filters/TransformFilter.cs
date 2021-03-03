 using System;
 using System.Collections.Generic;
 using System.Drawing;
 using System.Linq;
 using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        private Func<Size, Size> sizeTransform;
        private Func<Point, Size, Point> pointTransform;
        private string name;

        public TransformFilter(string name, Func<Size, Size> sizeTransform, Func<Point, Size, Point> pointTransform)
        {
            this.name = name;
            this.pointTransform = pointTransform;
            this.sizeTransform = sizeTransform;
        }

        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x = 0; x < newSize.Width; x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize);
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }

            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
