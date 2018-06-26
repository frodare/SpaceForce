using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
 
	public abstract class Entity {

		private Texture2D texture;
		private Rectangle size;
		private Vector2 origin;

		protected Vector2 pos;
		protected Vector2 vel;
		protected Vector2 acc;

		protected float rotVel;
		protected float rot;

		public bool Dead { get; set; }

		protected abstract Texture2D GetTexture(SpaceForceGame game);
    
		public Entity(SpaceForceGame game) {
			texture = GetTexture(game);
      size = new Rectangle(0, 0, texture.Width, texture.Height);
      origin = new Vector2(0 + texture.Width / 2, 0 + texture.Height / 2);
		}

		public void Freeze() {
			pos = new Vector2(0);
			vel = new Vector2(0);
			acc = new Vector2(0);
			rot = 0;
			rotVel = 0;
		}

		public void SetState(Vector2 pos, Vector2 vel, Vector2 acc, float rot, float rotVel) {
			this.pos = pos;
			this.vel = vel;
			this.acc = acc;
			this.rot = rot;
			this.rotVel = rotVel;
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			if (Dead) {
				return;
			}
			spriteBatch.Draw(texture, pos, size, Color.White, rot, origin, 1.0f, SpriteEffects.None, 1);
		}

		public virtual void Update(GameTime gameTime) {
			if (Dead) {
        return;
      }
			vel += acc;
			pos += vel;
			rot += rotVel;
		}

	}
}
