using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public class Asteroid : BaseEntity {

    
		public Asteroid(Texture2D texture, Vector2 pos) : base(texture) {
			this.pos = pos;
			this.acc = new Vector2(0.02f, 0.02f);
		}
	}
}
