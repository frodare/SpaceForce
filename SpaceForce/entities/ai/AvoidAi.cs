using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
  public class AvoidAi : Ai {

    protected readonly Enemy thisEnemy;

		public Vector2  Offset { get; set; }

		public AvoidAi(Enemy entity, int priority) : base(entity, priority) {
      this.thisEnemy = entity;
			Offset = Vector2.Zero;
    }
  
    public override bool ShouldExecute() {
			return false;
    }

    public override void Start() {
      
    }
  
		public override bool Update(GameTime gameTime) {
			return false;
    }

	}
}
