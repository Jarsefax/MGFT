using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.Graph {
    public static class GraphApi {
        private static void UpdateNodeExplicit(GameTime gameTime, List<INode> children) {
            foreach (var child in children) {
                child.Update(gameTime);
            }
        }

        public static void UpdateNode(GameTime gameTime, INode node) => UpdateNodeExplicit(gameTime, node.Children);

        private static void DrawNodeExplicit(GameTime gameTime, List<INode> children) {
            foreach (var child in children) {
                child.Draw(gameTime);
            }
        }

        public static void DrawNode(GameTime gameTime, INode node) => DrawNodeExplicit(gameTime, node.Children);
    }
}