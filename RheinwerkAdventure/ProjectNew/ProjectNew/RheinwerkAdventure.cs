﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectNew
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	internal class RheinwerkAdventure : Game
	{
		GraphicsDeviceManager graphics;

		public InputComponent Input
		{
			get;
			private set;
		}

		public SceneComponent Scene
		{
			get;
			private set;
		}

		public SimulationComponent Simulation
		{
			get;
			private set;
		}

		public RheinwerkAdventure()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			Input = new InputComponent(this);
			Input.UpdateOrder = 0;
			Components.Add(Input);

			Scene = new SceneComponent(this);
			Scene.UpdateOrder = 2;
			Scene.DrawOrder = 0;
			Components.Add(Scene);

			Simulation = new SimulationComponent(this);
			Simulation.UpdateOrder = 1;
			Components.Add(Simulation);
		}
		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}
	}
}
