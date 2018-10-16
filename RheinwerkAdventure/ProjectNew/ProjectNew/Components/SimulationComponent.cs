using System;
using System.Linq;
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

			Area area = new Area(2, 30, 20);
			for (int x = 0; x < area.Width; x++)
			{
				for (int y = 0; y < area.Height; y++)
				{
					area.Layers[0].Tiles[x, y] = new Tile();
					area.Layers[1].Tiles[x, y] = new Tile();

					if (x == 0 || y == 0 || x == area.Width - 1 || y == area.Height - 1)
						area.Layers[0].Tiles[x, y].Blocked = true;
				}
			}
            
			Player = new Player() { Position = new Vector2(15f, 10f), Radius = 0.25f };
			Diamond diamond = new Diamond() { Position = new Vector2(20f, 10f), Radius = 0.25f };
            
			area.Items.Add(Player);
			area.Items.Add(diamond);

			World.Areas.Add(area);
		}

		public override void Update(GameTime gameTime)
		{
			#region Player Input 

			Player.Velocity = game.Input.Movement * 10f;

			#endregion

			#region Character Movement

			foreach (var area in World.Areas)
			{
				foreach (var character in area.Items.OfType<Character>() )
				{
					character.move += character.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

					foreach (var item in area.Items)
					{
						if (item == character)
							continue;
						Vector2 distance = (item.Position + item.move) - (character.Position + character.move);
						float overlap = (item.Radius + character.Radius) - distance.Length();
                        if(overlap > 0f)
						{
							Vector2 resolution = distance * (overlap / distance.Length());
							if(item.Fixed && !character.Fixed)
							{
								// item fixiert
								character.move -= resolution;
							}
							else if(!item.Fixed && character.Fixed)
							{
								// character fixiert
								character.move += resolution;
							}
							else if(!item.Fixed && !character.Fixed)
							{
								// keiner ist fixiert
								float totalMass = item.Mass + character.Mass;
								character.move -= resolution * (item.Mass / totalMass);
								item.move += resolution * (character.Mass / totalMass);
							}
						}
					}
				}

				foreach (var item in area.Items)
				{
					Vector2 position = item.Position + item.move;
					int minCellX = (int)(position.X - item.Radius);
					int maxCellX = (int)(position.X + item.Radius);
					int minCellY = (int)(position.Y - item.Radius);
					int maxCellY = (int)(position.Y + item.Radius);

					for (int x = minCellX; x <= maxCellX; x++)
					{
						for (int y = minCellY; y <= maxCellY; y++)
						{
							if (!area.IsCellBlocked(x, y)) continue;

							if (position.X - item.Radius > x + 1 ||
								position.X + item.Radius < x ||
								position.Y - item.Radius > y + 1 ||
								position.Y + item.Radius < y )
								continue;

						}
					}

					item.Position += item.move;
					item.move = Vector2.Zero;
				}
			}


                
			#endregion
			base.Update(gameTime);
		}
	}
}