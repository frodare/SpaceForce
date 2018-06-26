using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceForce.Desktop.entities;

namespace SpaceForce.Desktop {
	public class SpaceForceGame : Game {

		internal GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		internal Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

		AsteroidPool asteroidPool = new AsteroidPool();
    
		public SpaceForceGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			base.Initialize();
		}

		private void LoadTexture(string name) {
			textures.Add(name, Content.Load<Texture2D>(name));
		}

		private void LoadTextures() {
			LoadTexture("Background/starBackground");
			LoadTexture("player");
			LoadTexture("meteorSmall");

			// TEMP
			//Asteroid asteroid = new Asteroid(this);
			//asteroid.SetState(new Vector2(0), new Vector2(0.3f), new Vector2(0), 0f, 0.05f);
			//asteroids.Add(asteroid);

			for (int i = 0; i < 10; i++) {
				asteroidPool.New(this);
			}
		}


		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			LoadTextures();
		}

		protected override void UnloadContent() {
		}

		private bool ExitRequested() {
			return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
						  || Keyboard.GetState().IsKeyDown(Keys.Escape);
		}

		protected override void Update(GameTime gameTime) {
			if (ExitRequested()) {
				Exit();
				return;
			}

			asteroidPool.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();
			/*
				  spriteBatch.Draw(textures["Background/starBackground"], new Rectangle(0, 0, 800, 480), Color.White);
				  spriteBatch.Draw(textures["player"], new Vector2(400, 240), Color.White);

				  Texture2D asteroid = textures["meteorSmall"];

				  Rectangle sourceRectangle = new Rectangle(0, 0, asteroid.Width, asteroid.Height);
				  spriteBatch.Draw(asteroid, new Vector2(450, 240), sourceRectangle, Color.White, angle, new Vector2(0 + asteroid.Width / 2, 0 + asteroid.Height / 2), 1.0f, SpriteEffects.None, 1);
			*/

			asteroidPool.Draw(gameTime, spriteBatch);


			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
