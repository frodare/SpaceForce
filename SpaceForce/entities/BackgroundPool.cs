using System;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities {
	public class BackgroundPool : EntityPool<BackgroundEntity> {
		private Random rand = new Random();

    private int NumberOnScreen { set; get; }

		public BackgroundPool(SpaceForceGame game) : base(game) {
      NumberOnScreen = 2;
    }

		protected override BackgroundEntity NewInstance() {
			return new BackgroundEntity(game);
    }

		protected override void Init(BackgroundEntity e) {
      e.Dead = false;
			e.scale = (float) (rand.NextDouble() * 2 + 2);
			e.SetState(RandomPostion(game), new Vector2(0, 2f), Vector2.Zero, RandomRotation(), (float)((rand.NextDouble() - 0.5) / 500));
    }
    
    public void respawnDead() {
      if (rand.Next(40) != 0) {
				return;
      }
			int count = 0;

			foreach (BackgroundEntity e in pool) {
        if (!e.Dead) {
          count++;
        }
      }
      if (count < NumberOnScreen) {
        New();
      }
    }

    private float RandomRotation() {
      return ((float)rand.NextDouble() - 0.5f) / 10f;
    }

    private Vector2 RandomPostion(SpaceForceGame game) {
      int w = game.graphics.GraphicsDevice.DisplayMode.Width;
      int x = rand.Next(w);
      return new Vector2(x, 0);
    }

  
  }
}
