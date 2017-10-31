using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk {
    public interface ITileChunk {
        ITile[,] Tiles { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}