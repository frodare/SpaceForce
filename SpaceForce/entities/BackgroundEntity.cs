using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public class BackgroundEntity : Entity {
		
		public BackgroundEntity(SpaceForceGame game) : base(game) {
			Collidable = false;
			vel = new Vector2(0, 1f);
			scale = 3f;
			textureColor = new Color(110, 80, 210);
		}

		public override void Update(GameTime gameTime) {
      if (!Dead && IsOffScreen()) {
        Dead = true;
      }
      base.Update(gameTime);
    }

		protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["meteorBig"] };
		}
	}
}
