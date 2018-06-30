using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
  public class WaitAi : Ai {
    
		protected readonly Enemy thisEnemy;
  
		public WaitAi(Enemy entity) : base(entity) {
      this.thisEnemy = entity;
    }

    public override void Update(GameTime gameTime) {
			entity.vel.X = 0;
			entity.vel.Y = 0;
			if (entity.rand.Next(400) == 0) {
				thisEnemy.Mode = Mode.Pursue;
      }
    }
  }
}
