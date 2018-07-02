using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
	public abstract class Ai {

		protected readonly Entity entity;
		protected readonly int priority;

		public Ai(Entity entity, int priority) {
		  this.entity = entity;
			this.priority = priority;
	  }

		public abstract bool ShouldExecute();

		public abstract void Start();

		public abstract bool Update(GameTime gameTime);

		public bool IsMoreImporantThan(Ai otherAi) {
			if (otherAi == null) return true;
			return priority > otherAi.priority;
		}
	}
}
