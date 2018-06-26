using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceForce.Desktop.entities {
	public class Player : Entity {
		private const float PlayerSpeed = 8f;
		private const float PlayerDrag = 0.9f;
		private LaserPool laserPool;
		private bool triggerDown = false;

		public Player(SpaceForceGame game, LaserPool laserPool) : base(game) {
			this.laserPool = laserPool;
		}
  
		public override void Update(GameTime gameTime) {
			Decel();
			HandleControls();
			base.Update(gameTime);
		}
    
		private void Decel() {
			if (Math.Abs(vel.X) > float.Epsilon) {
				vel.X *= PlayerDrag;
			}

			if (Math.Abs(vel.X) < 0.01f) {
				vel.X = 0;
			}

			if (Math.Abs(vel.Y) > float.Epsilon) {
        vel.Y *= PlayerDrag;
      }
      
			if (Math.Abs(vel.Y) < 0.01f) {
        vel.Y = 0;
      }

		}

		private void HandleControls() {
			KeyboardState state = Keyboard.GetState();
      
			textureIndex = 0;

			if (state.IsKeyDown(Keys.Right)) {
        vel.X = PlayerSpeed;
				textureIndex = 2;
      } else if (state.IsKeyDown(Keys.Left)) {
        vel.X = -PlayerSpeed;
				textureIndex = 1;
      }
         
      if (state.IsKeyDown(Keys.Up)) {
        vel.Y = -PlayerSpeed;
      } else if (state.IsKeyDown(Keys.Down)) {
        vel.Y = PlayerSpeed;
      }

			if (state.IsKeyDown(Keys.Space)) {
				if (!triggerDown) {
					FireLaser();
					triggerDown = true;
				}
			} else {
				triggerDown = false;
			}
		}

		public void FireLaser() {
			Laser laser = laserPool.New();
			laser.pos = pos;
		}

		protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["player"], game.textures["playerLeft"], game.textures["playerRight"] };
		}
	}
}