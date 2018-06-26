using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public abstract class EntityPool<T> where T: Entity {
    
		protected List<T> pool = new List<T>();
		protected SpaceForceGame game;
    
		public EntityPool(SpaceForceGame game) {
			this.game = game;
		}

		public T New() {
			T entity = GetExisting();
			if (entity == null) {
				entity = NewInstance();
				pool.Add(entity);
				game.entities.Add(entity);
			}
			Init(entity);
			return entity;
		}

		private T GetExisting() {
			foreach (var e in pool) {
        if (e.Dead) {
					return e;
        }
      }
			return null;
		}
    
		protected virtual void Init(T entity) {

		}

		protected abstract T NewInstance();

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
			foreach(var entity in pool) {
				entity.Draw(gameTime, spriteBatch);
      }
    }

    public void Update(GameTime gameTime) {
			foreach (var entity in pool) {
				entity.Update(gameTime);
      }
    }  
  }
}
