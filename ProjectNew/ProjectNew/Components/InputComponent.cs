using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjectNew
{
	internal class InputComponent : GameComponent
	{
		public Vector2 Movement
		{
			get;
			private set;
		}

		public InputComponent(RheinwerkAdventure game) : base(game)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			Vector2 movement = Vector2.Zero;
			movement += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left * new Vector2(1f, -1f);

			KeyboardState keyboard = Keyboard.GetState();
			if (keyboard.IsKeyDown(Keys.Left))
				movement += new Vector2(-1f, 0f);
			if (keyboard.IsKeyDown(Keys.Right))
				movement += new Vector2(1f, 0f);
			if (keyboard.IsKeyDown(Keys.Up))
				movement += new Vector2(0f, 1f);
			if (keyboard.IsKeyDown(Keys.Down))
				movement += new Vector2(1f, 0f);

			if (movement.Length() > 1f)
				movement.Normalize();

			Movement = movement;

			base.Update(gameTime);
		}
	}
}
