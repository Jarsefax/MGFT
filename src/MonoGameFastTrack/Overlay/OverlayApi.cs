using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.Overlay {
    static class OverlayApi {
        public static void UpdateOverlayExplicit(GameTime gameTime) {
        }

        public static void UpdateNode(GameTime gameTime, IOverlay overlay) => UpdateOverlayExplicit(gameTime);

        public static void DrawOverlayExplicit(GameTime gameTime) {            
        }

        public static void DrawNode(GameTime gameTime, IOverlay node) => DrawOverlayExplicit(gameTime);
    }
}
