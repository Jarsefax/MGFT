using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public static class InputApi {
        public static bool IsKeyDown(Keys key, IInputManager inputManager) => IsKeyDownExplicit(key, inputManager.NewKeyboardState);
        public static bool IsKeyDownExplicit(Keys key, KeyboardState newKeyboardState) => newKeyboardState.IsKeyDown(key);

        public static bool WasKeyPressed(Keys key, IInputManager inputManager) => WasKeyPressedExplicit(key, inputManager.OldKeyboardState, inputManager.NewKeyboardState);
        public static bool WasKeyPressedExplicit(Keys key, KeyboardState oldKeyboardState, KeyboardState newKeyboardState) => !oldKeyboardState.IsKeyDown(key) && newKeyboardState.IsKeyDown(key);

        public static bool WasKeyReleased(Keys key, KeyboardState oldKeyboardState, KeyboardState newKeyboardState) => oldKeyboardState.IsKeyDown(key) && !newKeyboardState.IsKeyDown(key);
        public static bool WasKeyReleasedExplicit(Keys key, KeyboardState oldKeyboardState, KeyboardState newKeyboardState) => oldKeyboardState.IsKeyDown(key) && !newKeyboardState.IsKeyDown(key);

        public static MenuInputs GetMenuInputState(IInputManager inputManager) => GetMenuInputStateExplicit(inputManager.OldKeyboardState, inputManager.NewKeyboardState);
        public static MenuInputs GetMenuInputStateExplicit(KeyboardState oldKeyboardState, KeyboardState newKeyboardState) {
            var up = newKeyboardState.IsKeyDown(Keys.Up) && !oldKeyboardState.IsKeyDown(Keys.Up);
            var down = newKeyboardState.IsKeyDown(Keys.Down) && !oldKeyboardState.IsKeyDown(Keys.Down);
            var enter = newKeyboardState.IsKeyDown(Keys.Enter) && !oldKeyboardState.IsKeyDown(Keys.Enter);

            if (enter) {
                return MenuInputs.Selected;
            }

            if (up && !down) {
                return MenuInputs.UpPressed;
            } else if (down && !up) {
                return MenuInputs.DownPressed;
            }

            return MenuInputs.Neutral;
        }
    }
}