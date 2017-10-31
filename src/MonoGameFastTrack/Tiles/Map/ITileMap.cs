using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map {
    public interface ITileMap {
        ITileChunkProvider ChunkProvider { get; }
        int ChunkX { get; }
        int ChunkY { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}