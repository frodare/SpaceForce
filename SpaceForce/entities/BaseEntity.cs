using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public abstract class BaseEntity {

		private string textureName;
		private Texture2D texture;
		private Rectangle size;
		private Vector2 origin;

		protected Vector2 pos;
		protected Vector2 vel;
		protected Vector2 acc;

		protected float rotVel;
		protected float rot;

		public bool Dead { get; set; }

		public BaseEntity(string textureName) {
			this.textureName = textureName;
		}

		public void Init(Dictionary<string, Texture2D> textures) {
			texture = textures[textureName];
			size = new Rectangle(0, 0, texture.Width, texture.Height);
			origin = new Vector2(0 + texture.Width / 2, 0 + texture.Height / 2);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			if (Dead) {
				return;
			}
			spriteBatch.Draw(texture, pos, size, Color.White, rot, origin, 1.0f, SpriteEffects.None, 1);
		}

		public void Update(GameTime gameTime) {
			if (Dead) {
        return;
      }
			vel += acc;
			pos += vel;
			rot += rotVel;
		}
	}
}
