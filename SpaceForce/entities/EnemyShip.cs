using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {

	public enum Mode {Pursue, Flee, Wait}

	public class EnemyShip : Entity {
       
		private Mode mode;
		private float maxSpeed = 5f;
		private Random rand = new Random();
    

		public EnemyShip(SpaceForceGame game) : base(game) {
			mode = Mode.Wait;
			scale = 0.6f;
			Collidable = false;
    }

    public override void Update(GameTime gameTime) {

			switch (mode) {
				case Mode.Flee:
					Flee();
					break;
				case Mode.Pursue:
					Pursue();
					break;
				case Mode.Wait:
					if (rand.Next(200) == 0) {
						mode = Mode.Pursue;
					}
					break;
			}

      base.Update(gameTime);
    }

		private void Flee() {
			vel = Vector2.Zero - pos;
      
      if (vel.LengthSquared() < 25) {
				mode = Mode.Wait;
        return;    
      }
   
      vel.Normalize();
      vel *= maxSpeed;
    }

		private void Pursue() {
			vel = game.player.pos - pos;
			vel.Y -= 400;

			if (vel.LengthSquared() < 25) {
				FireLaser();
				mode = Mode.Flee;
				return;
			}

			vel.Normalize();
			vel *= maxSpeed;
		}

		public void FireLaser() {
      Laser laser = game.laserPool.New();
      laser.pos = pos;
			laser.vel.Y = 12f;
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
