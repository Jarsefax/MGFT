using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public interface IFiniteStateMachine {
        IState CurrentState { get; }

        void Update(GameTime gameTime);
    }
}