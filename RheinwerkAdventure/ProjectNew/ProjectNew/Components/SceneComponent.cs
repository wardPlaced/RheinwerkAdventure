using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectNew
{
	internal class SceneComponent : DrawableGameComponent
	{
		private SpriteBatch spriteBatch;
		//private Texture2D star;
		private RheinwerkAdventure game;
		private Texture2D pixel;

		public SceneComponent(RheinwerkAdventure game) : base(game)
		{
			this.game = game;
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			//star = game.Content.Load<Texture2D>("starGold");
			pixel = new Texture2D(GraphicsDevice, 1, 1);
			pixel.SetData<Color>(new Color[] { Color.White });
			base.LoadContent();
		}

		public override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			Area area = game.Simulation.World.Areas[0];

			float scaleX = (GraphicsDevice.Viewport.Width - 20) / area.Width;
			float scaleY = (GraphicsDevice.Viewport.Height - 20) / area.Height;

			spriteBatch.Begin();

			for (int x = 0; x < area.Width; x++)
			{
				for (int y = 0; y < area.Height; y++)
				{
					bool blocked = false;
					for (int l = 0; l < area.Layers.Length; l++)
						blocked |= area.Layers[l].Tiles[x, y].Blocked;

					int offsetX = (int) ((x * scaleX) + 10);
					int offsetY = (int) ((y * scaleY) + 10);

					Color color = Color.DarkGreen;
					if (blocked)
						color = Color.DarkRed;
                        
					spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, (int)scaleX, (int)scaleY), color);
					spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, 1, (int)scaleY), Color.Black);
					spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, (int)scaleX, 1), Color.Black);
				}
			}

			foreach (var item in area.Items)
			{
				Color color = Color.Yellow;

				if (item is Player)
					color = Color.Red;

				int posX = (int) ((item.Position.X - item.Radius) * (int)scaleX) + 10;
				int posY = (int) ((item.Position.Y - item.Radius) * (int)scaleY) + 10;
				int size = (int)((item.Radius * 2) * scaleX);

				spriteBatch.Draw(pixel, new Rectangle(posX, posY, size, size), color);
			}

			spriteBatch.End();
		}
	}
}
