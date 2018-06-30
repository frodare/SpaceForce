using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
  public class FleeAi : Ai {

    protected readonly Enemy thisEnemy;

		protected Vector2 fleeTo = new Vector2(0,0);
		private bool initalized = false;

		public FleeAi(Enemy entity) : base(entity) {
      this.thisEnemy = entity;
    }

		public override void Update(GameTime gameTime) {
			if (!initalized) ChooseFleeTo();
			Flee();
    }
    
		private void ChooseFleeTo() {
			initalized = true;
			int w = entity.game.graphics.GraphicsDevice.DisplayMode.Width;
      int x = entity.rand.Next(w);
			fleeTo.X = x;
			fleeTo.Y = entity.size;
		}

		private void Flee() {
			thisEnemy.vel = fleeTo - thisEnemy.pos;

			if (thisEnemy.vel.LengthSquared() < 25) {
				thisEnemy.Mode = Mode.Wait;
				initalized = false;
        return;
      }

			thisEnemy.vel.Normalize();
			thisEnemy.vel *= thisEnemy.maxSpeed;
    }
  }
}
