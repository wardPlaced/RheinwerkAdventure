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
			GraphicsDevice.Clear(Color.Black);

			int width = GraphicsDevice.Viewport.Width - 20;
			int height = GraphicsDevice.Viewport.Height -20;

			spriteBatch.Begin();
			//spriteBatch.Draw(star, game.Simulation.Position, Color.White);

			spriteBatch.Draw(pixel, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, 10), Color.DarkGray);
			spriteBatch.Draw(pixel, new Rectangle(0, GraphicsDevice.Viewport.Height - 10, GraphicsDevice.Viewport.Width, 10), Color.DarkGray);
			spriteBatch.Draw(pixel, new Rectangle(0, 0, 10, GraphicsDevice.Viewport.Height), Color.DarkGray);
			spriteBatch.Draw(pixel, new Rectangle(GraphicsDevice.Viewport.Width - 10, 0, 10, GraphicsDevice.Viewport.Height), Color.DarkGray);

			int playerRadius = (int)(game.Simulation.PlayerSize * height) / 2;
			int player = (int)(height * game.Simulation.PlayerPosition) + 10;
			spriteBatch.Draw(pixel, new Rectangle(11, player, 10, playerRadius * 2), Color.DarkGray);

			spriteBatch.Draw(pixel, new Rectangle((int)(game.Simulation.BallPosition.X * width + 10), (int)(game.Simulation.BallPosition.Y * height + 10), 10, 10), Color.White);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
