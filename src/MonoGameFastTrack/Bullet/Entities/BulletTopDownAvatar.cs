using Jarsefax.Xna.MonoGameFastTrack.Bullet.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.Entities {
    public class BulletTopDownAvatar {
        BulletStaticSprite _sprite;

        public BulletTopDownAvatar(Texture2D texture, int frameWidth, int frameHeight, int animationLength) {
            _sprite = new BulletStaticSprite(texture);
        }

        public void Update(GameTime gameTime, BulletInput input) {

        }

        public void Draw(SpriteBatch spriteBatch) {
            _sprite.Draw(spriteBatch);
        }
    }
}
