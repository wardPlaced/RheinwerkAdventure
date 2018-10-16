using System;
using Microsoft.Xna.Framework;
using ProjectNew.Model;

namespace ProjectNew
{
	public class Item : ICollidable
	{
		public float Mass { get; set; }
        public bool Fixed { get; set; }

		internal Vector2 move = Vector2.Zero;

		public Vector2 Position
		{
			get;
			set;
		}
        
		public float Radius
		{
			get;
			set;
		}
			
		public Item()
		{
			Fixed = false;
			Mass = 1f;
		}
	}
}
