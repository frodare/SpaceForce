using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceForce.Desktop.entities.ai;

namespace SpaceForce.Desktop.entities {
  
	public enum Mode {Pursue, Flee, Wait}

	public class Enemy : Entity {

		//public Mode Mode { get; set; }

		protected AiStack ai = new AiStack();

		protected Dictionary<Mode, Ai> behavior = new Dictionary<Mode, Ai>();
  
		public Enemy(SpaceForceGame game) : base(game) {
			//Mode = Mode.Wait;
			scale = 0.6f;
			Collidable = true;

			PursueAi pursueAi = new PursueAi(this, 10) {
        Offset = new Vector2(0, 300f)
      };

			ai.Add(pursueAi);
			ai.Add(new FleeAi(this, 1));


      /*
			
      
			behavior.Add(Mode.Flee, new FleeAi(this));
			behavior.Add(Mode.Wait, new WaitAi(this));
			behavior.Add(Mode.Pursue, pursueAi);
*/
			target = game.player;
    }

    public override void Update(GameTime gameTime) {
			//behavior[Mode].Update(gameTime);
			ai.Update(gameTime);
      base.Update(gameTime);
    }
      
		public override void Attack() {
      Laser laser = game.laserPool.New();
      laser.pos = pos;
			laser.shooter = this;
			laser.vel.Y = 12f;
    }

		public override void onCollide(Entity foreignEntity) {
			if (foreignEntity.GetType() != typeof(Laser)) return;

			if (((Laser)foreignEntity).shooter.GetType() == typeof(Enemy)) return;

			game.particleEngine.EmitAsteriodExplosion(20, pos.X, pos.Y, vel.X, vel.Y);
      Dead = true;
    }

    protected override Texture2D[] GetTextures() {
      return new Texture2D[] { game.textures["enemyShip"] };
    }
  }
}
