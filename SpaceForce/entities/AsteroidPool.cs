using System;
using SpaceForce.Desktop.entities;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop {
	public class AsteroidPool : EntityPool<Asteroid> {

		private Random rand = new Random();

		public AsteroidPool(SpaceForceGame game) : base(game) {
		}

		protected override Asteroid NewInstance() {
			return new Asteroid(game);
		}

		protected override void Init(Asteroid asteroid) {
			asteroid.Dead = false;
			asteroid.SetState(RandomPostion(game), RandomVeclocity(), new Vector2(0), 0, RandomRotation());
		}

		public void respawnDead() {
			foreach (Asteroid asteroid in pool) {
				if (asteroid.Dead) {
					Init(asteroid);
				}
			}
		}

		private float RandomRotation() {
			return ((float)rand.NextDouble() - 0.5f) / 10f;
		}

		private Vector2 RandomVeclocity() {
			float x = (float)rand.NextDouble() - 0.5f;
			float y = (float)rand.NextDouble() * 2;
			return new Vector2(x, y);
		}

		private Vector2 RandomPostion(SpaceForceGame game) {
			int w = game.graphics.GraphicsDevice.DisplayMode.Width;
			int x = rand.Next(w);
			return new Vector2(x, 0);
		}

	}
}
