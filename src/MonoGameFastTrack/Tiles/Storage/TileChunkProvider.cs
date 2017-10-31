using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage {
    public class TileChunkProvider : ITileChunkProvider {
        private ITileChunk[,] _chunks;

        public TileChunkProvider(int tileWidth, int tileHeight, Texture2D texture, int textureWidth) {
            var tileValues = new int[,] {
                { 1, 1, 1, 1, 1 ,1 },
                { 1, 2, 2, 2, 2 ,1 },
                { 1, 2, 0, 0, 2 ,1 },
                { 1, 2, 0, 0, 2 ,1 },
                { 1, 2, 2, 2, 2 ,1 },
                { 1, 1, 1, 1, 1 ,1 }
            };

            var height = tileValues.GetLength(1);
            int width = tileValues.GetLength(0);

            ITile[,] tiles = new ITile[height, tileValues.GetLength(0)];
            for (var x = 0; x < width; x++) {
                for (var y = 0; y < height; y++) {
                    var tileValue = tileValues[y, x];
                    var texturePosition = GetTexturePosition(tileValue, textureWidth, tileWidth, tileHeight);
                    tiles[y, x] = new Tile(tileWidth, tileHeight, x, y, texture, new Rectangle(texturePosition, new Point(tileWidth, tileHeight)));
                }
            }

            _chunks = new ITileChunk[,] { { new TileChunk(tiles) } };
        }

        private static Point GetTexturePosition(int tileValue, int textureWidth, int tileWidth, int tileHeight) {
            var x = tileValue;
            var y = 0;
            while (x > textureWidth - 1) {
                x = x - textureWidth;
                y++;
            }

            return new Point(x * tileWidth, y * tileHeight);
        }

        public ITileChunk GetChunk(int tileMapX, int tileMapY) =>
            _chunks[tileMapY, tileMapX];
    }
}