using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public interface Entity {
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime, SpriteBatch spriteBatch);
	}
}
