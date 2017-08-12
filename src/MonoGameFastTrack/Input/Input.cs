using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public static class Input {
        public static bool IsKeyDown(Keys key, KeyboardState newKeyboardState) => newKeyboardState.IsKeyDown(key);
        public static bool WasKeyPressed(Keys key, KeyboardState oldKeyboardState, KeyboardState newKeyboardState) => !oldKeyboardState.IsKeyDown(key) && newKeyboardState.IsKeyDown(key);
        public static bool WasKeyReleased(Keys key, KeyboardState oldKeyboardState, KeyboardState newKeyboardState) => oldKeyboardState.IsKeyDown(key) && !newKeyboardState.IsKeyDown(key);
    }
}
