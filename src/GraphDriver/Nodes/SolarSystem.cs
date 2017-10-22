using Jarsefax.Xna.MonoGameFastTrack.Graph;
using Microsoft.Xna.Framework;

namespace GraphDriver.Nodes {
    public class SolarSystem : Node {
        public SolarSystem(Vector2 position) : base() {
            Position = position;
        }

        public Vector2 Position { get; set; }
    }
}
