using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceForce.Desktop.entities;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

/**
 * 
 * Space Shooter graphics by Kenney Vleugels (www.kenney.nl)
 * Song: (DL Sounds) https://www.dl-sounds.com/royalty-free/sci-fi-pulse-loop/
 * Sound: Laser shot (peepholecircus) https://freesound.org/people/peepholecircus/sounds/169989/
 * 
 */

namespace SpaceForce.Desktop {
	public class SpaceForceGame : Game {

		internal GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Song song;
		private int cleanupCounter = 0;
		public Random rand = new Random();

		private List<Entity> entities = new List<Entity>();
		private List<Entity> newEntities = new List<Entity>();

		internal Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
		internal Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
    
		internal AsteroidPool asteroidPool;
		internal LaserPool laserPool;
		internal Player player;
  
		public void RegisterEntity(Entity e) {
			newEntities.Add(e);
		}
    
		public SpaceForceGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			asteroidPool = new AsteroidPool(this);
			laserPool = new LaserPool(this);
		}

		protected override void Initialize() {
			base.Initialize();
		}

		private void LoadTexture(string name) {
			textures.Add(name, Content.Load<Texture2D>(name));
		}

		private void LoadTextures() {
			LoadTexture("Background/starBackground");
			LoadTexture("player");
			LoadTexture("playerLeft");
			LoadTexture("playerRight");
			LoadTexture("meteorSmall");
			LoadTexture("meteorBig");
			LoadTexture("laserRed");
			LoadTexture("laserGreen");

			sounds.Add("laser", Content.Load<SoundEffect>("laser"));

			player = new Player(this, laserPool);
			entities.Add(player);
      player.SetState(new Vector2(400, 400), Vector2.Zero, Vector2.Zero, 0, 0);
		}
    
		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);
			LoadTextures();
			this.song = Content.Load<Song>("Sci-fi Pulse Loop");
			MediaPlayer.Play(song);
			MediaPlayer.IsRepeating = true;
		}
  
		protected override void UnloadContent() {
		}

		private bool ExitRequested() {
			return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
						  || Keyboard.GetState().IsKeyDown(Keys.Escape);
		}

		protected override void Update(GameTime gameTime) {
			if (ExitRequested()) {
				Exit();
				return;
			}
   
			HandleCollisions();
			foreach (var e in entities) {
        e.Update(gameTime);
      }
			cleanupCounter++;
      
			if (cleanupCounter > 20) {
        cleanupCounter = 0;
				asteroidPool.respawnDead();
      }

			InsertNewEntities();

			base.Update(gameTime);
		}

		private void InsertNewEntities() {
			entities.AddRange(newEntities);
			newEntities.Clear();
		}

		private void HandleCollisions() {
			foreach (var e1 in entities) {
				if (e1.Dead) continue;
				foreach (var e2 in entities) {
					if (e2.Dead || object.ReferenceEquals(e1, e2)) continue;
					if (e1.isCollidingWith(e2)) {
						e1.onCollide(e2);
						e2.onCollide(e1);
					}
        }
      }
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();   
			foreach (var e in entities) {
				e.Draw(gameTime, spriteBatch);
			}   
			spriteBatch.End();
			base.Draw(gameTime);
		}

	}
}
