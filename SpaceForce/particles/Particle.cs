using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.particles {
	public class Particle {

		private Texture2D _texture;
		private Rectangle sourceRectangle;
		private Vector2 origin;

		public Texture2D Texture {
			get => _texture;
			set {
				_texture = value;
				MeasureTexture();
			}
		}

		public Type type;
		public Vector2 pos;
		public Vector2 vel;
		public float rot;
		public float rotvel;
		public Color color;
		public float size;
		public float sizevel;
		public float opacity;
		public float opacityvel;
		public int life;
  
		public Particle() {
			pos = new Vector2(0, 0);
			vel = new Vector2(0, 0);
			sourceRectangle = new Rectangle(0, 0, 0, 0);
      origin = new Vector2(0, 0);
		}

		private void MeasureTexture () {
			sourceRectangle.Width = _texture.Width;
			sourceRectangle.Height = _texture.Height;
			origin.X = _texture.Width / 2;
			origin.Y = _texture.Height / 2;
		}
    
		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, pos, sourceRectangle, color, rot, origin, size, SpriteEffects.None, 0f);
		}
	}

}
