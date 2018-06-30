using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public class Laser: Entity {
		public Laser(SpaceForceGame game) : base(game) {
			SetSize(6);
    }

    public override void Update(GameTime gameTime) {
      if (!Dead && IsOffScreen()) {
        Dead = true;
      }
      base.Update(gameTime);
    }

		public override void onCollide(Entity foreignEntity) {
			if (object.ReferenceEquals(foreignEntity, game.player)) return;
      Dead = true;
    }

    protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["laserRed"], game.textures["laserGreen"] };
    }
  }
}
