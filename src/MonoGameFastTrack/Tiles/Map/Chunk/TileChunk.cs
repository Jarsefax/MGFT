using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk {
    public class TileChunk : ITileChunk {
        public ITile[,] Tiles { get; }

        private int Width => Tiles.GetLength(1);
        private int Height => Tiles.GetLength(0);

        public TileChunk(ITile[,] tiles) {
            Tiles = tiles;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) =>
            TilesApi.DrawTileChunk(gameTime, spriteBatch, this);
    }
}