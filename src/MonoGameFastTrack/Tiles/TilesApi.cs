using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles {
    public static class TilesApi {
        public static void DrawTileExplicit(GameTime gameTime, SpriteBatch spriteBatch, Texture2D texture, Rectangle texturePosition, int xPosition, int width, int yPosition, int height) {
            var position = new Rectangle(xPosition * width, yPosition * height, width, height);
            spriteBatch.Draw(
                texture,
                position,
                texturePosition,
                Color.White);
        }

        public static void DrawTile(GameTime gameTime, SpriteBatch spriteBatch, ITile tile) =>
            DrawTileExplicit(gameTime, spriteBatch, tile.Texture, tile.TexturePosition, tile.XPosition, tile.Width, tile.YPosition, tile.Height);

        public static void DrawTileChunkExplicit(GameTime gameTime, SpriteBatch spriteBatch, ITile[,] tiles) {
            var width = tiles.GetLength(1);
            var height = tiles.GetLength(0);

            for (var x = 0; x < width; x++) {
                for (var y = 0; y < height; y++) {
                    tiles[y, x].Draw(gameTime, spriteBatch);
                }
            }
        }

        public static void DrawTileChunk(GameTime gameTime, SpriteBatch spriteBatch, ITileChunk chunk) =>
            DrawTileChunkExplicit(gameTime, spriteBatch, chunk.Tiles);

        public static void DrawTileMapExplicit(GameTime gameTime, SpriteBatch spriteBatch, ITileChunkProvider chunkProvider, int chunkX, int chunkY) {
            var chunk = chunkProvider.GetChunk(chunkX, chunkY);
            chunk.Draw(gameTime, spriteBatch);
        }

        public static void DrawTileMap(GameTime gameTime, SpriteBatch spriteBatch, ITileMap map) =>
            DrawTileMapExplicit(gameTime, spriteBatch, map.ChunkProvider, map.ChunkX, map.ChunkY);
    }
}
