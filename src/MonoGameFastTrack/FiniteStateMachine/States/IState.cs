using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public interface IState {
        IState Update(GameTime gameTime);
    }
}