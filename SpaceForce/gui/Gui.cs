using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.gui {
	public class Gui {

		protected SpaceForceGame game;
    
		public Gui(SpaceForceGame game) {
      this.game = game;
    }
    
		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
      
    }

    public virtual void Update(GameTime gameTime) {
      
    }

  }
}
