using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public class InputManager : IInputManager {
        private KeyboardState _oldKeyboardState;
        private KeyboardState _newKeyboardState;

        public InputManager() {
            _oldKeyboardState = Keyboard.GetState();
            _newKeyboardState = Keyboard.GetState();
        }

        public virtual void Update() {
            _oldKeyboardState = _newKeyboardState;
            _newKeyboardState = Keyboard.GetState();
        }

        public bool KeyIsDown(Keys key) => Input.IsKeyDown(key, _newKeyboardState);
        public bool KeyWasPressed(Keys key) => Input.WasKeyPressed(key, _oldKeyboardState, _newKeyboardState);
    }
}
