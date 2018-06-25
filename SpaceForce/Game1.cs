using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceForce.Desktop {
	public class Game1 : Game {
		private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

		private Texture2D background;
    private Texture2D ship;
    private Texture2D asteriod;

		private float angle = 0;

		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			background = Content.Load<Texture2D>("Background/starBackground");
			ship = Content.Load<Texture2D>("player");
			asteriod = Content.Load<Texture2D>("meteorSmall");
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

      spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
			spriteBatch.Draw(ship, new Vector2(400, 240), Color.White);

			Rectangle sourceRectangle = new Rectangle(0, 0, asteriod.Width, asteriod.Height);
			spriteBatch.Draw(asteriod, new Vector2(450, 240), sourceRectangle, Color.White, angle, new Vector2(0 + asteriod.Width/2, 0 + asteriod.Height /2), 1.0f, SpriteEffects.None, 1);

      spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
