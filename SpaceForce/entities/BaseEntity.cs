using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public abstract class BaseEntity : Entity {

		private Texture2D texture;

		protected Vector2 pos;
		protected Vector2 vel;
		protected Vector2 acc;
		protected float rot;
  

		public BaseEntity(Texture2D texture) {
			this.texture = texture;
		}
    
		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			spriteBatch.Draw(texture, pos, sourceRectangle, Color.White, rot, new Vector2(0 + texture.Width / 2, 0 + texture.Height / 2), 1.0f, SpriteEffects.None, 1);
		}

		public void Update(GameTime gameTime) {
			vel += acc;
			pos += vel;
      
      // min max vel/pos/acc

      // TODO check if key is down
		}


	}
}
