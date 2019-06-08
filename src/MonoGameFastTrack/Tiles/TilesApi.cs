using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk.Tile;
using Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles {
    public static class TilesApi {
        public static void DrawTileExplicit(GameTime gameTime, SpriteBatch spriteBatch, Texture2D texture, Rectangle texturePosition, int xPosition, int width, int yPosition, int height, int xOffset = 0, int yOffset = 0) {
            var position = new Rectangle(xPosition * width - xOffset, yPosition * height - yOffset, width, height);
            spriteBatch.Draw(
                texture,
                position,
                texturePosition,
                Color.White);
        }

        public static void DrawTile(GameTime gameTime, SpriteBatch spriteBatch, ITile tile, int offsetX = 0, int offsetY = 0) =>
            DrawTileExplicit(gameTime, spriteBatch, tile.Texture, tile.TexturePosition, tile.XPosition, tile.Width, tile.YPosition, tile.Height, offsetX, offsetY);

        public static void DrawTileChunkExplicit(GameTime gameTime, SpriteBatch spriteBatch, ITile[,] tiles, int offsetX = 0, int offsetY = 0) {
            var width = tiles.GetLength(1);
            var height = tiles.GetLength(0);

            for (var x = 0; x < width; x++) {
                for (var y = 0; y < height; y++) {
                    tiles[y, x].Draw(gameTime, spriteBatch, offsetX, offsetY);
                }
            }
        }

        public static void DrawTileChunk(GameTime gameTime, SpriteBatch spriteBatch, ITileChunk chunk, int offsetX = 0, int offsetY = 0) =>
            DrawTileChunkExplicit(gameTime, spriteBatch, chunk.Tiles, offsetX, offsetY);

        public static void DrawTileMapExplicit(GameTime gameTime, SpriteBatch spriteBatch, ITileChunkProvider chunkProvider, int chunkX, int chunkY, int offsetX = 0, int offsetY = 0) {
            var chunk = chunkProvider.GetChunk(chunkX, chunkY);
            chunk.Draw(gameTime, spriteBatch, offsetX, offsetY);
        }

        public static void DrawTileMap(GameTime gameTime, SpriteBatch spriteBatch, ITileMap map, int offsetX = 0, int offsetY = 0) =>
            DrawTileMapExplicit(gameTime, spriteBatch, map.ChunkProvider, map.ChunkX, map.ChunkY, offsetX, offsetY);
    }
}
