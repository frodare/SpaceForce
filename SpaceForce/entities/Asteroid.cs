using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceForce.Desktop.entities {
	public class Asteroid : Entity {

		private SpaceForceGame game;

		public Asteroid(SpaceForceGame game) : base(game) {
			this.game = game;
		}

		private bool isOffScreen() {
			int w = game.graphics.GraphicsDevice.DisplayMode.Width;
			int h = game.graphics.GraphicsDevice.DisplayMode.Height;
			return pos.X > w || pos.Y > h || pos.X < 0 || pos.Y < 0;
		}

		public override void Update(GameTime gameTime) {
			if (!Dead && isOffScreen()) {
				Dead = true;
			}
			base.Update(gameTime);
		}

		protected override Texture2D GetTexture(SpaceForceGame game) {
			return game.textures["meteorSmall"];
		}
	}
}
