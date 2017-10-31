using Microsoft.Xna.Framework;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map {
    public class TileMap : ITileMap {

        public TileMap(ITileChunkProvider provider, int chunkX, int chunkY) {
            ChunkProvider = provider;
            ChunkX = chunkX;
            ChunkY = chunkY;
        }

        public ITileChunkProvider ChunkProvider { get; }
        public int ChunkX { get; }
        public int ChunkY { get; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) =>
            TilesApi.DrawTileMap(gameTime, spriteBatch, this);
    }
}