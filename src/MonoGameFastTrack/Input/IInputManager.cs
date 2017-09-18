using Jarsefax.Xna.MonoGameFastTrack.Menu;
using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public interface IInputManager {
        KeyboardState OldKeyboardState { get; }
        KeyboardState NewKeyboardState { get; }

        void Update();
        bool IsKeyDown(Keys w);
        bool WasKeyPressed(Keys up);

        MenuInputs GetMenuInput();
    }
}