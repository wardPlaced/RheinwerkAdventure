using System;
using Microsoft.Xna.Framework;

namespace ProjectNew
{
	internal class SimulationComponent : GameComponent
	{
		private readonly RheinwerkAdventure game;

		public World World
		{
			get;
			private set;
		}

		public Player Player
		{
			get;
			private set;
		}

		public SimulationComponent(RheinwerkAdventure game) : base(game)
		{
			this.game = game;
			NewGame();
		}

		public void NewGame()
		{
			World = new World();

			Area area = new Area(30, 20);

			for (int x = 0; x < area.Width; x++)
			{
				for (int y = 0; y < area.Height; y++)
				{
					area.Tiles[x, y] = new Tile();
				}
			}

			Player = new Player() { Position = new Vector2(15f, 20f), Radius = 0.25f };
			Diamond diamond = new Diamond() { Position = new Vector2(20f, 20f), Radius = 0.25f };

			area.Items.Add(Player);
			area.Items.Add(diamond);

			World.Areas.Add(area);
		}

		public override void Update(GameTime gameTime)
		{
			
			base.Update(gameTime);
		}
	}
}