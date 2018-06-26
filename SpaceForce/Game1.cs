using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceForce.Desktop.entities;

namespace SpaceForce.Desktop {
	public class SpaceForceGame : Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
  
		internal Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();


		private float angle = 0;


		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			base.Initialize();

		}

		private void loadTexture(string name) {
			textures.Add(name, Content.Load<Texture2D>(name));
		}

		private void loadTextures() {
			loadTexture("Background/starBackground");
			loadTexture("player");
			loadTexture("meteorSmall");
		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			loadTextures();
		}

		protected override void UnloadContent() {
		}

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();



			// TODO: Add your update logic here

			angle += 0.01f;


			base.Update(gameTime);
      
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Beige);
			spriteBatch.Begin();

			spriteBatch.Draw(textures["Background/starBackground"], new Rectangle(0, 0, 800, 480), Color.White);
			spriteBatch.Draw(textures["player"], new Vector2(400, 240), Color.White);

			Texture2D asteroid = textures["meteorSmall"];

			Rectangle sourceRectangle = new Rectangle(0, 0, asteroid.Width, asteroid.Height);
			spriteBatch.Draw(asteroid, new Vector2(450, 240), sourceRectangle, Color.White, angle, new Vector2(0 + asteroid.Width / 2, 0 + asteroid.Height / 2), 1.0f, SpriteEffects.None, 1);
   
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
