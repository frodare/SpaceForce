using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities {
	public class EnemyShipPool : EntityPool<EnemyShip> {

		private Random rand = new Random();

		public EnemyShipPool(SpaceForceGame game) : base(game) {
      
    }

		protected override EnemyShip NewInstance() {
			return new EnemyShip(game);
    }

		protected override void Init(EnemyShip e) {
      e.Dead = false;
			e.SetState(RandomPostion(game), Vector2.Zero, Vector2.Zero, 0, 0);
    }
    
		private Vector2 RandomPostion(SpaceForceGame game) {
      int w = game.graphics.GraphicsDevice.DisplayMode.Width;
      int x = rand.Next(w);
      return new Vector2(x, 0);
    }
  }
}
