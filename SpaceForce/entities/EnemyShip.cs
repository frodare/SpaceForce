using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public class EnemyShip : Entity {
    
		private float thrust = 0.1f;
		private float maxSpeed = 8f * 8f;
		
		public EnemyShip(SpaceForceGame game) : base(game) {
			
    }

    public override void Update(GameTime gameTime) {
			HeadTowards(game.player.pos);
      base.Update(gameTime);
    }

		private void HeadTowards(Vector2 target) {
			acc = target - pos;
			acc.Normalize();
			acc *= thrust;

			if (vel.LengthSquared() > maxSpeed) {
				//vel.Normalize();
				//vel *= maxSpeed;
			}
		}

		public override void onCollide(Entity foreignEntity) {
      if (object.ReferenceEquals(foreignEntity, game.player)) return;
      Dead = true;
    }

    protected override Texture2D[] GetTextures() {
      return new Texture2D[] { game.textures["enemyShip"] };
    }
  }
}
