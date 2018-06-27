using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.gui {
	public class LifeGui : Gui {

		private Vector2 pos = new Vector2(20f, 20f);
    
		public LifeGui(SpaceForceGame game) : base(game) {
			
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			Vector2 offset = new Vector2(0, 0);
			for (int i = 0; i < game.player.Life; i++) {
				spriteBatch.Draw(game.textures["life"], pos + offset, Color.White);
				offset += new Vector2(100f, 0f);
			}
		}
  }
}
