using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
	public class PursueAi : Ai {

    public Vector2 Offset { get; set; }
		public float maxSpeed = 4f;
		  
		public PursueAi(Enemy entity, int priority) : base(entity, priority) {
}

    public override bool ShouldExecute() {
			return entity.target != null;
    }

    public override void Start() {
			System.Console.WriteLine("Starting Pursue");
    }

		public override bool Update(GameTime gameTime) {
			
			entity.vel = entity.target.pos - entity.pos;
			entity.vel -= Offset; 

			if (entity.vel.LengthSquared() < 25) {
				entity.target = null;
				entity.Attack();
        return false;
      }

			SetSpeed();
			return true;
		}

		private void SetSpeed() {
			entity.vel.Normalize();
			entity.vel *= maxSpeed;
    }

	}
}
