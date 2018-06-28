using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.particles {
	public class ParticleEngine {
		private Random random;
		public Vector2 EmitterLocation { get; set; }

		private LinkedList<Particle> particles;
		private LinkedList<Particle> dead;

		private List<Texture2D> textures;

		public ParticleEngine(List<Texture2D> textures, Vector2 location) {
			EmitterLocation = location;
			this.textures = textures;
			this.particles = new LinkedList<Particle>();
			this.dead = new LinkedList<Particle>();
			random = new Random();
		}

		public void Update() {
			int total = 10;

			for (int i = 0; i < total; i++) {
				GenerateNewParticle();
			}


			LinkedListNode<Particle> current = particles.First;
			LinkedListNode<Particle> next;

			while (current != null) {
				next = current.Next;	
				current.Value.Update();
				if (current.Value.TTL <= 0) {
					particles.Remove(current);
					dead.AddLast(current.Value);
				}
				current = next;
			}

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

		private Particle GenerateNewParticle() {
			
			Texture2D texture = textures[random.Next(textures.Count)];
			float x = EmitterLocation.X;
			float y = EmitterLocation.Y;


			float vx = 1f * (float)(random.NextDouble() * 2 - 1);
			float vy = 1f * (float)(random.NextDouble() * 2 - 1) + 10f;

			float angle = 0;
			float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

			Color color = new Color(
						(float)random.NextDouble(),
						(float)random.NextDouble(),
						(float)random.NextDouble());

			float size = (float)random.NextDouble();

			int ttl = 20 + random.Next(40);

			Particle particle = GetParticleInstance();

			particle.Init(texture, x, y, vx, vy, angle, angularVelocity, color, size, ttl);

			return particle;
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
