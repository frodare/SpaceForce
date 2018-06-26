using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceForce.Desktop.entities {
	public abstract class EntityPool<T> where T: Entity {
    
		List<T> pool = new List<T>();

		public T New(SpaceForceGame game) {
			T entity = GetExisting();
			if (entity == null) {
				entity = NewInstance(game);
				pool.Add(entity);
			}
			Init(game, entity);
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

		protected virtual void Init(SpaceForceGame game, T entity) {

		}

		protected abstract T NewInstance(SpaceForceGame game);

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
