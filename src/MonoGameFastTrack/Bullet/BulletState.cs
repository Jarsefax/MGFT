using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet {
    public abstract class BulletState {
        public BulletState Origin { set; protected get; }
        public BulletState Destination { set; protected get; }

        public abstract BulletState Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}