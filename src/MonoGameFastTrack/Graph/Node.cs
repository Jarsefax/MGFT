using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.Graph {
    public class Node : INode {
        public Node() {
            Children = new List<INode>();
        }

        public Node(INode parent) {
            Parent = parent;
            Children = new List<INode>();
        }

        public Node(List<INode> children) {
            Children = children;
        }

        public Node(INode parent, List<INode> children) {
            Parent = parent;
            Children = children;
        }

        public INode Parent { get; set; }
        public List<INode> Children { get; set; }

        public virtual void Update(GameTime gameTime) => GraphApi.UpdateNode(gameTime, this);
        public virtual void Draw(GameTime gameTime) => GraphApi.DrawNode(gameTime, this);
    }
}