using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.particles.handlers {
	public class AsteroidFragment : TypeHandler {

    private Random random = new Random();
    private SpaceForceGame game;

		public AsteroidFragment(SpaceForceGame game) {
      this.game = game;
    }

    public void Init(Particle particle, float x, float y, float vx, float vy) {
			particle.type = Type.AsteroidFragment;
			particle.Texture = game.textures["meteorSmall"];
      particle.pos.X = x;
      particle.pos.Y = y;
			particle.vel.X = vx + (float)((random.NextDouble() - 0.5) * 10);
			particle.vel.Y = vy + (float)((random.NextDouble() - 0.5) * 10);
      particle.rotvel = 0.1f * (float)(random.NextDouble() * 2 - 1);
      particle.sizevel = 0;

			particle.color = Color.White;

			particle.color *= 0.8f;


			particle.size = (float) (random.NextDouble() + 0.5) / 3;
			particle.life = 60 + random.Next(40);
    }

    public void Update(Particle particle) {
      particle.life--;
      particle.pos += particle.vel;
      particle.rot += particle.rotvel;
    }

  
  }
}
