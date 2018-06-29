using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.particles {
	public class ExhastHandler : TypeHandler {
		
		private Random random = new Random();
    private List<Texture2D> textures;
		private SpaceForceGame game;
    
		public ExhastHandler(SpaceForceGame game, List<Texture2D> textures) {
      this.textures = textures;
			this.game = game;
    }

		public void Init(Particle particle, float x, float y, float vx, float vy) {
			particle.type = Type.Rainbow;
			particle.Texture = textures[0];
      particle.pos.X = x;
      particle.pos.Y = y;
			particle.vel.X = 1f * (float)(random.NextDouble() * 2 - 1) + vx;
			particle.vel.Y = 1f * (float)(random.NextDouble() * 2 - 1) + vy;
      particle.rotvel = 0.1f * (float)(random.NextDouble() * 2 - 1);
      particle.sizevel = 0.09f;

			particle.color.R = (byte)(random.Next(100) + 156);
      particle.color.G = (byte)random.Next(150);
      particle.color.B = (byte)random.Next(100);

      particle.opacity = 1f;
			particle.opacityvel = -0.005f * (((float)random.NextDouble() / 2) + 0.5f);
      
      particle.size = (float)random.NextDouble() ;
      particle.life = 40;   
		}

		public void Update(Particle particle) {
			particle.life--;
			particle.pos += particle.vel;
			particle.rot += particle.rotvel;
			particle.size += particle.sizevel;
			particle.opacity += particle.opacityvel;
			if (particle.color.B > 0)	particle.color.B--;
			particle.color *= particle.opacity;
		}

	}
}
