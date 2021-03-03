using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		private readonly Pixel[,] data;

        public Photo(int inWidth, int inHeight)
        {
            width = inWidth;
            height = inHeight;
            data = new Pixel[width,height];
        }

        public Pixel this[int x, int y]
        {
            get => data[x, y];
            set => data[x, y] = value;
        }
    }
}

