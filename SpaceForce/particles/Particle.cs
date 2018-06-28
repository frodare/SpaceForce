using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.particles {
	public class Particle {

		public Texture2D Texture;
		public Vector2 Position;
		public Vector2 Velocity;
		public float Angle;
		public float AngularVelocity;
		public Color Color;
		public float Size;
		public int TTL;

		public Particle() {
			Position = new Vector2(0, 0);
			Velocity = new Vector2(0, 0);
		}

		public void Init(Texture2D texture, float x, float y, float vx, float vy,
      float angle, float angularVelocity, Color color, float size, int ttl) {
			Texture = texture;
			Position.X = x;
			Position.Y = y;
			Velocity.X = vx;
			Velocity.Y = vy;
      Angle = angle;
      AngularVelocity = angularVelocity;
      Color = color;
      Size = size;
      TTL = ttl;
		}

		public void Update() {
			TTL--;
			Position += Velocity;
			Angle += AngularVelocity;
		}

		public void Draw(SpriteBatch spriteBatch) {
			Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
			Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

			spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
				Angle, origin, Size, SpriteEffects.None, 0f);
		}
	}

}
