using System;

namespace ProjectNew
{
	public class Layer
	{
		public Tile[,] Tiles
        {
            get;
            private set;
        }

		public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

		public Layer(int width, int height)
		{
			Width = width;
			Height = height;

			Tiles = new Tile[width, height];
		}
	}
}