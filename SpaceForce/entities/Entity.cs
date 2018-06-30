using System;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {

	public abstract class Entity {

		private Texture2D[] textures;
		private Rectangle textureSize;
		private Vector2 origin;

		public Vector2 pos;
		public Vector2 vel;
		public Vector2 acc;

		public float rotVel;
		public float rot;

		public int size;
		public float scale = 1f;
		public double sqHalfSize;

		public SpaceForceGame game;
		protected int textureIndex = 0;
		protected Color textureColor = Color.White;


		public Random rand;

		public bool Dead { get; set; }
		public bool Collidable { get; set; }

		protected abstract Texture2D[] GetTextures();

		public virtual void Attack() {

		}

		protected Entity(SpaceForceGame game) {
			this.game = game;
			SizeTexture();
			Collidable = true;
			SetupRand();
		}

		private void SetupRand() {
			var rncCsp = new RNGCryptoServiceProvider();
      byte[] salt = new byte[4];
      rncCsp.GetBytes(salt);
      rand = new Random(BitConverter.ToInt32(salt, 0));
		}

		protected void SizeTexture() {
			textures = GetTextures();
      Texture2D texture = textures[textureIndex];
      textureSize = new Rectangle(0, 0, texture.Width, texture.Height);
      origin = new Vector2(0 + texture.Width / 2, 0 + texture.Height / 2);
			SetSize(MathHelper.Max(textureSize.Bottom, textureSize.Width));
		}

		protected void SetSize(int size) {
			this.size = size;
      sqHalfSize = Math.Pow(size / 2, 2);
		}

		public bool isCollidingWith(Entity foreignEntity) {
			float distanceSq = (pos - foreignEntity.pos).LengthSquared();
			return distanceSq < (sqHalfSize + foreignEntity.sqHalfSize);
		}

		public virtual void onCollide(Entity foreignEntity) {

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
			spriteBatch.Draw(textures[textureIndex], pos, textureSize, textureColor, rot, origin, scale, SpriteEffects.None, 1);
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
