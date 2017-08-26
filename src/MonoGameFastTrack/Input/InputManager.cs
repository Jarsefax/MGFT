using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public class InputManager : IInputManager {
        public InputManager() {
            OldKeyboardState = Keyboard.GetState();
            NewKeyboardState = Keyboard.GetState();
        }

        public virtual void Update() {
            OldKeyboardState = NewKeyboardState;
            NewKeyboardState = Keyboard.GetState();
        }

        public KeyboardState OldKeyboardState { get; private set; }
        public KeyboardState NewKeyboardState { get; private set; }

        public bool IsKeyDown(Keys key) => InputApi.IsKeyDown(key, this);
        public bool WasKeyPressed(Keys key) => InputApi.WasKeyPressed(key, this);

        public MenuInputs GetMenuInput() => InputApi.GetMenuInputState(this);
    }
}
