using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile {
    public interface ITile {
        Texture2D Texture { get; }
        Rectangle TexturePosition { get; }
        int Width { get; }
        int Height { get; }
        int XPosition { get; }
        int YPosition { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch, int offsetX = 0, int offsetY = 0);
    }
}