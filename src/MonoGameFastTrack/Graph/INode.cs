using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.Graph {
    public interface INode {
        INode Parent { get; set; }
        List<INode> Children { get; set; }

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}