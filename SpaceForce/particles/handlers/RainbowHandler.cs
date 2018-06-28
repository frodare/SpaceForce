using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.particles.handlers {
	public class RainbowHandler : TypeHandler {

		private Random random = new Random();
		private List<Texture2D> textures;
		private SpaceForceGame game;

		public RainbowHandler(SpaceForceGame game, List<Texture2D> textures) {
			this.textures = textures;
			this.game = game;
		}
		
		public void Init(Particle particle) {
			particle.type = Type.Exhast;
      particle.Texture = textures[random.Next(textures.Count)];
      particle.pos.X = game.player.pos.X;
      particle.pos.Y = game.player.pos.Y;
      particle.vel.X = 1f * (float)(random.NextDouble() * 2 - 1) * 1f;
      particle.vel.Y = 1f * (float)(random.NextDouble() * 2 - 1) + 10f;
      particle.rotvel = 0.1f * (float)(random.NextDouble() * 2 - 1);
      particle.sizevel = 0;

      particle.color.R = (byte)random.Next(256);
      particle.color.G = (byte)random.Next(256);
      particle.color.B = (byte)random.Next(256);

      particle.opacity = 1f;
      particle.opacityvel = 0;

      particle.size = (float)random.NextDouble();
      particle.life = 20 + random.Next(40);
    }

    public void Update(Particle particle) {
      particle.life--;
      particle.pos += particle.vel;
      particle.rot += particle.rotvel;
      particle.size += particle.sizevel;
      particle.opacity += particle.opacityvel;
      particle.color *= particle.opacity;
    }

  }
}
