using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceForce.Desktop.entities {
	public class Asteroid : Entity {
  
		public Asteroid(SpaceForceGame game) : base(game) {
		}
    
		public override void Update(GameTime gameTime) {
			if (!Dead && IsOffScreen()) {
				Dead = true;
			}
			base.Update(gameTime);
		}

		protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["meteorSmall"] };
		}
	}
}
