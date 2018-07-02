using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
  public class FleeAi : Ai {
  
		protected Vector2 fleeTo = new Vector2(0,0);
		public float maxSpeed = 5f;
  
		public FleeAi(Enemy entity, int prority) : base(entity, prority) {
    }

		public override bool ShouldExecute() {
			return true;
		}
    
		public override void Start() {
			System.Console.WriteLine("Starting Flee");
			ChooseFleeTo();
		}

		public override bool Update(GameTime gameTime) {
			if ((entity.pos - fleeTo).LengthSquared() < 25) {
				//thisEnemy.Mode = Mode.Wait;
				//initalized = false;
				entity.target = entity.game.player;
        return false;
      }
			Flee();
			return true;
    }
    
		private void ChooseFleeTo() {
			int w = entity.game.graphics.GraphicsDevice.DisplayMode.Width;
      int x = entity.rand.Next(w);
			fleeTo.X = x;
			fleeTo.Y = entity.size;
		}

		private void Flee() {
			entity.vel = fleeTo - entity.pos;   
			entity.vel.Normalize();
			entity.vel *= maxSpeed;
    }
  }
}
