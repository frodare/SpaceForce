using System;
using SpaceForce.Desktop.entities;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop {
	public class AsteroidPool : EntityPool<Asteroid> {

		private Random rand = new Random();

		private int NumberOnScreen { set; get; }

		public AsteroidPool(SpaceForceGame game) : base(game) {
			NumberOnScreen = 50;
		}

		protected override Asteroid NewInstance() {
			return new Asteroid(game);
		}

		protected override void Init(Asteroid asteroid) {
			asteroid.Dead = false;
			asteroid.Mass = rand.Next(2) + 1;
			asteroid.IFrames = 40;
			asteroid.SetState(RandomPostion(game), RandomVeclocity(), new Vector2(0), 0, RandomRotation());
		}

		public void respawnDead() {
			int count = 0;
			foreach (Asteroid asteroid in pool) {
				if (!asteroid.Dead) {
					count++;
				}
			}
			if (count < NumberOnScreen) {
				New();
			}
		}

		private float RandomRotation() {
			return ((float)rand.NextDouble() - 0.5f) / 10f;
		}

		private Vector2 RandomVeclocity() {
			float x = (float)rand.NextDouble() - 0.5f;
			float y = (float)rand.NextDouble() * 4 + 2;
			return new Vector2(x, y);
		}

		private Vector2 RandomPostion(SpaceForceGame game) {
			int w = game.graphics.GraphicsDevice.DisplayMode.Width;
			int x = rand.Next(w);
			return new Vector2(x, 0);
		}

	}
}
