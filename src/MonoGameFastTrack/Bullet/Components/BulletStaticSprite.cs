using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Bullet.Components {
    public class BulletStaticSprite {
        Texture2D _texture;
        private int _width;
        private int _height;

        public BulletStaticSprite(Texture2D texture, int width, int height) {
            _texture = texture;
            _width = width;
            _height = height;
        }

        internal void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, new Vector2(100, 100), new Rectangle(0, 0, _width, _height), Color.White);
        }
    }
}
