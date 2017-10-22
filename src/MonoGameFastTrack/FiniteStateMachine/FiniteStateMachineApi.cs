using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public static class FiniteStateMachineApi {
        public static IState UpdateExplicit(IState state, GameTime gameTime) => state.Update(gameTime);
        public static IState Update(IFiniteStateMachine finiteStateMachine, GameTime gameTime) => UpdateExplicit(finiteStateMachine.CurrentState, gameTime);

        public static void DrawExplicit(IDrawableState state, GameTime gameTime) => state.Draw(gameTime);
        public static void Draw(IDrawableFiniteStateMachine finiteStateMachine, GameTime gameTime) => DrawExplicit(finiteStateMachine.CurrentDrawableState, gameTime);
    }
}