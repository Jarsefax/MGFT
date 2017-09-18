using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public interface IDrawableState : IState {
        void Draw(GameTime gameTime);
    }
}