using Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine;
using Jarsefax.Xna.MonoGameFastTrack.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FiniteStateMachineDriver {
    public class StateOne : IDrawableState {
        private readonly IInputManager _inputManager;
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _font;

        public StateOne(IInputManager inputManager, SpriteBatch spriteBatch, SpriteFont font) {
            _inputManager = inputManager;
            _spriteBatch = spriteBatch;
            _font = font;
        }

        public StateTwo NextOne { get; set; }
        public StateThree NextTwo { get; set; }

        public IState Update(GameTime gameTime) {
            if (_inputManager.WasKeyPressed(Keys.Right)) {
                return NextOne;
            } else if (_inputManager.WasKeyPressed(Keys.Up)) {
                return NextTwo;
            }

            return this;
        }

        public void Draw(GameTime gameTime) {
            _spriteBatch.DrawString(_font, "StateOne - Right to StateTwo, Up to StateThree", new Vector2(100, 100), Color.White);
        }
    }
}