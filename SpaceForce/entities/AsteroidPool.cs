using System;
using SpaceForce.Desktop.entities;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop {
	public class AsteroidPool : EntityPool<Asteroid> {

		private Random rand = new Random();

		protected override Asteroid NewInstance(SpaceForceGame game) {
      return new Asteroid(game);
    }

		protected override void Init (SpaceForceGame game, Asteroid asteroid) {
			asteroid.SetState(RandomPostion(game), RandomVeclocity(), new Vector2(0), 0, RandomRotation());
    }

		private float RandomRotation() {
			return (float) rand.NextDouble() / 10;
		}

		private Vector2 RandomVeclocity() {
			float x = (float) rand.NextDouble() - 0.5f;
			float y = (float) rand.NextDouble();
			return new Vector2(x, y);
		}

		private Vector2 RandomPostion(SpaceForceGame game) {
			int w = game.graphics.GraphicsDevice.DisplayMode.Width;
			int x = rand.Next(w);
			return new Vector2(x, 0);
		}

	}
}
