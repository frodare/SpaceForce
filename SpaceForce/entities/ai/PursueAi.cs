using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
	public class PursueAi : Ai {

		protected readonly Entity target;
		protected readonly Enemy thisEnemy;
    public Vector2 Offset { get; set; }

		public PursueAi(Enemy entity, Entity target) : base(entity) {
			this.target = target;
			this.thisEnemy = entity;
		}

		public override void Update(GameTime gameTime) {
			Pursue();
		}

		private void Pursue() {
			thisEnemy.vel = target.pos - thisEnemy.pos;
			thisEnemy.vel -= Offset;

			if (entity.vel.LengthSquared() < 25) {
				thisEnemy.Attack();
				thisEnemy.Mode = Mode.Flee;
        return;
      }

			thisEnemy.vel.Normalize();
			thisEnemy.vel *= thisEnemy.maxSpeed;
    }
	}
}
