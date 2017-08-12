using Microsoft.Xna.Framework.Input;

namespace Jarsefax.Xna.MonoGameFastTrack.Input {
    public interface IInputManager {
        void Update();
        bool KeyIsDown(Keys w);
        bool KeyWasPressed(Keys up);
    }
}
