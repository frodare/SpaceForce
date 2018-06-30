using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
	public abstract class Ai {

		protected readonly Entity entity;

		public Ai(Entity entity) {
		  this.entity = entity;
	  }
  
		public abstract void Update(GameTime gameTime);
  }
}
