using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
 
	public abstract class Entity {

		private Texture2D[] textures;
		private Rectangle size;
		private Vector2 origin;

		public Vector2 pos;
		public Vector2 vel;
		public Vector2 acc;

		public float rotVel;
		public float rot;

		protected SpaceForceGame game;
		protected int textureIndex = 0;

		public bool Dead { get; set; }

		protected abstract Texture2D[] GetTextures();

		protected Entity(SpaceForceGame game) {
			this.game = game;
			textures = GetTextures();
			Texture2D texture = textures[0];
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

		protected bool IsOffScreen() {
      int w = game.graphics.GraphicsDevice.DisplayMode.Width;
      int h = game.graphics.GraphicsDevice.DisplayMode.Height;
      return pos.X > w || pos.Y > h || pos.X < 0 || pos.Y < 0;
    }

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			if (Dead) {
				return;
			}
			spriteBatch.Draw(textures[textureIndex], pos, size, Color.White, rot, origin, 1.0f, SpriteEffects.None, 1);
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
