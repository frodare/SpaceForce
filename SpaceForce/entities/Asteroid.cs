using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceForce.Desktop.entities {
	public class Asteroid : Entity {
		public Asteroid(SpaceForceGame game) : base(game) {
		}

		protected override Texture2D GetTexture(SpaceForceGame game) {
			return game.textures["meteorSmall"];
		}
	}
}
