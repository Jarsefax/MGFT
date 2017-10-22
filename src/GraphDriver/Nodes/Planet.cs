using Jarsefax.Xna.MonoGameFastTrack.Graph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GraphDriver.Nodes {
    public class Planet : INode {
        private SolarSystem _solarSystem;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
        private Vector2 _offset;

        public Planet(SolarSystem solarSystem, SpriteBatch spriteBatch, Texture2D texture, Rectangle sourceRectangle, Vector2 offset) {
            _solarSystem = solarSystem;
            _spriteBatch = spriteBatch;
            _texture = texture;
            _sourceRectangle = sourceRectangle;
            _offset = offset;
        }

        public INode Parent {
            get => _solarSystem;
            set => throw new InvalidOperationException();
        }
        public List<INode> Children { get; set; }
        
        public void Draw(GameTime gameTime) {
            _spriteBatch.Draw(_texture, _solarSystem.Position + _offset, _sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime) {            
        }
    }
}
