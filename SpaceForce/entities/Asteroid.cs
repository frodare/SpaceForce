using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public class Asteroid : Entity {
    
		private int _mass;
		public int IFrames { set; get; }

		public int Mass {
			get { return _mass; }
			set {
				_mass = value;
				textureIndex = value - 1;
				SizeTexture();
				if (value != 1 && value != 2) Dead = true;
			}
		}

		public Asteroid(SpaceForceGame game) : base(game) {
			Mass = 1;
		}

		public override void Update(GameTime gameTime) {
			if (!Dead && IsOffScreen()) {
				Dead = true;
			}
			if (IFrames > 0) IFrames--;
			base.Update(gameTime);
		}

		public override void onCollide(Entity foreignEntity) {

			if (foreignEntity.GetType() == typeof(Asteroid) && IFrames > 0) {
				return;
			}
      
			Dead = true;

			float volume = Mass == 2 ? 0.8f : 0.4f;

			game.sounds["explosionCrash"].Play(volume, 0, 0);

			if (Mass > 1) {
				SpawnSmaller(pos);
			}
		}

		private Vector2 RandomOffset () {
			float x = (float)(game.rand.NextDouble() / 2) * 100f;
			float y = (float)(game.rand.NextDouble() / 2) * 100f;
			return new Vector2(x, y);
		}

		private void SpawnSmaller(Vector2 posIn) {
			for (int i = 0; i < 3; i++) {
				Asteroid a = game.asteroidPool.New();
				if (a == null) return;
				a.Mass = 1;
				a.IFrames = 80;
				a.pos = new Vector2(posIn.X, posIn.Y) + RandomOffset();
			}
		}

		protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["meteorSmall"], game.textures["meteorBig"] };
		}
	}
}
