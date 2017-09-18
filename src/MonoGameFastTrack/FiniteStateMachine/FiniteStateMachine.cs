using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Jarsefax.Xna.MonoGameFastTrack.FiniteStateMachine {
    public abstract class FiniteStateMachine : IFiniteStateMachine {
        protected readonly List<IState> _states;

        public FiniteStateMachine(List<IState> states, IState startingState) {
            _states = states;
            CurrentState = startingState;
        }

        public abstract IState CurrentState { get; set; }

        public void Update(GameTime gameTime) {
            CurrentState = FiniteStateMachineApi.Update(this as IFiniteStateMachine, gameTime);
        }
    }
}