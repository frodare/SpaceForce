using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities {
	public class EnemyShipPool : EntityPool<Enemy> {

		private Random rand = new Random();

		public EnemyShipPool(SpaceForceGame game) : base(game) {
      
    }

		protected override Enemy NewInstance() {
			return new Enemy(game);
    }

		protected override void Init(Enemy e) {
      e.Dead = false;
			e.SetState(RandomPostion(game), Vector2.Zero, Vector2.Zero, 0, 0);
			e.Mode = Mode.Wait;
    }
    
		private Vector2 RandomPostion(SpaceForceGame game) {
      int w = game.graphics.GraphicsDevice.DisplayMode.Width;
      int x = rand.Next(w);
      return new Vector2(x, 0);
    }
  }
}
