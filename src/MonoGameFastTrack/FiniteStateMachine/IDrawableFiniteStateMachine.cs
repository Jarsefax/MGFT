using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public interface IDrawableFiniteStateMachine : IFiniteStateMachine {
        IDrawableState CurrentDrawableState { get; }

        void Draw(GameTime gameTime);
    }
}