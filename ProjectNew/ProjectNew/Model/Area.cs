using System;
using System.Collections.Generic;

namespace ProjectNew
{
	public class Area
	{
		public Tile[,] Tiles
		{
			get;
			private set;
		}

		public List<Item> Items
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

		public Area(int width, int height)
		{
			Tiles = new Tile[width, height];
			Width = width;
			Height = height;

			Items = new List<Item>();
		}
	}
}
