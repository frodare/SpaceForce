using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace SpaceForce.Desktop.entities {
	public class Player : Entity {
		private const float PlayerSpeed = 8f;
		private const float PlayerDrag = 0.9f;
		private LaserPool laserPool;
		private bool triggerDown = false;

		private Color iFrameColor = new Color(1f, 0.6f, 0.6f);
    
		private int iFrames = 0;
  
		public int Life { get; set; }

		public Player(SpaceForceGame game, LaserPool laserPool) : base(game) {
			this.laserPool = laserPool;
			Life = 5;
			scale = 0.75f;
		}
  
		public override void Update(GameTime gameTime) {
			DecIFrames();
			Decel();
			HandleControls();
			base.Update(gameTime);
			KeepOnScreen();
			//game.particleEngine.EmitterLocation = pos;
		}

		private void DecIFrames() {
			if (iFrames > 0) {
        iFrames--;
				Collidable = false;
				textureColor = (iFrames/2) % 2 == 0 ? iFrameColor : Color.White;
      } else {
        textureColor = Color.White;
				Collidable = true;
      }
		}

		private void KeepOnScreen() {
      int w = game.graphics.GraphicsDevice.DisplayMode.Width;
      int h = game.graphics.GraphicsDevice.DisplayMode.Height;

			if (pos.X > w) {
        pos.X = w;
      }

			if (pos.Y > h) {
        pos.Y = h;
      }

			if (pos.Y < 0) {
        pos.Y = 0;
      }

			if (pos.X < 0) {
        pos.X = 0;
      }
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
  
		public override void onCollide(Entity foreignEntity) {
			if (iFrames > 0) return;

			if (foreignEntity.GetType() == typeof(Laser) && Object.ReferenceEquals(this, ((Laser)foreignEntity).shooter)) {
        return;
      }

			iFrames = 20;
      game.sounds["explosionHit"].Play(0.7f, 0, 0);
			Life--;
			System.Console.WriteLine("Life: " + Life);
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
				game.particleEngine.EmitExhast(5, pos.X, pos.Y, 8);
      } else if (state.IsKeyDown(Keys.Down)) {
        vel.Y = PlayerSpeed;
			} else {
				game.particleEngine.EmitExhast(2, pos.X, pos.Y, 4);
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
			laser.vel.Y = -12f;
			laser.shooter = this;
		}

		protected override Texture2D[] GetTextures() {
			return new Texture2D[] { game.textures["player"], game.textures["playerLeft"], game.textures["playerRight"] };
		}
	}
}