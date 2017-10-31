using Jarsefax.Xna.MonoGameFastTrack.Tiles.Map.Chunk;

namespace Jarsefax.Xna.MonoGameFastTrack.Tiles.Storage {
    public interface ITileChunkProvider {
        ITileChunk GetChunk(int tileMapX, int tileMapY);
    }
}