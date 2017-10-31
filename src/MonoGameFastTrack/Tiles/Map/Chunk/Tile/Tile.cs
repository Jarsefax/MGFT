using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile {
    public class Tile : ITile {
        public Tile(int width, int height, int xPosition, int yPosition, Texture2D texture, Rectangle texturePosition) {
            Width = width;
            Height = height;

            XPosition = xPosition;
            YPosition = yPosition;

            Texture = texture;
            TexturePosition = texturePosition;
        }

        public Texture2D Texture { get; }
        public Rectangle TexturePosition { get; }
        public int Width { get; }
        public int Height { get; }
        public int XPosition { get; }
        public int YPosition { get; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) =>
            TilesApi.DrawTile(gameTime, spriteBatch, this);
    }
}