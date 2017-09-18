using Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine;
using Jarsefax.Xna.MonoGameFastTrack.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FiniteStateMachineDriver {
    public class StateFour : IDrawableState {
        private readonly IInputManager _inputManager;
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _font;

        public StateFour(IInputManager inputManager, SpriteBatch spriteBatch, SpriteFont font) {
            _inputManager = inputManager;
            _spriteBatch = spriteBatch;
            _font = font;
        }

        public StateThree Previous { get; set; }

        public IState Update(GameTime gameTime) {
            if (_inputManager.WasKeyPressed(Keys.Left)) {
                return Previous;
            }

            return this;
        }

        public void Draw(GameTime gameTime) {
            _spriteBatch.DrawString(_font, "StateFour - Left to StateThree", new Vector2(100, 100), Color.White);
        }
    }
}