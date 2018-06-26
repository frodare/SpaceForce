using Microsoft.Xna.Framework.Audio;

namespace SpaceForce.Desktop.entities {
	public class LaserPool : EntityPool<Laser> {

    public LaserPool(SpaceForceGame game) : base(game) {
    }
    
    protected override Laser NewInstance() {
      return new Laser(game);
    }

    protected override void Init(Laser entity) {
			game.sounds["laser"].Play();
			entity.Dead = false;
    }
  
  }
}
