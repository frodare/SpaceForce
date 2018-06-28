using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceForce.Desktop.particles.handlers;

namespace SpaceForce.Desktop.particles {

	public enum Type {Rainbow, Exhast}

	public class ParticleEngine {
		
		private SpaceForceGame game;

		private LinkedList<Particle> particles;
		private LinkedList<Particle> dead;
		private List<Texture2D> textures;

		public ExhastHandler exhastHandler;
		public RainbowHandler rainbowHandler;

		public ParticleEngine(List<Texture2D> textures, SpaceForceGame game) {
			this.game = game;
			this.textures = textures;
			this.particles = new LinkedList<Particle>();
			this.dead = new LinkedList<Particle>();
			exhastHandler = new ExhastHandler(game, textures);
      rainbowHandler = new RainbowHandler(game, textures);
		}

		public void EmitExhast(int count, float x, float y, float vy) {
      for (int i = 0; i < count; i++) exhastHandler.Init(GetParticleInstance(), x, y, vy);
		}

   
		public void Update() {
			
      
			LinkedListNode<Particle> current = particles.First;
			LinkedListNode<Particle> next;

			while (current != null) {
				next = current.Next;
				UpdateParticle(current.Value);
				if (current.Value.life <= 0) {
					particles.Remove(current);
					dead.AddLast(current.Value);
				}
				current = next;
			}
		}
    
		private void UpdateParticle(Particle particle) {
			GetHandler(particle.type).Update(particle);
		}


		private Particle GetParticleInstance() {
			Particle particle;
			if (dead.First != null) {
				particle = dead.First.Value;
				dead.Remove(dead.First);
			} else {
				particle = new Particle();
			}
			particles.AddLast(particle);
			return particle;
		}

		private TypeHandler GetHandler(Type type) {
			switch (type) {
        case Type.Exhast: return exhastHandler;
        case Type.Rainbow: return rainbowHandler;
      }
			return null;
		}
  
		public void Draw(SpriteBatch spriteBatch) {
			LinkedListNode<Particle> current = particles.First;
			while (current != null) {
				current.Value.Draw(spriteBatch);
				current = current.Next;
      }
		}
	}
}
