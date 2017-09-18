using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public class DrawableFiniteStateMachine : FiniteStateMachine, IDrawableFiniteStateMachine {
        private readonly new List<IDrawableState> _states;

        public DrawableFiniteStateMachine(List<IDrawableState> states, IDrawableState startingState) : base(states.ConvertAll(s => (IState)s), startingState) {
            _states = states;
        }

        public IDrawableState CurrentDrawableState { get; private set; }
        public override IState CurrentState {
            get { return CurrentDrawableState as IState; }
            set { CurrentDrawableState = value as IDrawableState; }
        }

        public void Draw(GameTime gameTime) => FiniteStateMachineApi.Draw(this, gameTime);
    }
}